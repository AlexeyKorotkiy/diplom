using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM_00.Database;

namespace ORM_00.Classes
{
    public static class DBClass
    {
        public static readonly EmszhmtwContext db = new EmszhmtwContext();
    }
}
