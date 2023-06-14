using ORM_00.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_00.Classes
{
    internal class Dockclass
    {
        public int Iddocuments { get; set; }

        public int Idstages { get; set; }

        public string? Regulatorygosts { get; set; }

        public string Formatdocument { get; set; }

        public byte[]? Documentss { get; set; }
    }
}
