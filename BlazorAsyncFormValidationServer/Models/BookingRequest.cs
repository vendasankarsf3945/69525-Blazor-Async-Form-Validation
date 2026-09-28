using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using BlazorAsyncFormValidationServer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAsyncFormValidationServer.Models;

public sealed class BookingRequest : IAsyncValidatableObject
{
    [Required]
    public string Destination { get; set; } = "Lisbon";

    [Required]
    public string RoomType { get; set; } = "Standard";

    [Range(typeof(DateOnly), "2026-01-01", "2100-12-31", ErrorMessage = "Check-in date must be between 2026-01-01 and 2100-12-31.")]
    public DateOnly CheckInDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddDays(7));

    [Range(1, 21)]
    public int Nights { get; set; } = 3;

    [Range(1, 6)]
    public int Guests { get; set; } = 2;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return [];
    }

    public async IAsyncEnumerable<ValidationResult> ValidateAsync(
        ValidationContext validationContext,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var availabilityService = validationContext.GetRequiredService<IBookingAvailabilityService>();
        var isAvailable = await availabilityService.IsCombinationAvailableAsync(this, cancellationToken);

        if (!isAvailable)
        {
            yield return new ValidationResult(
                $"No availability was found for {Destination} ({RoomType}) on {CheckInDate:yyyy-MM-dd} for {Guests} guest(s).",
                [nameof(Destination), nameof(RoomType), nameof(CheckInDate), nameof(Guests)]);
        }
    }
}
