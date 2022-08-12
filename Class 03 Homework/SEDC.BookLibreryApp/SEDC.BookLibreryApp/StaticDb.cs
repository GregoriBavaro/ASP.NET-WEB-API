using SEDC.BookLibreryApp.Modals;

namespace SEDC.BookLibreryApp
{
    public static class StaticDb
    {
        public static List<Book> Books = new()
        {
            new Book() {Author = "J. R. R. Tolkien", Title = "The fellowship of the ring" },
            new Book() {Author = "J. R. R. Tolkien", Title = "The Hobit" },
            new Book() {Author = "J. R. R. Tolkien", Title = "The fall of Gondolin" },
            new Book() {Author = "J. R. R. Tolkien", Title = "The two towers" },
            new Book() {Author = "J. R. R. Tolkien", Title = "The retrun of the king" },
            new Book() {Author = "J. R. R. Tolkien", Title = "The Children of Hurin" },
            new Book() {Author = "J. R. R. Tolkien", Title = "Roverandom" },
            new Book() {Author = "J. R. R. Tolkien", Title = "The fall of Arthur" },
            new Book() {Author = "J. R. R. Tolkien", Title = "The lost road" },
            new Book() {Author = "J. R. R. Tolkien", Title = "Baren and Luthien" },
        };
    }
}
