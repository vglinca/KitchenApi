using System;
using System.Threading;
using System.Threading.Tasks;

namespace KitchenApi.Services
{
    public interface IGrpcService
    {
        Task ReturnProcessedOrderAsync(Guid orderId, CancellationToken token);
    }
}