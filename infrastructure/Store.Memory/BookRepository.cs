namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 0131103628", "Brian W. Kernighan", "C Programming Language", "Includes detailed coverage of the C language " +
                "plus the official C language reference manual for at-a-glance help with syntax notation, declarations, ANSI changes, " +
                "scope rules, and the list goes on and on.", 7.19m),
            new Book(2, "ISBN 1835081746", "John Horton", "Beginning C++ Game Programming", "Get to grips with programming and game " +
                "development techniques using C++ libraries and Visual Studio 2022 with this updated edition of the bestselling series.", 22.2m),
            new Book(3, "ISBN 1718502702", "Eric Matthes", "Python Crash Course", "Python Crash Course is the world’s bestselling programming book, " +
                "with over 1,500,000 copies sold to date!", 41.1m),
            new Book(4, "ISBN 1098147448", "Joseph Albahari", "C# 12 in a Nutshell: The Definitive Reference", "Aimed at intermediate and advanced " +
                "programmers, this is a book whose explanations get straight to the point, covering C#, the CLR, and the core .NET libraries in depth " +
                "without long intros or bloated samples.", 65.9m)

        };

        public Book[] GetAllByIsbn(string query)
        {
            return books.Where(book => book.Isbn == query)
                        .ToArray();
        }

        public Book[] GetAllByTitleorAuthor(string query)
        {
            if (string.IsNullOrEmpty(query)) return Array.Empty<Book>();

            return books.Where(book => book.Title.Contains(query)
                                    || book.Author.Contains(query))
                        .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
