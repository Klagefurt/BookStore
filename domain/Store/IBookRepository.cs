namespace Store
{
    public interface IBookRepository
    {
        Book[] GetAllByIsbn(string isbn);
        Book[] GetAllByTitleorAuthor(string titlePart);
        Book GetById(int id);
    }
}
