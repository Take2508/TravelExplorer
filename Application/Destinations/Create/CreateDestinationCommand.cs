using ErrorOr;
using MediatR;

namespace Application.Destinations;

public record CreateDestinationCommand(
    string Name,
    string Description,
    string Ubication,
    bool Active
) : IRequest<ErrorOr<Unit>>;