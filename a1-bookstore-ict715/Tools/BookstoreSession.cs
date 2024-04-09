namespace a1_bookstore_ict715.Tools
{
    public class BookstoreSession : IBookstoreSession
    {
        private const string BookKey = "user-books";
        private const string CountKey = "books-count";
        private const string SortKey = "sortOrder";
        private const string FilterKey = "filterBy";
        

        public ISession Session { get; set; } = null;

        // This method adds favorite books to the users session by the BookId
        public void AddUserBookId(int bookId)
        {
            List<int> ids = Session.GetObject<List<int>>(BookKey) ?? new List<int>();
            if (!ids.Contains(bookId))
            {
                ids.Add(bookId);
                SetUserBookIds(ids);
            }
        }

        // This method removes favorite books to the users session by the BookId
        public void RemoveUserBookId(int bookId)
        {
            List<int> ids = Session.GetObject<List<int>>(BookKey) ?? new List<int>();
            if (ids.Contains(bookId))
            {
                ids.Remove(bookId);
                SetUserBookIds(ids);
            }
        }


        public void SetUserBookIds(List<int> bookIds)
        {
            Session.SetObject(BookKey, bookIds);
            Session.SetInt32(CountKey, bookIds.Count);
        }

        public List<int> GetUserBookIds() =>
            Session.GetObject<List<int>>(BookKey) ?? new List<int>();

        public int? GetBookCount() => Session.GetInt32(CountKey);

        public void SetFilter(string filterBy)
        {
            Session.SetString(FilterKey, filterBy);
        }
        public string? GetFilter() => Session.GetString(FilterKey);

        public void SetSort(string sortOrder) =>
            Session.SetString(SortKey, sortOrder);
        public string? GetSort() => Session.GetString(SortKey);

        public void RemoveBookOptions()
        {
            Session.Remove(FilterKey);
            Session.Remove(SortKey);
        }
        
        public void RemoveBookCourses()
        {
            throw new NotImplementedException();
        }
    }
}
