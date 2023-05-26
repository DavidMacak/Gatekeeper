using GatekeeperLib.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatekeeperLib.Data
{
    /// <summary>
    /// Aplikace volá tyto metody. Ty obsahují vyplněné parametry a
    /// dále volají metody z SqlDataAccess
    /// </summary>
    public class SqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }




    }
}
