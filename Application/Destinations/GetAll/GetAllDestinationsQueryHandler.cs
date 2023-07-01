using Destinations.Common;
using Domain.Destinations;
using ErrorOr;
using MediatR;

namespace Application.Destinations.GetAll;


internal sealed class GetAllDestinationsQueryHandler : IRequestHandler<GetAllDestinationsQuery, ErrorOr<IReadOnlyList<DestinationResponse>>>
{
    private readonly IDestinationRepository _destinationRepository;

    public GetAllDestinationsQueryHandler(IDestinationRepository destinationRepository)
    {
        _destinationRepository = destinationRepository ?? throw new ArgumentNullException(nameof(destinationRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<DestinationResponse>>> Handle(GetAllDestinationsQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Destination> destinations = await _destinationRepository.GetAll();

        return destinations.Select(Destination => new DestinationResponse(
                Destination.Id.Value,
                Destination.Name,
                Destination.Description,
                Destination.Ubication,
                Destination.Active
                )).ToList();
    }
}