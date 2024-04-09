using System.Text.Json;

namespace a1_bookstore_ict715.Tools
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return JsonSerializer.Deserialize<T>(value ?? "") ?? default(T);
        }
    }

}
