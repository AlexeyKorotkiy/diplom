using ORM_00.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_00.Classes
{
    internal class OKRClass
    {
        public string IdOKR { get; set; }

        public string? Title { get; set; }

        public string? NameComp { get; set; }

        public string? RegulatoryDoc { get; set; }
        public string? StackPanelColor { get; set; }

        public virtual ICollection<Stage> Stages { get; set; } = new List<Stage>();
    }
}
