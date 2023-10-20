using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Registrationstatus
{
    public short Registrationstatusid { get; set; }

    public string Registrationstatus1 { get; set; } = null!;

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
