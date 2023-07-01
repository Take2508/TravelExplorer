using Domain.TouristPackages;
using ErrorOr;
using MediatR;

namespace Application.Reservations.Update;

public record UpdateReservationCommand(
    Guid Id,
    string Name,
    string Email,
    string PhoneNumber,
    TouristPackageId TouristPackageId,
    DateTime Traveldate
    ) : IRequest<ErrorOr<Unit>>;