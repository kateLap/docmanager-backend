using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DocManager.Business.Contract.Documents.Models;
using DocManager.Business.Contract.Documents.Services;
using DocManager.Business.Contract.Users.Models;
using Microsoft.AspNet.Identity;
using Ninject;

namespace DocManager.Web.Controllers
{
    //[Authorize]
    // [RoutePrefix("api/Versions")]
    public class DocumentVersionsController : ApiController
    {
        #region Dependencies

        [Inject]
        public IDocumentVersionService DocumentVersionService { get; set; }

        [Inject]
        public UserManager<ProfileUser, Guid> UserManager { get; set; }

        #endregion

        public class FileData
        {
            public string ContentType { get; set; }
            public string FileName { get; set; }
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            return DownloadLocalFile();
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody]FileData file)
        {
            byte[] fileBytes = File.ReadAllBytes("C:\\1.pdf");

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(new MemoryStream(fileBytes))
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "1.pdf"
            };

            return result;
        }

        [HttpPost]
        [Route("documents/{documentId:int}/versions")]
        public async Task<IHttpActionResult> Create(int documentId)
        {
            if (HttpContext.Current.Request.Files.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

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

            await DocumentVersionService.CreateDocumentVersion(documentVersion, fileBlob);

            return Ok();
        }

        [HttpGet]
        [Route("documents/{documentId:int}/versions")]
        public IHttpActionResult GetDocumentVersions(int documentId, int versionId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("documents/{documentId:int}/versions/{versionId:int}")]
        public HttpResponseMessage DownloadPolicyVersion(int documentId, int versionId)
        {
            return DownloadLocalFile();
        }

        private HttpResponseMessage DownloadLocalFile()
        {
            byte[] fileBytes = File.ReadAllBytes("C:\\1.doc");

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(new MemoryStream(fileBytes))
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/msword");//pdf

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "1.doc"
            };

            return result;
        }
    }
}
