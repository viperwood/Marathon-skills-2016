using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Charityfoundation
{
    public int Fundid { get; set; }

    public string Fundname { get; set; } = null!;

    public string? Funddescription { get; set; }

    public virtual ICollection<Sponsorship> Sponsorships { get; set; } = new List<Sponsorship>();
}
