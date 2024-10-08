namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12342-32121", "H. Martin", "First book"),
            new Book(2, "ISBN 12342-34421", "J. Smith", "Second book"),
            new Book(3, "ISBN 12672-39421", "S. Juriev", "Third book")
        };

        public Book[] GetAllByIsbn(string query)
        {
            return books.Where(book => book.Isbn == query)
                        .ToArray();
        }

        public Book[] GetAllByTitleorAuthor(string query)
        {
            return books.Where(book => book.Title.Contains(query)
                                    || book.Author.Contains(query))
                        .ToArray();
        }
    }
}
