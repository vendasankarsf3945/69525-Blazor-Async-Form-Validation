using BlazorAsyncFormValidationWebAssembly.Client.Models;

namespace BlazorAsyncFormValidationWebAssembly.Client.Services;

public interface IBookingAvailabilityService
{
    Task<bool> IsCombinationAvailableAsync(BookingRequest request, CancellationToken cancellationToken = default);
}
