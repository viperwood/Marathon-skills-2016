using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Myresult
{
    public string? Eventid { get; set; }

    public string? Eventtypename { get; set; }

    public DateTime? Registrationtimestamp { get; set; }

    public short? Bibnumber { get; set; }

    public string? Eventname { get; set; }

    public DateTime? Dateofbirth { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public int? Racetime { get; set; }
}
