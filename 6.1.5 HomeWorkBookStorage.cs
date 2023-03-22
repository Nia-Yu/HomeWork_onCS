using System;
using System.Collections.Generic;

namespace HWBookStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();

            storage.ShowMenu();
        }
    }

    enum Genre
    {
        Detective = 1,
        Fantasy,
        Horror,
        History,
        Romance,
        Mystery,
        Satire,
        Poetry,
        Fantastic,
        Fiction
    }

    class Storage
    {
        private readonly List<Book> _library = new List<Book>();

        public Storage()
        {
            FillLibrary();
        }

        private void FillLibrary()
        {
            _library.Add(new Book("Ольга Гусейнова", "Путевой светлячок", 2016, Genre.Fantasy, null));
            _library.Add(new Book("Ольга Гусейнова", "Второй шанс для Елены", 2018, Genre.Fantasy, "Венчанные огнём"));
            _library.Add(new Book("Ольга Гусейнова", "Второй шанс для Юлии", 2019, Genre.Fantasy, "Венчанные огнём"));
            _library.Add(new Book("Ольга Гусейнова", "Второй шанс для Алев", 2019, Genre.Fantasy, "Венчанные огнём"));
            _library.Add(new Book("Михаил Булгаков", "Мастер и Маргарита", 1928, Genre.Romance, null));
            _library.Add(new Book("Джон Рональд Руэл Толкин", "Братство Кольца", 1954, Genre.Fantasy, "Властелин колец"));
            _library.Add(new Book("Джон Рональд Руэл Толкин", "Две крепости", 1954, Genre.Fantasy, "Властелин колец"));
            _library.Add(new Book("Джон Рональд Руэл Толкин", "Возвращение короля", 1954, Genre.Fantasy, "Властелин колец"));
            _library.Add(new Book("Екатерина Коути", "Недобрая старая Англия", 2015, Genre.History, "Окно в историю"));
        }

        public void ShowMenu()
        {
            bool isWork = true;

            while (isWork)
            {
                const string CommandAdd = "1";
                const string CommandDelete = "2";
                const string CommandShowFilter = "3";
                const string CommandOutput = "4";
                const string CommandExit = "0";

                Console.WriteLine($"Выберите действие:" +
                    $"\n{CommandAdd}. Добавить книгу " +
                    $"\n{CommandDelete}. Убрать книгу " +
                    $"\n{CommandShowFilter}. Показать книги(по фильтру) " +
                    $"\n{CommandOutput}. Показать все книги " +
                    $"\n{CommandExit}. Выход\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAdd:
                        AddBook();
                        break;

                    case CommandDelete:
                        DeleteBook();
                        break;

                    case CommandShowFilter:
                        ShowBookByFilter();
                        break;

                    case CommandOutput:
                        ShowInfoBooks();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Такой команды нет.");
                        break;
                }

                Console.Clear();
            }
        }

        public void AddBook()
        {
            string author;
            string title;
            int year;
            int genre;
            string series;
            string userInput;

            Console.WriteLine("Введите автора:");
            author = Console.ReadLine();
            Console.WriteLine("Введите название книги: ");
            title = Console.ReadLine();
            Console.WriteLine("Введите год: ");
            year = ReadIntNumber();
            Console.WriteLine("Выберите жанр из списка:");
            genre = GetGenre();
            Console.WriteLine("Введите название серии: ");
            userInput = Console.ReadLine();

            if (userInput == "")
                series = null;
            else
                series = userInput;

            Book book = new Book(author, title, year, (Genre)genre, series);
            _library.Add(book);
            Console.Write("Книга добавлена!");
        }

        public void DeleteBook()
        {
            Console.Clear();

            if (CheckLibraryLength())
            {
                Console.WriteLine("Введите номер книги которую хотите удалить: ");

                if (TryGetBook(out Book book) == false)
                {
                    _library.Remove(book);
                    Console.Write("Книга удалена!");
                }
            }
        }

        public void ShowBookByFilter()
        {
            const string CommandOne = "1";
            const string CommandTwo = "2";
            const string CommandThree = "3";
            const string CommandFour = "4";
            const string CommandFive = "5";

            Console.Clear();
            Console.WriteLine($"Выберите фильтр:" +
                $"\n{CommandOne}. По автору " +
                $"\n{CommandTwo}. По названию книги " +
                $"\n{CommandThree}. По году " +
                $"\n{CommandFour}. По жанру " +
                $"\n{CommandFive}. По серии\n");
            string userInput = Console.ReadLine();
            Console.Clear();

            switch (userInput)
            {
                case CommandOne:
                    FindAuthorBooks();
                    break;

                case CommandTwo:
                    FindBooksByTitle();
                    break;

                case CommandThree:
                    FindBooksByYear();
                    break;

                case CommandFour:
                    FindBooksByGenre();
                    break;

                case CommandFive:
                    FindBooksBySeries();
                    break;

                default:
                    Console.WriteLine("Фильтр не был выбран. Список всех книг:");
                    ShowInfoBooks();
                    break;
            }

            Console.Clear();
        }

        public void ShowInfoBooks()
        {
            for (int i = 0; i < _library.Count; i++)
            {
                int numberBook = i + 1;

                Console.Write($"{numberBook} ");
                _library[i].ShowInfo();
            }

            Console.ReadKey();
        }

        public void ShowGenres()
        {
            int number = 1;
            Genre[] genres = (Genre[])Enum.GetValues(typeof(Genre));

            foreach (var genre in genres)
            {
                Console.WriteLine($"{number} - {genre}");
                number++;
            }
        }

        private void FindAuthorBooks()
        {
            string author;
            bool isFound = false;

            Console.WriteLine("Введите автора книг:\n");
            author = Console.ReadLine();
            Console.Clear();

            foreach (var book in _library)
            {
                if (book.Author.ToLower() == author.ToLower())
                {
                    book.ShowInfo();
                    isFound = true;
                }
            }

            if (isFound == false)
                ShowMessageError();

            Console.ReadKey();
        }

        private void FindBooksByTitle()
        {
            string title;
            bool isFound = false;

            Console.WriteLine("Введите название книги:\n");
            title = Console.ReadLine();
            Console.Clear();

            foreach (var book in _library)
            {
                if (book.Title.ToLower() == title.ToLower())
                {
                    book.ShowInfo();
                    isFound = true;
                }
            }

            if (isFound == false)
                ShowMessageError();

            Console.ReadKey();
        }

        private void FindBooksByYear()
        {
            int year;
            bool isFound = false;

            Console.WriteLine("Введите год:\n");
            year = ReadIntNumber();
            Console.Clear();

            foreach (var book in _library)
            {
                if (book.Year == year)
                {
                    book.ShowInfo();
                    isFound = true;
                }
            }

            if (isFound == false)
                ShowMessageError();

            Console.ReadKey();
        }

        private void FindBooksByGenre()
        {
            int genreValue;
            bool isFound = false;

            Console.WriteLine("Выберите жанр книг:");
            genreValue = GetGenre();
            Console.Clear();

            foreach (var book in _library)
            {
                if (book.Genre == (Genre)genreValue)
                {
                    book.ShowInfo();
                    isFound = true;
                }
            }

            if (isFound == false)
                ShowMessageError();

            Console.ReadKey();
        }

        private void FindBooksBySeries()
        {
            string series;
            bool isFound = false;

            Console.WriteLine("Введите название серии книг:");
            series = Console.ReadLine();

            foreach (var book in _library)
            {
                if (book.Series.ToLower() == series.ToLower())
                {
                    book.ShowInfo();
                    isFound = true;
                }
            }

            if (isFound == false)
                ShowMessageError();

            Console.ReadKey();
        }

        private void ShowMessageError()
        {
            Console.WriteLine("Ни одной книги не найдено!");
        }

        private int GetGenre()
        {
            int numberInput = 1;
            bool isWorking = true;

            while (isWorking)
            {
                ShowGenres();

                numberInput = ReadIntNumber();

                if (numberInput >= 1 && numberInput <= (Enum.GetValues(typeof(Genre)).Length - 1))
                {
                    isWorking = false;

                    return numberInput;
                }
                else
                {
                    Console.WriteLine("Указан некорректный жанр. Повторите ввод...");
                }
            }

            return numberInput;
        }

        private int ReadIntNumber()
        {
            string userInput = Console.ReadLine();
            int numberInput;

            while ((int.TryParse(userInput, out numberInput) == false))
            {
                Console.WriteLine("Ошибка ввода! Проверьте введенные данные");

                userInput = Console.ReadLine();
            }

            return numberInput;
        }

        private bool CheckLibraryLength()
        {
            bool isCheck = true;

            if (_library.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                isCheck = false;
            }

            return isCheck;
        }

        private bool TryGetBook(out Book bookFound)
        {
            bool isCheck = true;
            bookFound = null;

            while (isCheck)
            {
                int numberId = ReadIntNumber();

                if (numberId > 0 && numberId - 1 < _library.Count)
                {
                    bookFound = _library[numberId - 1];
                    isCheck = false;
                }

                if (bookFound == null)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка! Книга не найдена, введите номер книги из списка: ");
                    ShowInfoBooks();
                }
            }

            return isCheck;
        }
    }
    class Book
    {
        public Book(string author, string title, int year, Genre genre, string series)
        {
            Author = author;
            Title = title;
            Year = year;
            Genre = genre;
            Series = series;
        }

        public string Author { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public Genre Genre { get; private set; }
        public string Series { get; private set; }

        public void ShowInfo()
        {
            if (Series != null)
                Console.WriteLine($"{Author} - {Title}. Серия {Series}. Год выпуска {Year}. Жанр: {Genre}");
            else
                Console.WriteLine($"{Author} - {Title}. Год выпуска {Year}. Жанр: {Genre}");
        }
    }
}
