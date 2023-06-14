using System;
using System.Collections.Generic;

namespace ORM_00.Database;

public partial class Documentaccordingtogost
{
    public int Iddocument { get; set; }

    public int? Idstage { get; set; }

    public int? Regulatorygost { get; set; }

    public byte[]? Documents { get; set; }

    public virtual Gostform IddocumentNavigation { get; set; } = null!;

    public virtual Stage? IdstageNavigation { get; set; }
}
