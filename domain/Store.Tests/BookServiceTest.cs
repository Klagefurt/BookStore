using Moq;

namespace Store.Tests
{
    public class BookServiceTest
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                              .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleorAuthor(It.IsAny<string>()))
                              .Returns(new[] { new Book(2, "", "", "", "", 0m) });
            
            var bookService = new BookService(bookRepositoryStub.Object);

            var validIsbn = "ISBN 123-456-7890";
            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitleorAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByTitleorAuthor(It.IsAny<string>()))
                              .Returns([new Book(1, "", "", "", "", 0m)]);

            bookRepositoryStub.Setup(x => x.GetAllByTitleorAuthor(It.IsAny<string>()))
                              .Returns([new Book(2, "", "", "", "", 0m)]);

            var bookService = new BookService(bookRepositoryStub.Object);

            var invalidIsbn = "123-456-7890";
            var actual = bookService.GetAllByQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
    }
}
