﻿using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Exceptions;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

namespace GoogleSheetsTelegramBot;

internal static class Program
{
    private static readonly string TgToken = "YOUR_TELEGRAM_BOT_TOKEN";

    private static void Main(string[] args)
    {
        GoogleSheetTest();
        TelegramBotTest();
    }

    private static void TelegramBotTest()
    {
        TelegramBotClient botClient = new(TgToken);
        CancellationTokenSource cts = new();

        // Start receiving updates
        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = [] // receive all update types
        };

        botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            cts.Token
        );

        Console.WriteLine("Running... Press Enter to terminate");
        Console.ReadLine();
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type != UpdateType.Message || update.Message!.Type != MessageType.Text)
            return;

        string? messageText = update.Message.Text;
        long chatId = update.Message.Chat.Id;
        string chatTitle = update.Message.Chat.Title ?? "Личная переписка";
        
        HandleData();

        Console.WriteLine($"Получено сообщение из чата '{chatTitle}' (ID: {chatId}): {messageText}");

        if (messageText != null && Regex.IsMatch(messageText, @"\d"))
        {
            Console.WriteLine($"Сообщение, содержащее цифры: {messageText}");
        }

        // Echo the received message back to the user
        await botClient.SendTextMessageAsync(chatId, $"Вы сказали: {messageText}", cancellationToken: cancellationToken);
    }

    private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        string errorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }

    private static void HandleData()
    {
        Console.WriteLine("Start handling data...");
        Thread.Sleep(5000);
        Console.WriteLine("Data handled!");
    }
    
    
    
    private static readonly string[] Scopes = [SheetsService.Scope.Spreadsheets];
    private const string ApplicationName = "Google Sheets API .NET Quickstart";
    
    // GoogleSheetsTelegramBot
    // private const string SpreadsheetId = "1m92Mr5_XkD6GQ7q04uYKPYXcjSnI3ncjj6luuMo1SHc";
    // private const string SheetName = "Sheet1";
    
    // Copy of Журнал дзвінків на 2024 рік 
    private const string SpreadsheetId = "1E53bygPrEP_57mx_zVEFnGUr26Aou9_NCOHV7X9MBfA";
    private const string SheetName = "Лист32";
    private static SheetsService? _service;

    private static void GoogleSheetTest()
    {
        GoogleCredential credential;

        // Загрузка учетных данных сервисного аккаунта
        using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
        }

        // Создание службы Google Sheets API
        _service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });

        // Запись данных в Google Sheets
        WriteToSheet("Hello World");
    }

    private static void WriteToSheet(string value)
    {
        const string range = $"{SheetName}!E1";
        
        ValueRange valueRange = new ()
        {
            Values = new List<IList<object>> { new List<object> { value } }
        };

        UpdateRequest? updateRequest = _service?.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);

        if (updateRequest != null)
        {
            updateRequest.ValueInputOption = UpdateRequest.ValueInputOptionEnum.RAW;
            updateRequest.Execute();
        }

        Console.WriteLine("Updated cell E1 with 'Hello World'");
    }
            
    // Для работы с Google Sheets API вам нужно использовать учетные данные сервисного аккаунта. 
    //     Вот шаги для создания и использования учетных данных сервисного аккаунта:
    //
    // Создайте учетные данные сервисного аккаунта
    //     Перейдите в Google Cloud Console.
    //     Выберите ваш проект или создайте новый.
    //     Перейдите в раздел "API & Services" > "Credentials".
    //     Нажмите "Create credentials" и выберите "Service account".
    //     Заполните необходимые поля и нажмите "Create".
    //     На следующем шаге выберите роль "Editor" или "Owner" и нажмите "Continue".
    //     Нажмите "Done".
    //     В разделе "Service accounts" найдите созданный аккаунт и нажмите на кнопку "Manage keys".
    //     Нажмите "Add key" > "Create new key" и выберите формат JSON.
    //     Скачайте файл JSON и сохраните его в вашем проекте (например, service_account.json).
    //     Шаг 2: Обновите ваш код для использования учетных данных сервисного аккаунта
    //
    //     Предоставьте доступ сервисному аккаунту к таблице Google Sheets:
    //
    // Откройте таблицу Google Sheets в браузере.
    //     Нажмите на кнопку "Поделиться" (Share) в правом верхнем углу.
    //     Введите email сервисного аккаунта (например, gsapi2@graphical-balm-433408-i1.iam.gserviceaccount.com) в поле "Добавить людей и группы" (Add people and groups).
    //     Выберите роль "Редактор" (Editor) и нажмите "Отправить" (Send).
    //     Убедитесь, что ваш код корректен:
    //
    // Проверьте, что ваш код использует правильные учетные данные и имеет доступ к таблице.
}