using BlazorAsyncFormValidationServer.Models;

namespace BlazorAsyncFormValidationServer.Services;

public sealed class MockBookingAvailabilityService : IBookingAvailabilityService
{
    private static readonly HashSet<string> UnavailableCombinations =
    [
        "Paris|Suite|2026-10-20|3|2",
        "Seattle|Standard|2026-10-22|2|4",
        "Tokyo|Deluxe|2026-10-25|5|2"
    ];

    public async Task<bool> IsCombinationAvailableAsync(BookingRequest request, CancellationToken cancellationToken = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);

        var key = $"{request.Destination}|{request.RoomType}|{request.CheckInDate:yyyy-MM-dd}|{request.Nights}|{request.Guests}";
        return !UnavailableCombinations.Contains(key);
    }
}
