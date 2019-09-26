
namespace FileManagement.DataAccess.Entities
{
    public class User: BaseEntity
    {
        public string Email { get; set; }
        public string ApiSecret { get; set; }
    }
}
