using StytchAuth.Models.MagicLink;

namespace StytchAuth.Extensions;

public static class HttpContentJsonExtensions
{
    public static async Task<T?> AddRequestInfo<T>(this Task<T?> task, HttpResponseMessage request)
        where T : BaseMagicLinkErrorResponse
    {
        var result = await task;
        if (result != null)
        {
            return result with
            {
                StatusCode = request.StatusCode,
                IsSuccessStatusCode = request.IsSuccessStatusCode
            };
        }
        return result;
    }
}
