namespace a1_bookstore_ict715.Tools
{
    public interface IBookstoreSession
    {
        private const string BookKey = "user-books";
        private const string CountKey = "book-count";
        private const string SortKey = "sortOrder";
        private const string FilterKey = "filterBy";

        public ISession Session { get; set; }
        

        public void AddUserBookId(int bookId);

        
        public void RemoveUserBookId(int bookId);

        
        public void SetUserBookIds(List<int> bookIds);

        public List<int> GetUserBookIds();

        public int? GetBookCount();

        public void SetFilter(string filterBy);

        public string? GetFilter();

        public void SetSort(string sortOrder);

        public string? GetSort();

        public void RemoveBookOptions();

        public void RemoveBookCourses();
    }
}
