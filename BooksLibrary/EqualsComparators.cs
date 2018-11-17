namespace BooksLibrary
{
    /// <summary>
    /// Custom interface for argument comparison
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomEquality<T>
    {
        bool Equals(T tag, Book book);
    }

    /// <summary>
    /// Compare for equality objects acccording to field ISBN 
    /// </summary>
    public class ISBNEqualComparer : ICustomEquality<string>
    {
        public bool Equals(string tag, Book book)
        {
            return tag.Equals(book.ISBN);
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field Author
    /// </summary>
    public class AuthorEqualComparer : ICustomEquality<string>
    {
        public bool Equals(string author, Book book)
        {
            return author.Equals(book.Author);
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field Title
    /// </summary>
    public class TitleEqualComparer : ICustomEquality<string>
    {
        public bool Equals(string title, Book book)
        {
            return title.Equals(book.Title);
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field PublishingHouse
    /// </summary>
    public class PublishingHouseEqualComparer : ICustomEquality<string>
    {
        public bool Equals(string publishingHouse, Book book)
        {
            return publishingHouse.Equals(book.PublishingHouse);
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field YearOfPublishing
    /// </summary>
    public class YearOfPublishingEqualComparer : ICustomEquality<int>
    {
        public bool Equals(int yearOfPublishing, Book book)
        {
            return yearOfPublishing.Equals(book.YearOfPublishing);
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field NumberOfPages
    /// </summary>
    public class NumberOfPagesEqualComparer : ICustomEquality<int>
    {
        public bool Equals(int numberOfPages, Book book)
        {
            return numberOfPages.Equals(book.NumberOfPages);
        }
    }

    /// <summary>
    /// Compare for equality objects acccording to field Price
    /// </summary>
    public class CostEqualComparer : ICustomEquality<double>
    {
        public bool Equals(double cost, Book book)
        {
            return cost.Equals(book.Cost);
        }
    }
}
