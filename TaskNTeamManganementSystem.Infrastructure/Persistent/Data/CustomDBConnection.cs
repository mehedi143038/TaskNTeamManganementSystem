using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNTeamManganementSystem.Application.Interfaces;

namespace TaskNTeamManganementSystem.Infrastructure.Persistent.Data
{
    public class CustomDBConnection : ICustomDBConnection
    {
        public IDbConnection CreateConnection()
        {
            var connStr = DBConnectionString.GetConnectionString()
                ?? throw new InvalidOperationException("Missing connection string!");
            return new SqlConnection(connStr);
        }
    }
}
