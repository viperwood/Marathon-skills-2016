using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Schedule
{
    public int Schedulesid { get; set; }

    public string? Schedulesname { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
