using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
namespace Models
{
    public static class Connection
    {
        //setup database here
        public const string DATABASE_NAME = "finance_manager";

        public static MySQL GetNewInstance()
        {
            return new MySQL(DATABASE_NAME);
        }
    }
}
