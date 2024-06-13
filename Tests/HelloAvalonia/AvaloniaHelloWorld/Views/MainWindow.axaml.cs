using System; // Add this line
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaHelloWorld.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    public void NewButton_Click(object sender, RoutedEventArgs e)
    {
        Console.WriteLine("From New Button");
    }
}