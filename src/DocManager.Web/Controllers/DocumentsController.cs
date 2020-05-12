using System;
using System.Web.Http;
using DocManager.Business.Contract.Documents.Models;
using DocManager.Business.Contract.Documents.Services;
using DocManager.Business.Contract.Users.Models;
using Microsoft.AspNet.Identity;
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
        public UserManager<ProfileUser, Guid> UserManager { get; set; }

        #endregion

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody]Document model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetDocuments()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{documentId:int}")]
        public IHttpActionResult GetDocument(int documentId)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{documentId:int}/approve")]
        public IHttpActionResult Approve(int documentId)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{documentId:int}/decline")]
        public IHttpActionResult Decline(int documentId)
        {
            return Ok();
        }
    }
}
