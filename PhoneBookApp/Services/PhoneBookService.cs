using PhoneBookApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookApp.Services
{
    public class PhoneBookService : IService
    {
        private IFileRepository _fileRepository;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IView _view;

        public PhoneBookService(IRepositoryFactory repositoryFactory, IView view)
        {
            _repositoryFactory = repositoryFactory;
            _view = view;

            _view.OnLoad += _view_OnLoad;
            _view.OnRequestContacts += _view_OnRequestContacts;
        }

        private void _view_OnRequestContacts(object sender, RequestContactsEventArgs e)
        {
            var contacts = e.Ascending
                ? GetContacts().OrderBy(e.SortBy)
                : GetContacts().OrderByDescending(e.SortBy);

            _view.ShowContacts(contacts.ToList());
        }

        private void _view_OnLoad(object sender, System.EventArgs e)
        {
            var path = _view.GetFilePath();
            _fileRepository = _repositoryFactory.GetRepository(path);
        }

        public void Start()
        {
            _view.Start();
        }

        private List<Contact> GetContacts()
        {
            return _fileRepository.GetContacts();
        }
    }
}
