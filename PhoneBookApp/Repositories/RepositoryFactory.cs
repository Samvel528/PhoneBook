namespace PhoneBookApp.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IFileRepository GetRepository(string filePath)
        {
            return new FileRepository(filePath);
        }
    }
}
