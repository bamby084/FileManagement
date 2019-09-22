
using System.Collections.Generic;
using System.Net;

namespace FileManagement.Common.Exceptions
{
    public class ValidationException: HttpException
    {
        private const string ErrorMessage = "Validation failed. Please see errors for details";

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public ValidationException()
            : base(ErrorMessage)
        {
        }

        public ValidationException(IList<string> errorDetails)
            : base(ErrorMessage)
        {
            ErrorDetails = errorDetails;
        }

        public ValidationException(string message)
            : base(message)
        {

        }

        public ValidationException(string message, IList<string> errorDetails)
            : base(message)
        {
            ErrorDetails = errorDetails;
        }
    }
}
