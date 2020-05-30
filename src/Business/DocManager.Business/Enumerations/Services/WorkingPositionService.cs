using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DocManager.Business.Contract.Enumerations.Models;
using DocManager.Business.Contract.Enumerations.Services;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace DocManager.Business.Enumerations.Services
{
    public class WorkingPositionService : IWorkingPositionService
    {
        private readonly IWorkingPositionRepository _workingPositionRepository;

        public WorkingPositionService(IWorkingPositionRepository workingPositionRepository)
        {
            _workingPositionRepository = workingPositionRepository;
        }

        public List<WorkingPosition> GetAll()
        {
            var positions = _workingPositionRepository.GetAll().ToList();

            return positions.Select(Mapper.Map<WorkingPosition>).ToList();
        }

        public void AddWorkingPosition(WorkingPosition workingPosition)
        {
            _workingPositionRepository.Add(Mapper.Map<WorkingPositionEntity>(workingPosition));

            _workingPositionRepository.CommitAsync();
        }

        public void DeleteWorkingPosition(WorkingPosition workingPosition)
        {
            _workingPositionRepository.Delete(Mapper.Map<WorkingPositionEntity>(workingPosition));

            _workingPositionRepository.CommitAsync();
        }
    }
}
