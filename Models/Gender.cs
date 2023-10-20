using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Gender
{
    public string Gender1 { get; set; } = null!;

    public virtual ICollection<Runner> Runners { get; set; } = new List<Runner>();

    public virtual ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
}
