using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Utils.Db
{
    public static class DbCommandEx
    {
        public static void Liberar(this DbCommand pCommand)
        {
            pCommand.Connection.Close();
            pCommand.Dispose();
        }
    }
}
