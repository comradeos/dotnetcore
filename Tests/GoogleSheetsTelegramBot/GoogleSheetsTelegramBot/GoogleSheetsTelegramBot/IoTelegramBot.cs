using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Exceptions;

namespace GoogleSheetsTelegramBot;

public class IoTelegramBot
{
    private static readonly string TgToken = "";

    private static void TelegramBotTest()
    {
        TelegramBotClient botClient = new(TgToken);
        CancellationTokenSource cts = new();
        
        botClient.SendTextMessageAsync(
            chatId: 1002209585239,
            text: "hey!", 
            cancellationToken: cts.Token
        );

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
        // Thread.Sleep(5000);
        Console.WriteLine("Data handled!");
    }
    
    private static void TelegramSingleMessage()
    {
        TelegramBotClient botClient = new(TgToken);
        CancellationTokenSource cts = new();
        
        try
        {
            var message = botClient.SendTextMessageAsync(
                chatId: -1002209585239,
                text: "hey223!",
                cancellationToken: cts.Token
            ).GetAwaiter().GetResult();

            Console.WriteLine($"Message sent: {message.Text}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
        Console.WriteLine("done");
    }
    
}