using England.User;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace England.Pages;

public class StartPage : IPage
{
    public PageResult View(Update update, UserState userState)
    {
        var text = @"Hello, dear student, I'm your teacher!";

        return new PageResult(text, GetKeyboard())
        {
            UpdateUserState = new UserState(this, userState.UserData)
        };
    }

    public PageResult Handle(Update update, UserState userState)
    {
        if (update.Message == null)
        {
            return new PageResult("Tap the buttons", replyMarkup: GetKeyboard());
        }

        if (update.Message.Text == "Мозгокачалка")
        {
            return new BrainGymPage().View(update, userState);
        }

        if (update.Message.Text == "Войти в IT")
        {
            return new EnterToItPage().View(update, userState);
        }

        return null;
    }

    private ReplyKeyboardMarkup GetKeyboard()
    {
        return new ReplyKeyboardMarkup(
        [
            [
                new KeyboardButton("Мозгокачалка")
            ],
            [
                new KeyboardButton("Войти в IT")
            ]
        ])
        {
            ResizeKeyboard = true,
        };
    }
}