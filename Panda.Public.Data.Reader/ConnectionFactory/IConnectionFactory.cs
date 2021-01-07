using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Panda.Public.Data.Reader
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
        void CloseConnection();
    }
}
