using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MarathonSkills2016.Models;

namespace MarathonSkills2016;

public partial class SponsorARunnerInfo : Window
{
    public SponsorARunnerInfo()
    {
        InitializeComponent();
    }
    public SponsorARunnerInfo(int contextComboBoxId)
    {
        InitializeComponent();
        List<Runnerinf> runnerinfs = Helper.Database.Runnerinfs.ToList();
        NameFond.Text = runnerinfs[contextComboBoxId].Charityname;
        Description.Text = runnerinfs[contextComboBoxId].Charitydescription;
    }
}