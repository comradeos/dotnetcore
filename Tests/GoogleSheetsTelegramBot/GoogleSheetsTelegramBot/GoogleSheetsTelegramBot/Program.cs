using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;

namespace GoogleSheetsTelegramBot;

public static class Program
{
    static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
    static readonly string ApplicationName = "Google Sheets API .NET Quickstart";
    static readonly string SpreadsheetId = "1vkTdABlZA_r1aKM92BScmWfH2hD0B0mhCSlH73ejMSo";
    static readonly string SheetName = "Sheet1";
    static SheetsService service;

    static void Main(string[] args)
    {
        GoogleCredential credential;
        
        // Загрузка учетных данных
        using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream)
                .CreateScoped(Scopes);
        }

        // Создание службы Google Sheets API
        service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });

        ReadEntries();
        WriteEntries();
    }

    static void ReadEntries()
    {
        var range = $"{SheetName}!A1:D5"; // Указываем диапазон данных для чтения
        SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(SpreadsheetId, range);

        ValueRange response = request.Execute();
        IList<IList<object>> values = response.Values;

        if (values != null && values.Count > 0)
        {
            foreach (var row in values)
            {
                Console.WriteLine(string.Join(", ", row)); // Вывод строк из таблицы
            }
        }
        else
        {
            Console.WriteLine("Нет данных.");
        }
    }

    static void WriteEntries()
    {
        var range = $"{SheetName}!A1"; // Указываем ячейку, с которой начнем запись
        var valueRange = new ValueRange();

        // Создаем данные для записи
        var oblist = new List<IList<object>> { new List<object>() { "Hello", "World" } };
        valueRange.Values = oblist;

        var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
        appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        var appendResponse = appendRequest.Execute();
    }
}
