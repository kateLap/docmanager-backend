using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using DocManager.Business.Contract.Documents.Models;
using DocManager.Business.Contract.Documents.Services;
using DocManager.Business.Contract.Users.Models;
using DocManager.Business.Contract.Users.Services;
using DocManager.Web.Models;
using Ninject;

namespace DocManager.Web.Controllers
{
    // [Authorize]
    [RoutePrefix("api/Documents")]
    public class DocumentsController : ApiController
    {
        #region Dependencies

        [Inject]
        public IDocumentService DocumentService { get; set; }

        [Inject]
        public IUserRetrievingService UserRetrievingService { get; set; }

        #endregion

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]DocumentModel model)
        {
            await AddCurrentUserAsDocumentReviewer(model);

            await DocumentService.CreateDocument(Mapper.Map<DocumentModel, Document>(model));

            return Ok();
        }

        [HttpGet]
        [Route("")]
        public List<DocumentModel> GetDocuments()
        {
            return DocumentService
                .GetAll(User.Identity.Name)
                .Select(Mapper.Map<Document, DocumentModel>)
                .ToList();
        }

        [HttpGet]
        [Route("{documentId:int}")]
        public DocumentModel GetDocument(int documentId)
        {
            Document document = DocumentService.GetDocument(User.Identity.Name, documentId);

            return Mapper.Map<DocumentModel>(document);
        }

        [HttpPut]
        [Route("{documentId:int}/approve")]
        public IHttpActionResult Approve(int documentId)
        {
            DocumentService.Approve(User.Identity.Name, documentId);
            return Ok();
        }

        [HttpPut]
        [Route("{documentId:int}/decline")]
        public IHttpActionResult Decline(int documentId)
        {
            DocumentService.Decline(User.Identity.Name, documentId);
            return Ok();
        }

        private async Task AddCurrentUserAsDocumentReviewer(DocumentModel document)
        {
            string selfName = User.Identity.Name;
            ProfileUser self = await UserRetrievingService.GetByUserName(selfName);
            Guid selfId = self.Id;

            if (document.Reviewers.All(e => e.UserName != selfName))
            {
                document.Reviewers.Add(
                    new ProfileModel()
                    {
                        Id = selfId
                    });
            }
        }
    }
}
