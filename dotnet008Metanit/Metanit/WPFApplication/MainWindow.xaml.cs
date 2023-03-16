using System.Windows;

namespace WPFApplication;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        if(textBox1.Text != "")
        {
            MessageBox.Show(textBox1.Text);
        }
    }

}
