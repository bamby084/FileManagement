using System.Net;

namespace FileManagement.Common.Exceptions
{
    public class NotFoundException: HttpException
    {
        public override int StatusCode => (int) HttpStatusCode.NotFound;

        public NotFoundException()
            : base("Item not found.")
        {
        }

        public NotFoundException(string message)
            : base(message)
        {

        }
    }
}
