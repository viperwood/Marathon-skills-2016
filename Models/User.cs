using System;
using System.Collections.Generic;

namespace MarathonSkills2016.Models;

public partial class User
{
    public string? Email { get; set; } = null!;

    public string? Password { get; set; } = null!;

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public char Roleid { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Runner> Runners { get; set; } = new List<Runner>();
}
