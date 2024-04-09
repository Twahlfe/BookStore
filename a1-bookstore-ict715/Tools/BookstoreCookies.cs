using a1_bookstore_ict715.Models;

namespace a1_bookstore_ict715.Tools
{
    public class BookstoreCookies
    {
        private const string BookKey = "user-book-ids";
        private const string Delimiter = "-";

        private IRequestCookieCollection? requestCookies;
        private IResponseCookies? responseCookies;
        

        public BookstoreCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }
        
        public BookstoreCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }
        
        public void SetUserBookIds(List<int> userBookIds)
        {
            string idsString = string.Join(Delimiter, userBookIds);
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            RemoveUserBookIds();
            responseCookies?.Append(BookKey, idsString, options);
        }
        

        public void SetUserBookIds(List<BookModel> userBooks)
        {
            List<int> ids = userBooks.Select(cr => cr.BookId).ToList();
            SetUserBookIds(ids);
        }
        

        public List<int> GetUserBookIds()
        {
            string? cookie = requestCookies?[BookKey];
            if (string.IsNullOrEmpty(cookie))
                return new List<int>();
            else
                return cookie.Split(Delimiter).Select(d => Convert.ToInt32(d)).ToList();
        }
        

        public void RemoveUserBookIds()
        {
            responseCookies?.Delete(BookKey);
        }
    }
}
