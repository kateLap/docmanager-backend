using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using DocManager.Business.Contract.Core.Exceptions;
using DocManager.Business.Contract.Documents.Models;
using DocManager.Business.Contract.Documents.Services;
using DocManager.Business.Contract.Users.Models;
using DocManager.Web.Models;
using Microsoft.AspNet.Identity;
using Ninject;

namespace DocManager.Web.Controllers
{
    //[Authorize]
    //[RoutePrefix("api/Versions")]
    public class DocumentVersionsController : ApiController
    {
        private string[] _supportedMediaTypes =
        {
            "application/pdf",
            "text/plain",
            "application/octet-stream"
        };

        #region Dependencies

        [Inject]
        public IDocumentVersionService DocumentVersionService { get; set; }

        [Inject]
        public UserManager<ProfileUser, Guid> UserManager { get; set; }

        #endregion

        [HttpPost]
        [Route("documents/{documentId:int}/versions")]
        public async Task<IHttpActionResult> Create(int documentId)
        {
            if (documentId <= 0)
            {
                throw new DocManagerException("Document Is should be greater than zero.");
            }

            if (HttpContext.Current.Request.Files.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            //if (_supportedMediaTypes.All(e => postedFile.ContentType != e))
            //{
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //}

            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            
            var fileBlob = new FileBlob()
            {
                Content = bytes,
                Details = postedFile.ContentType
            };

            var documentVersion = new DocumentVersion()
            {
                Document = new Document() { Id = documentId },
                Name = postedFile.FileName,
            };

            await DocumentVersionService.CreateDocumentVersion(User.Identity.Name, documentVersion, fileBlob);

            return Ok();
        }

        [HttpGet]
        [Route("documents/{documentId:int}/versions")]
        public List<DocumentVersionModel> GetDocumentVersions(int documentId)
        {
            var versions = DocumentVersionService.GetAll(documentId).ToList();

            return versions.Select(Mapper.Map<DocumentVersionModel>).ToList();
        }

        [HttpGet]
        [Route("documents/{documentId:int}/versions/{versionId:int}")]
        public async Task<HttpResponseMessage> DownloadDocumentVersion(int documentId, int versionId)
        {
            var version = await DocumentVersionService.GetDocumentVersion(versionId);

            byte[] fileBytes = version.FileBlob.Content;//"C:\\1.doc"

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(new MemoryStream(fileBytes))
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue(version.FileBlob.Details);//pdf

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = version.Name //"1.doc"
            };

            return result;
        }

        private HttpResponseMessage DownloadLocalFile(string name)
        {
            byte[] fileBytes = File.ReadAllBytes(name);//"C:\\1.doc"

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(new MemoryStream(fileBytes))
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/msword");//pdf

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = name //"1.doc"
            };

            return result;
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            return DownloadLocalFile("");
        }
    }
}
