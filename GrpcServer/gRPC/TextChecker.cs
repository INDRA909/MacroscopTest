using Grpc.Core;
using ServerGrpc;

namespace GrpcServer.Services
{
    public class TextChecker:PalindromeService.PalindromeServiceBase
    {
        public override async Task GetCheckForPalindrome(
            IAsyncStreamReader<PalindromeRequest> requestStream,
            IServerStreamWriter<PalindromeResponse> responseStream,            
            ServerCallContext context)
        {
            await foreach(var request in requestStream.ReadAllAsync())
            {
                Thread.Sleep(2000);
                await responseStream.WriteAsync(new PalindromeResponse()
                {                   
                    Check = CheckForPalindrome(request.Text)
                }) ;
            }                                           
        }
        private bool CheckForPalindrome(string text)
        {
            for (int i = 0; i < text.Length / 2; ++i)
            {
                if (text[i] != text[text.Length - 1 - i] && char.ToLower(text[i]) != char.ToLower(text[text.Length - 1 - i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
