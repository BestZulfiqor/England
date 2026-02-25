using System.Collections.Concurrent;
using England.User;

namespace England.Storage;

public class UserStateStorage
{
    private readonly ConcurrentDictionary<long, UserState> cache = new();

    public void AddOrUpdate(long telegramUserId, UserState userState)
    {
        cache.AddOrUpdate(telegramUserId, userState, (x, y) => userState);
    }

    public bool TryGetValue(long telegramUserId, out UserState? userState)
    {
        return cache.TryGetValue(telegramUserId, out userState);
    }
}