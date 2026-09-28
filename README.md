# Blazor async whole-form validation sample for #69525

This repository provides sample apps for [dotnet/aspnetcore#69525](https://github.com/dotnet/aspnetcore/issues/69525):

- Interactive Server: [BlazorAsyncFormValidationServer](./BlazorAsyncFormValidationServer)
- Static SSR: [BlazorAsyncFormValidationStaticSsr](./BlazorAsyncFormValidationStaticSsr)
- Interactive WebAssembly: [BlazorAsyncFormValidationWebAssembly](./BlazorAsyncFormValidationWebAssembly)

## Scenario

Each app includes a `/booking` page with:

- A booking `EditForm`
- `DataAnnotationsValidator` and `ValidationSummary`
- A model implementing `IAsyncValidatableObject`
- A delayed mock availability service
- `OnValidSubmit` and `OnInvalidSubmit` result messages

The async model-level validation checks the full combination:

`Destination + RoomType + CheckInDate + Nights + Guests`

## Interactive behavior (Server and WebAssembly)

While async validation is running:

- `EditContext.IsValidationPending()` is observed
- A pending message is shown
- The submit button is disabled

When validation completes:

- Available selection => `OnValidSubmit` message
- Unavailable selection => validation error and `OnInvalidSubmit` message

## Static SSR behavior

The static SSR app uses form POST binding (`[SupplyParameterFromForm]` + `method="post"` + `FormName`) and waits for async validation before rendering the response.

## Unavailable sample combinations

Use one of these to trigger an invalid submit:

- `Paris | Suite | 2026-10-20 | 3 nights | 2 guests`
- `Seattle | Standard | 2026-10-22 | 2 nights | 4 guests`
- `Tokyo | Deluxe | 2026-10-25 | 5 nights | 2 guests`

## Run

```powershell
dotnet run --project .\BlazorAsyncFormValidationServer\BlazorAsyncFormValidationServer.csproj
dotnet run --project .\BlazorAsyncFormValidationStaticSsr\BlazorAsyncFormValidationStaticSsr.csproj
dotnet run --project .\BlazorAsyncFormValidationWebAssembly\BlazorAsyncFormValidationWebAssembly\BlazorAsyncFormValidationWebAssembly.csproj
```

