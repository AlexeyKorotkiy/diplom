using System;
using System.Collections.Generic;

namespace ORM_00.Database;

public partial class Okp
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Namecomponent { get; set; }

    public string? Regulatorydocument { get; set; }

    public virtual ICollection<Stage> Stages { get; set; } = new List<Stage>();
}
