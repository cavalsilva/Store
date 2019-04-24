using FluentValidator;
using FluentValidator.Validation;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Fail Fast Validations
        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "The first name must contain at least 3 characters")
                .HasMaxLen(FirstName, 40, "FirstName", "The first name must contain a maximum of 40 characters")
                .HasMinLen(LastName, 3, "LastName", "The last name must contain at least 3 characters")
                .HasMaxLen(LastName, 40, "LastName", "The last name must contain a maximum of 40 characters")
                .IsEmail(Email, "Email", "The e-mail is invalid")
                .HasLen(Document, 11, "Document", "CPF is invalid")
            );
            return IsValid;
        }
    }
}