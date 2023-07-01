
using Domain.Primitives;
using Domain.Destinations;
using ErrorOr;
using MediatR;
using Domain.ValueObjects;
using Destinations.Common;

namespace Application.Destinations;
internal sealed class CreateDestinationCommandHandler : IRequestHandler<CreateDestinationCommand, ErrorOr<Unit>>
{
    private readonly IDestinationRepository _destinationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDestinationCommandHandler(IDestinationRepository destinationRepository, IUnitOfWork unitOfWork)
    {
        _destinationRepository = destinationRepository ?? throw new ArgumentNullException(nameof(destinationRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateDestinationCommand command, CancellationToken cancellationToken)
    {
        var destination = new Destination(
            new DestinationId(Guid.NewGuid()),
            command.Name,
            command.Description,
            command.Ubication,
            command.Active
            );

        await _destinationRepository.Add(destination);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}