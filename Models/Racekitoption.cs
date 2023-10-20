using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Racekitoption
{
    public char Racekitoptionid { get; set; }

    public string Racekitoption1 { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
