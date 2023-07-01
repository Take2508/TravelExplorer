using Domain.Customers;
using Domain.Reservations;
using Domain.Primitives;
using ErrorOr;
using MediatR;
using Domain.ValueObjects;

namespace Application.Reservations.Create;
public sealed class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ErrorOr<Unit>>
{

    private readonly IReservationRepository _reservationRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitofwork;
    public CreateReservationCommandHandler(IReservationRepository reservationRepository, IUnitOfWork unitofwork, ICustomerRepository customerRepository)
    {

        _reservationRepository = reservationRepository;
        _unitofwork = unitofwork;
        _customerRepository = customerRepository;
    }


    public async Task<ErrorOr<Unit>> Handle(CreateReservationCommand command, CancellationToken cancellationToken)
    {
        if (PhoneNumber.Create(command.PhoneNumber) is not PhoneNumber phoneNumber)
        {
            return Error.Validation("Customer.PhoneNumber", " is not a valid phone number");
        }

        var reservation = Reservation.Create(command.Name, command.Email, phoneNumber, command.TouristPackageId, command.Traveldate);

        _reservationRepository.Add(reservation);

        await _unitofwork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}