using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Threading;

namespace MarathonSkills2016;

public partial class RegisterRunnerMenu : Window
{
    private DispatcherTimer _timer = new DispatcherTimer();
    public RegisterRunnerMenu()
    {
        InitializeComponent();
        _timer.Interval = TimeSpan.FromSeconds(0);
        _timer.Tick += TimerTick;
        _timer.Start();
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        TimerMarafon timerMarafon = new TimerMarafon();
        Timers.Text = timerMarafon.Timer1();
    }

    /*private readonly FileDialogFilter filefilter = new FileDialogFilter()
    {
        Extensions = new List<string>()
        {
            "png",
            "jpg",
            "jpeg"
        }
    };
    
    
    
    
    
    private async void SelectFileButton_Click(object? sender, RoutedEventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filters?.Add(filefilter);
        string[]? result = await dialog.ShowAsync(this);
        if (result == null)
        {
            return;
        }

        string combinFileName = Path.Combine(Directory.GetCurrentDirectory(), "ServiceSchools\\");
        
        combinFileName = combinFileName.Replace("bin\\Debug\\net7.0\\","");
        
        string imageName = Path.GetFileName(result[0]);
        
        string lastFilePath = Path.Combine(combinFileName, imageName);
        
        File.Copy(result[0],lastFilePath,true);
        

        
        
        
        
        
        
        
        
    }*/
    
    
    

    /*private async void ImageButton(object? sender, RoutedEventArgs e)
    {
        OpenFileDialog fileDialog = new OpenFileDialog();
        fileDialog.Filters?.Add(filefilter);


        string[]? result = await fileDialog.ShowAsync(this);
        if (result == null) return;
    }*/
}