using System;
using System.Collections.Generic;
using System.Linq;
using MarathonSkills2016.Models;
using Metsys.Bson;

namespace MarathonSkills2016;

public class TimerMarafon
{
    public string Timer1()
    {
        System.TimeSpan timeq = 
            new DateTime(2015, 09, 06, 07, 00, 00) - DateTime.Now;
        string Timerstart = $"{timeq.Days} дней {timeq.Hours} часов {timeq.Minutes} минут до старта марафона!";
        return Timerstart;
    }
}