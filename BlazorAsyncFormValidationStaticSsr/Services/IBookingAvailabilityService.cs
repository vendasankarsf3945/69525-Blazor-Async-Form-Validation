using BlazorAsyncFormValidationStaticSsr.Models;

namespace BlazorAsyncFormValidationStaticSsr.Services;

public interface IBookingAvailabilityService
{
    Task<bool> IsCombinationAvailableAsync(BookingRequest request, CancellationToken cancellationToken = default);
}
