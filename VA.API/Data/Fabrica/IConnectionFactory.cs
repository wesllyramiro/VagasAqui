using System.Data;

namespace VA.API.Data.Fabrica
{
    public interface IConnectionFactory
    {
        IDbConnection CreateSqlConnectionOpened();
    }
}
