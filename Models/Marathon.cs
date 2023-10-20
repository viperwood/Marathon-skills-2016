using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Marathon
{
    public short Marathonid { get; set; }

    public string Marathonname { get; set; } = null!;

    public string? Cityname { get; set; }

    public string Countrycode { get; set; } = null!;

    public short? Yearheld { get; set; }

    public virtual Country CountrycodeNavigation { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
