namespace Store.Tests
{
    public class BookTest
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);

            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("    ");

            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBN 34323");

            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            bool actual = Book.IsIsbn("ISBN 123-456-789 0");

            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("ISBN 123-456-789 0123");

            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithTrashStartOrEnd_ReturnFalse()
        {
            bool actual = Book.IsIsbn("xxx ISBN 123-456-789 0123 yyy");

            Assert.False(actual);
        }
    }
}