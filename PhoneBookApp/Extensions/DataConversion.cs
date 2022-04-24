using PhoneBookApp.Models;
using System;

namespace PhoneBookApp.Extensions
{
    public static class DataConversion
    {
        public static Contact ToContact(this string value)
        {
            Contact contact = new Contact();
            var components = value.Split(' ');
            if (components.Length == 3)
            {
                contact.Separator = Convert.ToChar(components[1].Trim());
                contact.PhoneNumber = components[2].Trim();
            }
            else
            {
                contact.Surname = components[1].Trim();
                contact.Separator = Convert.ToChar(components[2].Trim());
                contact.PhoneNumber = components[3].Trim();
            }
             
            contact.Name = components[0].Trim();
            contact.PhoneNumberCode = contact.PhoneNumber.Substring(0, 3);

            return contact;
        }
    }
}
