using England.Pages;
using England.Storage;
using England.User;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace England;

class Program
{
    static UserStateStorage storage = new();

    static async Task Main(string[] args)
    {
        var client = new TelegramBotClient("8535196591:AAFLYX3Sm8qSe5oQw0WwZ4C0MQurqQmC65w");

        var user = await client.GetMe();
        Console.WriteLine($"Listening to {user.Username}");

        client.StartReceiving(updateHandler: UpdateHandler, errorHandler: ErrorHandler);
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }

    private static async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if (update.Message?.Text == null)
        {
            return;
        }

        var telegramUserId = update.Message.From.Id;
        Console.WriteLine($"UpdateId  = {update.Id}, TelegramUserId = {telegramUserId}");

        var isExistUserState = storage.TryGetValue(telegramUserId, out var userState);

        if (!isExistUserState)
        {
            userState = new UserState(new NotStartedPage(), new UserData());
        }

        Console.WriteLine($"UpdateId = {update.Id}, CURRENT_UserState = {userState}");

        var result = userState!.Page.Handle(update, userState);
        Console.WriteLine(
            $"UpdateId = {update.Id}, \n----- send_text = {result.Text} \n, UPDATED_UserState = {result.UpdateUserState}");

        await client.SendMessage(
            chatId: telegramUserId,
            text: result.Text,
            replyMarkup: result.ReplyMarkup,
            cancellationToken: token);

        storage.AddOrUpdate(telegramUserId, result.UpdateUserState);
    }

    private static Task ErrorHandler(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        Console.WriteLine(exception);
        return Task.CompletedTask;
    }
}