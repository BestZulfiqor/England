using England.User;
using Telegram.Bot.Types;

namespace England.Pages;

public interface IPage
{
    PageResult View(Update update, UserState userState);
    PageResult Handle(Update update, UserState userState);
}