
using Destinations.Common;
using ErrorOr;
using MediatR;

namespace Application.Destinations.GetAll;

public record GetAllDestinationsQuery() : IRequest<ErrorOr<IReadOnlyList<DestinationResponse>>>;