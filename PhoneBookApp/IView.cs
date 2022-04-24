using PhoneBookApp.Models;
using System;
using System.Collections.Generic;

namespace PhoneBookApp
{
    public interface IView
    {
        void ShowContacts(List<Contact> contacts);
        void Start();
        event EventHandler OnLoad;
        event EventHandler<RequestContactsEventArgs> OnRequestContacts;
        string GetFilePath();
        void Clear();
    }

    public class RequestContactsEventArgs : EventArgs
    {
        public RequestContactsEventArgs(Func<Contact, object> sortBy, bool ascending = true)
        {
            SortBy = sortBy;
            Ascending = ascending;
        }

        public Func<Contact, object> SortBy { get; }

        public bool Ascending { get; }
    }
}
