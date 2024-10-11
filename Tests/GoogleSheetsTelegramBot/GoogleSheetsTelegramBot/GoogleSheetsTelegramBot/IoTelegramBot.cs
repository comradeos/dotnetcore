using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Exceptions;

namespace GoogleSheetsTelegramBot;

public class IoTelegramBot
{
    public readonly string TgToken = "7447477377:AAGXpaUY4vbZaelgqF9ssr0sWy2MC_2dsQ8";
    // public readonly string TgToken = "SECRET_API_TOKEN";

    // группы и исполнители
    private Dictionary<long, List<string>> _groupPerformers = new()
    {
        {-4590477055, ["Нагорний"] },
        {-4535485804, ["Моісеєнко"] },
        {-4594391063, ["Поляков"] },
    };
    private const long CallCenterChatId = -4504928640;
    // группы и исполнители
    
    private readonly TelegramBotClient _botClient;
    private readonly CancellationTokenSource _cancellation = new();
    
    public IoTelegramBot()
    {
        _botClient = new TelegramBotClient(TgToken);
    }
    
    public void Test()
    {
        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = []
        };

        _botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            _cancellation.Token
        );

        Console.WriteLine("Running... Press Enter to terminate");
        Console.ReadLine();
    }

    private Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type != UpdateType.Message || update.Message!.Type != MessageType.Text)
        {
            return Task.CompletedTask;
        }

        string? messageText = update.Message.Text;
        long chatId = update.Message.Chat.Id;
        string chatTitle = update.Message.Chat.Title ?? "Личная переписка";
        string? replyToMessage = update.Message.ReplyToMessage?.Text;
        
        HandleData();

        Console.WriteLine($"Получено сообщение из чата '{chatTitle}' (ID: {chatId}): {messageText}");

        if (messageText != null && Regex.IsMatch(messageText, @"\d"))
        {
            Console.WriteLine($"Сообщение, содержащее цифры: {messageText}");
        }

        if (chatId == CallCenterChatId)
        {
            return Task.CompletedTask;
        }

        string author = $"{update.Message.From?.FirstName} {update.Message.From?.LastName}";
        
        if (!string.IsNullOrEmpty(replyToMessage)) 
        {
            author = $"{author}: {messageText} (У відповідь на: '{replyToMessage}')";
        }
        
        SendToCallCentre(author, messageText);

        return Task.CompletedTask;

        // Echo the received message back to the user
        // await botClient.SendTextMessageAsync(chatId, $"Вы сказали: {messageText}", cancellationToken: cancellationToken);
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
    
    private void SendToCallCentre(string? author, string? messageText)
    {
        if (author == null || messageText == null)
        {
            return;
        }
        
        try
        {
            Message _ = _botClient.SendTextMessageAsync(
                chatId: CallCenterChatId,
                text: $"{author}: {messageText}",
                cancellationToken: _cancellation.Token
            ).GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}