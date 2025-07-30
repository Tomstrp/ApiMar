using System;
using System.Collections.Generic;

namespace ApiMar.Models;

public partial class utenteruolo
{
    public int id { get; set; }

    public string username { get; set; } = null!;

    public int ruoloid { get; set; }

    //public virtual ruolo ruolo { get; set; } = null!;
}
