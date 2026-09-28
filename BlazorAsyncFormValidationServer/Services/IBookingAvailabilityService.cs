using BlazorAsyncFormValidationServer.Models;

namespace BlazorAsyncFormValidationServer.Services;

public interface IBookingAvailabilityService
{
    Task<bool> IsCombinationAvailableAsync(BookingRequest request, CancellationToken cancellationToken = default);
}
