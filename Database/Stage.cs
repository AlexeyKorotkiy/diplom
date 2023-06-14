using System;
using System.Collections.Generic;

namespace ORM_00.Database;

public partial class Stage
{
    public int Idstage { get; set; }

    public int? Idokp { get; set; }

    public double? Numberstage { get; set; }

    public string? Stagename { get; set; }

    public int? Numberofproducts { get; set; }

    public DateOnly? Startday { get; set; }

    public DateOnly? Endday { get; set; }

    public virtual ICollection<Documentaccordingtogost> Documentaccordingtogosts { get; set; } = new List<Documentaccordingtogost>();

    public virtual ICollection<Documentsduringstage> Documentsduringstages { get; set; } = new List<Documentsduringstage>();

    public virtual ICollection<Finaldocument> Finaldocuments { get; set; } = new List<Finaldocument>();

    public virtual Okp? IdokpNavigation { get; set; }
}
