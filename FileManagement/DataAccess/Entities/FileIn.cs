
namespace FileManagement.DataAccess.Entities
{
    public class FileIn: BaseEntity
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileContent { get; set; }
        public bool IsProcessed { get; set; }
    }
}
