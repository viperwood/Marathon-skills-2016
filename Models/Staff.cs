using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Staff
{
    public int Staffid { get; set; }

    public string? Fullname { get; set; }

    public DateTime? Dateofbirth { get; set; }

    public string Gender { get; set; } = null!;

    public int Positionid { get; set; }

    public DateTime? Payperiod { get; set; }

    public int? Schedulesid { get; set; }

    public string? Emailaddress { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual Schedule? Schedules { get; set; }
}
