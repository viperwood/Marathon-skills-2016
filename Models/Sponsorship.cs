using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Sponsorship
{
    public int Sponsorshipid { get; set; }

    public string Sponsorname { get; set; } = null!;

    public int Registrationid { get; set; }

    public decimal Amount { get; set; }

    public int? Fundid { get; set; }

    public virtual Charityfoundation? Fund { get; set; }

    public virtual Registration Registration { get; set; } = null!;
}
