using PhoneBookApp.Repositories;

namespace PhoneBookApp
{
    public interface IRepositoryFactory
    {
        IFileRepository GetRepository(string filePath);
    }
}
