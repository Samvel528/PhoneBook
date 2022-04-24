using PhoneBookApp.Models;
using System.Collections.Generic;
using System.IO;
using PhoneBookApp.Extensions;

namespace PhoneBookApp.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly string _filePath;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
            string line = "";
            
            using (StreamReader reader = new StreamReader(_filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    contacts.Add(DataConversion.ToContact(line));
                }
                
                reader.Close();
            }

            return contacts;
        }
    }
}
