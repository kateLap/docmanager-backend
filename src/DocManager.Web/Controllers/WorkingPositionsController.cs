using System.Collections.Generic;
using System.Web.Http;
using DocManager.Business.Contract.Enumerations.Models;
using DocManager.Business.Contract.Enumerations.Services;
using Ninject;

namespace DocManager.Web.Controllers
{
    [RoutePrefix("api/Positions")]
    [Authorize]
    public class WorkingPositionsController : ApiController
    {
        [Inject]
        public IWorkingPositionService WorkingPositionService { get; set; }

        [HttpGet]
        [Route("{userId:guid}")]
        public List<WorkingPosition> GetWorkingPositions()
        {
            List<WorkingPosition> positions = WorkingPositionService.GetAll();

            return positions;
        }
    }
}
