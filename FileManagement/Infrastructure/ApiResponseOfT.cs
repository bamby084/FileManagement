using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace FileManagement.Infrastructure
{
    public class ApiResponse<TValue> : IConvertToActionResult
    {
        public bool Success { get; set; }

        public int StatusCode { get; set; }

        public int ErrorCode { get; set; }

        public TValue Data { get; set; }
        
        public IActionResult Convert()
        {
            return new ObjectResult(this) { DeclaredType = typeof(ApiResponse<TValue>) };
        }

        protected ApiResponse() { }

        protected ApiResponse(TValue value)
        {
            Success = true;
            StatusCode = (int)HttpStatusCode.OK;
            Data = value;
        }

        protected ApiResponse(ApiResponse response)
        {
            Success = response.Success;
            StatusCode = response.StatusCode;
            Data = (TValue)response.Data;
        }

        public static implicit operator ApiResponse<TValue>(TValue value)
        {
            return new ApiResponse<TValue>(value);
        }

        public static implicit operator ApiResponse<TValue>(ApiResponse response)
        {
            return new ApiResponse<TValue>(response);
        }
    }
}
