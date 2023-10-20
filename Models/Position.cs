using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Position
{
    public int Positionid { get; set; }

    public string? Positionname { get; set; }

    public string? Positiondescription { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
