using System.Web.Http;

namespace DocManager.Web.Controllers
{
    [RoutePrefix("api/Statuses")]
    public class StatusesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("Succeeded!");
        }
    }
}
