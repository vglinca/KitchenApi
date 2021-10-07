using System;
using System.Threading;
using System.Threading.Tasks;

namespace KitchenApi.Services
{
    public class CookingService : ICookingService
    {
        private readonly IGrpcService _grpcService;

        public CookingService(IGrpcService grpcService)
        {
            _grpcService = grpcService;
        }

        public async Task PrepareOrderAsync(Guid orderId, CancellationToken token)
        {
            Console.WriteLine($"Getting an Order with ID: '{orderId}'");
            Thread.Sleep(2000);
            await _grpcService.ReturnProcessedOrderAsync(orderId, token);
        }
    }
}