using System.Collections.Generic;
using Newtonsoft.Json;

namespace FileManagement.Infrastructure
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiError
    {
        public string Message { get; set; }
        public IList<string> Errors { get; set; }
    }
}
