using Task;

Console.WriteLine("Hello, World!");

PasswordFileReader passwordFileReader = new("passwords.txt");
int counter = passwordFileReader.CountValidPasswords();
Console.WriteLine(counter);