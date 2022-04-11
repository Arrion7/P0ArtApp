namespace DL;

public class DbRepository : IRepository
{
    public readonly string ConnectionString;
    public DbRepository(string connectionString)
    {
        this.ConnectionString = connectionString;
    }
}