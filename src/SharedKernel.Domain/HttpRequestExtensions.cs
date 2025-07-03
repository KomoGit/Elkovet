using Microsoft.AspNetCore.Http;

namespace SharedKernel.Domain
{
    public static class HttpRequestExtensions
    {
        public static string GetBaseUrl(this HttpRequest request)
        {
            // Check if the request object is null
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            // Construct base URL from the request
            var baseUrl = $"{request.Scheme}://{request.Host}";
            return baseUrl;
        }
    }
}