
namespace FileManagement.DataAccess.Entities
{
    public class FileOut: BaseEntity
    {
        public string SapId { get; set; }
        public string ActivityId { get; set;}
        public string ResourceCode { get; set; }
        public decimal ResourceQuantity { get; set; }
    }
}
