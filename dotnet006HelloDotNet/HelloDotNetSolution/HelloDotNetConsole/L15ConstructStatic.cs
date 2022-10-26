﻿namespace HelloDotNetConsole;

public class Robot {
    private string _name;
    private int _weight;
    private int[] _coordinates;

    public Robot(string name, int weight, int[] coordinates) {
        _name = name;
        _weight = weight;
        _coordinates = coordinates;
    }

    public void SetValues(string newName, int newWeight, int[] newCoordinates) {
        _name = newName;
        _weight = newWeight;
        _coordinates = newCoordinates;
    }

    public void PrintValues() {
        Console.WriteLine("Robot Info:");
        Console.WriteLine("Name: " + _name);
        Console.WriteLine("Weight: " + _weight + "kg.");
        Console.WriteLine("Current coordinates:");
        foreach (var i in _coordinates) {
            Console.Write(i + ", ");
        }
    }
}

public static class L15ConstructStatic {
    public static void Run() {
        var bot = new Robot("B1", 512, new[] { 42, 12, 52, });
        bot.PrintValues();
    }
}