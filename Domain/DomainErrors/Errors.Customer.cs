using ErrorOr;

namespace Domain.DomainErrors;

public static partial class Errors
{
    public static class Customer
    {
        public static Error PhoneNumberWhitBadFormat =>
            Error.Validation("Customer.PhoneNumber", " is not a valid phone number");

        public static Error AddressWhitBadFormat =>
            Error.Validation("Customer.Address", " is not a valid address");
    }
}