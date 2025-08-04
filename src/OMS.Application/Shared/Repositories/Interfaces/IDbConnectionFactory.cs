using System.Data;

namespace OMS.Application.Shared.Repositories.Interfaces;

public interface IDbConnectionFactory
{
    IDbContext GetDbContext();

    IDbConnection GetOpenConnection();
}