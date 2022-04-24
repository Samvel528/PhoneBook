using PhoneBookApp.Models;
using System.Collections.Generic;

namespace PhoneBookApp
{
    public interface IFileRepository
    {
        List<Contact> GetContacts();
    }
}
