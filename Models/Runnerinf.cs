using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Runnerinf
{
    public int? Runnerid { get; set; }

    public string? Email { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public short? Bibnumber { get; set; }

    public string? Sponsorname { get; set; }

    public string? Gender { get; set; }

    public string? Countrycode { get; set; }
    
    public string Fundname { get; set; } = null!;

    public string? Funddescription { get; set; }
}
