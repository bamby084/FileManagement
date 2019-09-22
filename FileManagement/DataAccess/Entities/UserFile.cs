using System;

namespace FileManagement.DataAccess.Entities
{
    public class UserFile: BaseEntity
    {
        public Guid UserId { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }
}
