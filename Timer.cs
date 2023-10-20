using System;
using System.Collections.Generic;
using System.Linq;
using MarathonSkills2016.Models;
using Metsys.Bson;

namespace MarathonSkills2016;

public class Timer
{
    static int day = 18;
    static int hour = 8;
    static int minutes = 17;

    private DateTime time = DateTime.Now;

    DateTime datet = new DateTime(2015,09 , 06, 07, 00, 00);
    
    
    public static string Timerstart = $"{day} дней {hour} часов {minutes} минут до старта марафона!";
}