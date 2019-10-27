using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FileManagement.DataAccess;
using FileManagement.DataAccess.Entities;
using FileManagement.ExtensionMethods;
using FileManagement.Models;
using System.Linq;

namespace FileManagement.Services
{
    public class ScheduleOutService : IScheduleOutService
    {
        private readonly IRepository<FileOut> _scheduleOutRepository;
        private readonly IMapper _mapper;

        public ScheduleOutService(IRepositoryFactory repositoryFactory, IMapper mapper)
        {
            _scheduleOutRepository = repositoryFactory.CreateRepository<FileOut>();
            _mapper = mapper;
        }

        public async Task<IList<ScheduleOut>> GetAllAsync()
        {
            var data = await _scheduleOutRepository.GetAllAsync();
            return _mapper.Map<IList<ScheduleOut>>(data);
        }

        public async Task<IList<ScheduleOut>> GetByProjectIdAsync(string projectId)
        {
            var data = await _scheduleOutRepository.FindAsync(entity => entity.ProjectId.EqualsIgnoreCase(projectId));
            data = data.OrderBy(e => e.ActivityId).ThenBy(e => e.ResourceCode);

            return _mapper.Map<IList<ScheduleOut>>(data);
        }
    }
}
