using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace DocManager.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Versions")]
    public class DocumentVersionsController : ApiController
    {
        public class FileData
        {
            public string ContentType { get; set; }
            public string FileName { get; set; }
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
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

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody]FileData file)
        {
            /*byte[] fileBytes = File.ReadAllBytes("C:\\1.pdf");

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(new MemoryStream(fileBytes))
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = file.FileName
            };


            // result.Content = new ByteArrayContent(fileBytes);

            return result;*/
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
    }
}
