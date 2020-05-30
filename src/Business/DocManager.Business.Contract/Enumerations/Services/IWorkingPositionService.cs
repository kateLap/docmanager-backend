using System.Collections.Generic;
using DocManager.Business.Contract.Enumerations.Models;

namespace DocManager.Business.Contract.Enumerations.Services
{
    public interface IWorkingPositionService
    {
        List<WorkingPosition> GetAll();

        void AddWorkingPosition(WorkingPosition workingPosition);

        void DeleteWorkingPosition(WorkingPosition workingPosition);
    }
}
