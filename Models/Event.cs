using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class Event
{
    public string Eventid { get; set; } = null!;

    public string Eventname { get; set; } = null!;

    public string Eventtypeid { get; set; } = null!;

    public short Marathonid { get; set; }

    public DateTime? Starttimestamp { get; set; }

    public decimal? Cost { get; set; }

    public short? Maxparticipants { get; set; }

    public virtual Eventtype Eventtype { get; set; } = null!;

    public virtual Marathon Marathon { get; set; } = null!;

    public virtual ICollection<Registrationevent> Registrationevents { get; set; } = new List<Registrationevent>();
}
