using England.User;
using Telegram.Bot.Types.ReplyMarkups;

namespace England.Pages;

public class PageResult
{
    public string Text { get; }
    public ReplyMarkup ReplyMarkup { get; }

    public UserState UpdateUserState { get; set; }

    public PageResult(string text, ReplyMarkup replyMarkup)
    {
        Text = text;
        ReplyMarkup = replyMarkup;
    }
}