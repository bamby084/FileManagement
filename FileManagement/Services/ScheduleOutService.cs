using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FileManagement.DataAccess;
using FileManagement.DataAccess.Entities;
using FileManagement.Models;

namespace FileManagement.Services
{
    public class ScheduleOutService : IScheduleOutService
    {
        private IRepository<FileOut> _scheduleOutRepository;
        private IMapper _mapper;

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
    }
}
