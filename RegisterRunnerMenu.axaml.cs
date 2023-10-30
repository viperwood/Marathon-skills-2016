using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using MarathonSkills2016.Models;

namespace MarathonSkills2016;

public partial class RegisterRunnerMenu : Window
{
    public Runner _runner;
    
    private DispatcherTimer _timer = new DispatcherTimer();
    public RegisterRunnerMenu()
    {
        _runner = new Runner();
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

    private readonly FileDialogFilter filefilter = new FileDialogFilter()
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
        //Открытие диологового окна
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filters?.Add(filefilter);
        string[]? result = await dialog.ShowAsync(this);
        //Если выбранный файл есть
        if (result != null)
        {
            //Создаем путь к файлу Images в папке дерриктории
            string combinFileName = Path.Combine(Directory.GetCurrentDirectory(), "Images\\");
            //Убираем из пути не нужную часть
            combinFileName = combinFileName.Replace("bin\\Debug\\net7.0\\","");
            //Берем имя выбранного файла
            string imageName = Path.GetFileName(result[0]);
            //Создаем путь для картинки в папке дерриктории
            string lastFilePath = Path.Combine(combinFileName, imageName);
            //Копирует файла в папку
            File.Copy(result[0],lastFilePath,true);
            //Перевод картинки в Avalonia ресурс и вывод ее за место текста
            using(var  memoryStream = new FileStream(result[0] , FileMode.Open))
            {
                Bitmap bit = new Bitmap(memoryStream);
                PhotoText.IsVisible = false;
                ImageServise.Source = bit;
            }

            _path.Text = imageName;
            _runner.Imagerunner = $"Images\\{imageName}";
        }
    }

    private void SaveButton(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_email.Text != null && _email.Text != "")
        {
            _emailchack.Text = "";
            if (_password.Text != null && _password.Text != "")
            {
                _passwordchack.Text = "";
                if (_password2.Text != null && _password2.Text != "")
                {
                    _passwordchack2.Text = "";
            
                }
                else
                {
                    _passwordchack2.Text = "Все поля обязательны";
                }
            }
            else
            {
                _passwordchack.Text = "Все поля обязательны";
            }
        }
        else
        {
            _emailchack.Text = "Все поля обязательны";
        }
        
        
        
        
        
        
        //Подгрузка в базу данных
        Helper.Database.Add(_runner);
        //Сохранение базы данных
        Helper.Database.SaveChanges();
        //Закрыть
        Close();
    }
}