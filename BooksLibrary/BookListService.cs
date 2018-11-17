using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NLog;

namespace BooksLibrary
{
    public class BookListService
    {
        private string path;
        private List<Book> booksList = new List<Book>(); //что инициализирует тут переменную???
        private PropertyInfo[] bookProperties = typeof(Book).GetProperties(BindingFlags.Instance | BindingFlags.Public);
        private Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Constructor with default parameter 
        /// </summary>
        /// <param name="path">directory with storage file</param>
        public BookListService(string path = "BooksStorageFile")
        {
            this.path = path;
        }

        /// <summary>
        /// Method add object into collection
        /// </summary>
        /// <param name="book">instance to add to the collection</param>
        public void AddBook(Book book)
        {
            logger.Debug("Пытаемся добавить книгу");
            logger.Debug(book);

            if (CompareBooks(book))
            {
                logger.Info("Книга не была добавлена, найдено совпадение в библиотеке!");

                throw new Exception("This book already exist!");
            }

            logger.Info("Книга успешно добавлена в библиотеку!");

            booksList.Add(book);
        }

        /// <summary>
        /// Method remove the same object as argument from the collection
        /// </summary>
        /// <param name="book">instance that we try to remove</param>
        public void RemoveBook(Book book)
        {
            logger.Debug("Пытаемся удалить книгу");
            logger.Debug(book);

            if (!CompareBooks(book))
            {
                logger.Info("Книга не может быть удалена: такой не существует в библиотеке!");

                throw new Exception("This book doesn't exist!");
            }

            logger.Info("Книга была успешно удалена из библиотеки!");

            booksList.Remove(book);
        }

        /// <summary>
        /// Method helper for AddBook and RemoveBook.
        /// Compare argument with instances in the collection 
        /// </summary>
        /// <param name="book"></param>
        /// <returns>bool result</returns>
        private bool CompareBooks(Book book)
        {
            for (int i = 0; i < booksList.Count; i++)
            {
                if (booksList[i].Equals(book))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Allow to perform search in the collection 
        /// according to tag
        /// </summary>
        /// <param name="tag">key word</param>
        /// <param name="equality">comparator</param>
        /// <returns>collection of found objects</returns>
        public List<Book> FindBooksByTag<T>(T tag, ICustomEquality<T> equality)
        {
            List<Book> list = new List<Book>();

            logger.Debug($"Пытаемся найти книгу по тегу: {tag}");

            for (int i = 0; i < booksList.Count; i++)
            {
                if (equality.Equals(tag, booksList[i]))
                {
                    logger.Debug("Совпадение обнаружено");
                    logger.Debug(booksList[i]);

                    list.Add(booksList[i]);
                }
            }

            logger.Info($"Было обнаружено {list.Count} совпадений по тегу");

            return list;
        }

        /// <summary>
        /// Method for sorting instances in the collection
        /// </summary>
        /// <param name="compare">comparartor</param>
        public void SortBooksByTag(IComparer<Book> compare)
        {
            logger.Debug("Начата сортировка по тегу");

            booksList.Sort(compare);

            logger.Info("Сортировка завершена успешно!");
        }

        /// <summary>
        /// Method to load collection from file
        /// </summary>
        public void LoadFile()
        {
            logger.Debug($"Производится загрузка данных из файла {path}");

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                logger.Debug($"Доступ к файлу осуществлен, начат процесс чтения");

                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    string publishingHouse = reader.ReadString();
                    int yearOfPublishung = reader.ReadInt32();
                    int numberOfPages = reader.ReadInt32();
                    double cost = reader.ReadDouble();

                    booksList.Add(new Book(isbn, author, title, publishingHouse, yearOfPublishung, numberOfPages, cost));
                }

                logger.Debug("Процесс чтения заверен");
            }

            logger.Info($"Было загружено {booksList.Count} записей из файла {path}");
        }

        /// <summary>
        /// Method to save collection to file
        /// </summary>
        public void SaveFile()
        {
            logger.Debug($"Попытка сохранения записей о книгах в файл {path}");

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                logger.Debug("Начат процесс записи");

                foreach (Book book in booksList)
                {
                    writer.Write(book.ISBN);
                    writer.Write(book.Author);
                    writer.Write(book.Title);
                    writer.Write(book.PublishingHouse);
                    writer.Write(book.YearOfPublishing);
                    writer.Write(book.NumberOfPages);
                    writer.Write(book.Cost);
                }

                logger.Debug("Процесс записи завершен");
            }

            logger.Info($"Было сделано {booksList.Count} записей о книгах в файл {path}");
        }

        public List<Book> GetBook()
        {
            return booksList;
        }
    }
}
