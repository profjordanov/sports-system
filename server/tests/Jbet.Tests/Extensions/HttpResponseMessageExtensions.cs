using Shouldly;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jbet.Tests.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<TResponse> ShouldDeserializeTo<TResponse>(this HttpResponseMessage response)
        {
            var deserialized = await response?
                .Content?
                .ReadAsAsync<TResponse>();

            return deserialized != null ?
                deserialized :
                throw new ShouldAssertException($"Expected the response to be of type {typeof(TResponse).FullName} but could not deserialize it.");
        }
    }
}