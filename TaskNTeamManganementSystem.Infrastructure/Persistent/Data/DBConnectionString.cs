using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNTeamManganementSystem.Infrastructure.Persistent.Data
{
    public class DBConnectionString
    {
        private readonly string _connectionString;
        public DBConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
        public static string GetConnectionString()
        {            
            var ConnectionString = "Server=DESKTOP-ATOEHED;Database=TaskNTeamManagementSystem;Integrated Security=True;TrustServerCertificate=True;";
            return ConnectionString;
        }
    }
}
