using AutoMapper;
using FileManagement.DataAccess.Entities;
using FileManagement.Models;

namespace FileManagement.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<FileOut, ScheduleOut>();
            CreateMap<User, XmlUser>();
        }
    }
}
