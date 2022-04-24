using PhoneBookApp.Models;

namespace PhoneBookApp.Validators
{
    public class ContactValidator : IContactValidator
    {
        public string Validate(Contact contact)
        {
            string message = string.Empty;

            if (contact.PhoneNumber.Length != 9 && contact.Separator != ':' && contact.Separator != '-')
            {
                message += "phone number should be with 9 digits, the separator should be `:` or `-`.";
            }
            else if (contact.PhoneNumber.Length != 9)
            {
                message += "phone number should be 9 digits.";
            }

            return message;
        }
    }
}
