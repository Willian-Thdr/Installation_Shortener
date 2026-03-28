using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

public class DependsError : Window
{
    public DependsError(string title, string mensage)
    {
        Title = title;
        Width = 700;
        Height = 700;

        var canvas = new Canvas
        {
            Width = 700,
            Height = 700
        };

        var textBox = new TextBox
        {
            Text = mensage,
            Foreground = Brushes.Red,
            Background = Brushes.Black
        };

        var buttonOpt1 = new Button
        {
            Content = "Aceitar",
            Foreground = Brushes.White,
            BorderBrush = Brushes.White,
            BorderThickness = new Avalonia.Thickness(2)
        };
        buttonOpt1.Click += Confirmate;

        var buttonOpt2 = new Button
        {
            Content = "Negar",
            Foreground = Brushes.Red,
            BorderBrush = Brushes.White,
            BorderThickness = new Avalonia.Thickness(2)
        };


    }

    public void Confirmate(object? sender, RoutedEventArgs e)
    {
        
    }

    public void Dimiss(object? sender, RoutedEventArgs e)
    {
        
    }
}