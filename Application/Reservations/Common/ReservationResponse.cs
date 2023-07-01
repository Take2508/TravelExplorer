using MediatR;
using ErrorOr;

namespace Application.Reservations.Common;

public record ReservationResponse(
    Guid ReservationCode,
    string Name,
    string Email,
    string PhoneNumber,
    DateTime TravelDate,
    DateTime ReservationDate,
    TouristPackageResponse touristPackageResponse
) : IRequest<ErrorOr<ReservationResponse>>;

public record TouristPackageResponse(
    string Name,
    List<LineItemResponse> Destinations
    );

public record LineItemResponse(
    string Name,
    string Ubication);
