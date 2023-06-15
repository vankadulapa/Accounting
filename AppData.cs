using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models

{
    static public class AppData
    {
        static public AccountingEntities db = new AccountingEntities();
        static public int CurrentAccessLevel = 0;
    }
}
