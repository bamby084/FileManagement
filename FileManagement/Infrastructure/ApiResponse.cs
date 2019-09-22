using System.Net;

namespace FileManagement.Infrastructure
{
    public class ApiResponse : ApiResponse<object>
    {
        public static ApiResponse NotFound => new ApiResponse()
        {
            StatusCode = (int)HttpStatusCode.NotFound,
            Success = false,
            Data = new ApiError()
            {
                Message = "Item not found."
            }
        };

        public static ApiResponse NoContent => new ApiResponse()
        {
            StatusCode = (int)HttpStatusCode.NoContent,
            Success = true
        };

        public static ApiResponse Created => new ApiResponse()
        {
            StatusCode = (int)HttpStatusCode.Created,
            Success = true
        };
    }
}
