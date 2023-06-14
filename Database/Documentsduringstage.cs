using System;
using System.Collections.Generic;

namespace ORM_00.Database;

public partial class Documentsduringstage
{
    public int Iddocument { get; set; }

    public int Idstage { get; set; }

    public string Regulatorygost { get; set; } = null!;

    public byte[] Documents { get; set; } = null!;

    public string Formatdocument { get; set; } = null!;

    public virtual Stage IdstageNavigation { get; set; } = null!;
}
