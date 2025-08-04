using OMS.Application.Shared.Repositories.Interfaces;
using OMS.Application.Shared.Settings;
using System.Data;

namespace OMS.Persistence.Shared;

public class DbConnectionFactory : IDbConnectionFactory
{
    public DbConnectionFactory(IAppSettings appSettings)
    {
    }

    public IDbContext GetDbContext()
    {
        throw new NotImplementedException();
    }

    public IDbConnection GetOpenConnection()
    {
        throw new NotImplementedException();
    }
}