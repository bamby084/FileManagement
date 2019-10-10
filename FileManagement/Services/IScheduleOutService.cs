using FileManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManagement.Services
{
    public interface IScheduleOutService
    {
        Task<IList<ScheduleOut>> GetAllAsync();
    }
}
