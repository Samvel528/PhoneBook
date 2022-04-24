using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneBookApp.Views
{
    public class ConsoleView : IView
    {
        private readonly IContactValidator _contactValidator;

        public ConsoleView(IContactValidator contactValidator)
        {
            _contactValidator = contactValidator;
        }

        public event EventHandler OnLoad;
        public event EventHandler<RequestContactsEventArgs> OnRequestContacts;

        public void Clear()
        {
            Console.Clear();
        }

        public string GetFilePath()
        {
            Console.Write("File path - ");
            
            return Path.Combine(Directory.GetCurrentDirectory(), "Files", Console.ReadLine());
        }

        public void ShowContacts(List<Contact> contacts)
        {
            Clear();
            Console.WriteLine("File Structure:");

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Name} {contact.Surname} {contact.Separator} {contact.PhoneNumber}");
            }

            Console.WriteLine();

            for (int i = 0; i < contacts.Count; i++)
            {
                var message = _contactValidator.Validate(contacts[i]);

                if (message != string.Empty)
                {
                    Console.WriteLine($"line{i + 1}: {message}");
                }
            }
        }

        public void Start()
        {
            OnLoad?.Invoke(this, EventArgs.Empty);

            Console.WriteLine();
            Console.Write("Please choose criteria: “Name”, “Surname” or “PhoneNumberCode” - ");
            var sortProperty = Console.ReadLine();
            var contactType = typeof(Contact);
            Console.Write("Please choose an ordering to sort: “Ascending” or “Descending” - ");
            string value = Console.ReadLine();
            bool ascending = true
                ? value == "Ascending"
                : false;

            OnRequestContacts(this, new RequestContactsEventArgs(c => contactType.GetProperty(sortProperty).GetValue(c), ascending));
        }
    }
}
