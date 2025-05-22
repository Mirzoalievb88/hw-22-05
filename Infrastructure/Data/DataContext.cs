using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
    private const string connectionString = "Server=localhost;Database=CRM;User Id=postgres;Password=12345;";

    public Task<NpgsqlConnection> GetConnectionAsync()
    {
        return Task.FromResult(new NpgsqlConnection(connectionString));
    }
}