using England.User;
using Telegram.Bot.Types;

namespace England.Pages;

public class NotStartedPage : IPage
{
    public PageResult Handle(Update update, UserState userState)
    {
        return new StartPage().View(update, userState);
    }

    public PageResult View(Update update, UserState userState)
    {
        return null;
    }
}