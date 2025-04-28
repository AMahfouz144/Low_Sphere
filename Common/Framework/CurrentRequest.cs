using Microsoft.AspNetCore.Http;

namespace Common.Common
{
    public class CurrentRequest : ICurrentRequest
    {
        private readonly IHeaderDictionary headers;
        public CurrentRequest(IHttpContextAccessor httpContextAccessor)
        {
            headers = httpContextAccessor?.HttpContext.Request.Headers;
        }

        private string GetHeaderValue(string key) => headers[key].ToString();

        //public Language Language
        //{
        //    get
        //    {
        //        int res = 1;
        //        var val = GetHeaderValue("Accept-Language");
        //        if (!string.IsNullOrWhiteSpace(val))
        //        {
        //            val = val?.Trim().ToLowerInvariant();
        //            if (val.Contains("ar-eg"))
        //                res = 2;
        //        }

        //        return (Language)res;
        //    }
        //}


        public string AccessToken => GetHeaderValue("Authorization");
    }
}