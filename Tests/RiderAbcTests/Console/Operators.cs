﻿namespace Console;

public class MyClass
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Operators
{
    public static void Tests()
    {
        MyClass myObj = new()
        {
            Id = 1,
            Name = "MyName"
        };
        
        System.Console.WriteLine("----------");
        System.Console.WriteLine(myObj is MyClass);
        System.Console.WriteLine("----------");
        
    }
}