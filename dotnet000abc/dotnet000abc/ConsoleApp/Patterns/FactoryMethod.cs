namespace ConsoleApp.Patterns;

public static class FactoryMethod
{
    public static void Test()
    {
        Application app = new("Web");
    }
}

internal interface IButton
{
    void Render();
    void OnClick();
}

internal class WindowsButton : IButton
{
    public void Render() { Console.WriteLine("Windows Button Rendered!"); }
    public void OnClick() { Console.WriteLine("Windows Button Clicked!"); }
}

internal class WebButton : IButton
{
    public void Render() { Console.WriteLine("Web Button Rendered!"); }
    public void OnClick() { Console.WriteLine("Web Button Clicked!"); }
}

internal interface IDialog
{
    IButton CreateButton();
}

internal class WindowsDialog : IDialog
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }
}

internal class WebDialog : IDialog
{
    public IButton CreateButton()
    {
        return new WebButton();
    }
}

internal class Application
{
    private readonly IDialog _dialog;
    
    public Application(string system)
    {
        switch (system)
        {
            case "Windows":
                _dialog = new WindowsDialog();
                break;
            case "Web":
                _dialog = new WebDialog();
                break;
            default:
                Console.WriteLine("Unknown Operating System!");
                Environment.Exit(1);
                break;
        }
        
        IButton button = _dialog.CreateButton();
        button.OnClick();
    }
}