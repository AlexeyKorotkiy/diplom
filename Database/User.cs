using System;
using System.Collections.Generic;

namespace ORM_00.Database;

public partial class User
{
    public int Iduser { get; set; }

    public int Idrole { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateOnly? Dataregistory { get; set; }

    public string Userlogin { get; set; } = null!;

    public string Userpassword { get; set; } = null!;
}
