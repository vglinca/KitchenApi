using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.Extensions.Hosting;
using RestaurantService;

namespace KitchenApi.Services
{
    public class GrpcService : IGrpcService
    {
        private readonly GrpcDinningHallService.GrpcDinningHallServiceClient _client;

        public GrpcService()
        {
            var address = GetAddress();
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            var httpClient = new HttpClient(httpClientHandler);
            
            var channel = GrpcChannel.ForAddress(address, new GrpcChannelOptions
            {
                HttpClient = httpClient
            });

            _client = new GrpcDinningHallService.GrpcDinningHallServiceClient(channel);
        }
        
        private static string GetAddress()
        {
            var host = string.Empty;
            var port = 0;

            if (string.IsNullOrWhiteSpace(host))
            {
                host = "localhost";
            }

            port = 5001;

            return $"https://{host}:{port}";
        }

        public async Task ReturnProcessedOrderAsync(Guid orderId, CancellationToken token)
        {
            var request = new SendOrderBackRequest()
            {
                OrderId = orderId.ToString()
            };

            Console.WriteLine($"Sending back order with ID: '{orderId}'");
            await _client.SendOrderBackAsync(request, cancellationToken: token);
        }
    }
}