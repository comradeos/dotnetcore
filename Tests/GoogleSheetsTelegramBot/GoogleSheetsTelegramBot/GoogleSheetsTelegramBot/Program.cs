﻿namespace GoogleSheetsTelegramBot;

internal static class Program
{
    

    private static void Main(string[] args)
    {
        IoGoogleSheets gs = new();
        gs.Test();
        
        IoTelegramBot tg = new();
        // tg.Test();
        
        
        // WriteRandom();
        // TelegramBotTest();
    }

    
}



