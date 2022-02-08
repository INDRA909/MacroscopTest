using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.VisualStudio.Services.Profile;

namespace GrpcServer.gRPC
{
   public class LimitClientRequests: Interceptor //Реализован некоректно, DuplexStreamingServerHandler - работает с потоком запросов в целом
    {
        int MaxNumberRequests;
        int CurrentNumberRequests = 0;
        public LimitClientRequests(int maxNumberRequests)
        {
            this.MaxNumberRequests = maxNumberRequests;
        }
        public override async Task DuplexStreamingServerHandler
            <TRequest, TResponse>(IAsyncStreamReader<TRequest> requestStream,
            IServerStreamWriter<TResponse> responseStream,
            ServerCallContext context,
            DuplexStreamingServerMethod<TRequest, TResponse> continuation)
        {
            CurrentNumberRequests++;
            if (CurrentNumberRequests > MaxNumberRequests)
            {
                throw new RpcException(new Status(StatusCode.PermissionDenied, "The server is overloaded"));
            }
            else
            {
                CurrentNumberRequests--;
                await base.DuplexStreamingServerHandler(requestStream, responseStream, context, continuation);
            }
        }
    }   
}
