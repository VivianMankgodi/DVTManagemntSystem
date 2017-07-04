using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVT.DataAccess;
namespace DVT.ManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
           DataAccess.DataAccesses.DataAccess da = new DataAccess.DataAccesses.DataAccess();
           da.insertProfile("lee", "lee", "kfg@hgd", "hghg", true, 1,1,2);


            da.InsertAddresses(120, "hello", "012", "kk", 1, 1, 2);
                }
    }
}
