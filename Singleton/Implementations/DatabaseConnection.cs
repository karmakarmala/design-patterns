namespace Singleton;
using System.Data.SqlClient;

public sealed class DatabaseConnection
{
    private static readonly Lazy<DatabaseConnection> LazyDbConnection =
        new Lazy<DatabaseConnection>(() => new DatabaseConnection());
    
    public static DatabaseConnection Instance => LazyDbConnection.Value;

    private SqlConnection _connection;
    
    private DatabaseConnection()
    {
        _connection = new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
    }
    
    public SqlConnection GetConnection()
    {
        return _connection;
    }
}