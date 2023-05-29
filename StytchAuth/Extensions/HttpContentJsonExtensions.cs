using System.Net;
using StytchAuth.Models.MagicLink;

namespace StytchAuth.Extensions;

public static class HttpContentJsonExtensions
{
    public static async Task<T> AddRequestInfo<T>(this Task<T?> task, HttpResponseMessage? request)
        where T : BaseMagicLinkErrorResponse, new()
    {
        var result = await task;
        if (result != null)
        {
            var statusCode = (HttpStatusCode)(result.StatusCode ?? 0);
            if (Enum.IsDefined(typeof(HttpStatusCode), statusCode))
            {
                return result with
                {
                    StatusCode = statusCode,
                    IsSuccessStatusCode = request?.IsSuccessStatusCode
                };
            }
            return result;
        }
        return new T();
    }
}
