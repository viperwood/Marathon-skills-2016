using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using MarathonSkills2016.Models;

namespace MarathonSkills2016;

public partial class ListOfCharities : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    public ListOfCharities()
    {
        InitializeComponent();
        _timer.Interval = TimeSpan.FromSeconds(0);
        _timer.Tick += TimerTick;
        _timer.Start();
        ListFond();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }

    private void ListFond()
    {
        List<Charity> charities = Helper.Database.Charities.ToList();
        ListBoxFond.Items = charities.Select(x => new
        {
            NameFond = x.Charityname,
            DescriptionFond = x.Charitydescription
        }).ToList();
    }

    private void Beack(object? sender, RoutedEventArgs e)
    {
        FindOutMoreInformation findOutMoreInformation = new FindOutMoreInformation();
        findOutMoreInformation.Show();
        Close();
    }
}