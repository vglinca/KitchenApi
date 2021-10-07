using System;
using System.Threading;
using System.Threading.Tasks;

namespace KitchenApi.Services
{
    public interface ICookingService
    {
        Task PrepareOrderAsync(Guid orderId, CancellationToken token);
    }
}