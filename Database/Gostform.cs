using System;
using System.Collections.Generic;

namespace ORM_00.Database;

public partial class Gostform
{
    public int Idgostform { get; set; }

    public int? Idstage { get; set; }

    public string? Formdocument { get; set; }

    public virtual Documentaccordingtogost? Documentaccordingtogost { get; set; }

    public virtual Finaldocument? Finaldocument { get; set; }
}
