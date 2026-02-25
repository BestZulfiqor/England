using England.User;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace England.Pages;

public class BrainGymPage : IPage
{
    public PageResult View(Update update, UserState userState)
    {
        var text = @"МОЗГОКАЧАЛКА

Правило всего одно - решать задачи каждый день на любых курсах в Stepik
УЧАСТИЕ В ПРОЕКТЕ - БЕСПЛАТНОЕ";

        return new PageResult(text, GetKeyboard())
        {
            UpdateUserState = new UserState(this, userState.UserData),
        };
    }

    public PageResult Handle(Update update, UserState userState)
    {
        throw new NotImplementedException();
    }

    private ReplyKeyboardMarkup GetKeyboard()
    {
        return new ReplyKeyboardMarkup(
        [
            [
                new KeyboardButton("ПОДРОБНЕЕ"),
                new KeyboardButton("СМОТРЕТЬ ЭФИР")
            ],
            [
                new KeyboardButton("ВСТУПИТЬ")
            ],
            [
                new KeyboardButton("НАЗАД")
            ]
        ])
        {
            ResizeKeyboard = true,
        };
    }
}