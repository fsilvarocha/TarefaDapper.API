using System.Data;
using System.Data.SqlClient;

namespace TarefaDapper.API.Data;

public class DbSession : IDisposable
{
    public IDbConnection Connection { get; }

    public IDbTransaction Transaction { get; }

    public DbSession(IConfiguration configuration)
    {
        Connection = new SqlConnection(configuration.GetConnectionString("SqlServerConnection"));
        Connection.Open();
    }

    public void Dispose()=>Connection?.Dispose();
}
