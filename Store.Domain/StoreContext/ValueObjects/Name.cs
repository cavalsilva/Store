using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "The first name must contain at least 3 characters")
                .HasMaxLen(FirstName, 40, "FirstName", "The first name must contain a maximum of 40 characters")
                .HasMinLen(LastName, 3, "LastName", "The last name must contain at least 3 characters")
                .HasMaxLen(LastName, 40, "LastName", "The last name must contain a maximum of 40 characters")
            );

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}