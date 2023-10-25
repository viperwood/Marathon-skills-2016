namespace MarathonSkills2016.Models;

public partial class Runnerinf
{
    public int Runnerid { get; set; }

    public string Email { get; set; } = null!;
    
    public string? Firstname { get; set; }

    public string? Lastname { get; set; }
    
    public string Gender { get; set; } = null!;
    
    public short? Bibnumber { get; set; }
    
    public string Countrycode { get; set; } = null!;
    
    public string Sponsorname { get; set; } = null!;
}