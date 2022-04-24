using PhoneBookApp.Models;

namespace PhoneBookApp
{
    public interface IContactValidator
    {
        string Validate(Contact contact);
    }
}
