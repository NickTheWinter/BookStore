using static System.IO.Directory;

namespace BookStore
{
    internal class StoredData
    {
        public static char separator = '⁂';
        public static char separatorRow = '⸘';
        public static string directory = GetCurrentDirectory();
        public static string header = "-----БАЗА ДАННЫХ: КНИЖНЫЙ МАГАЗИН-----\n\n" +
                                      "Для использования функций необходимо ввести соответствующую " +
                                      "цифру на клавиатуре.\n";
        public static string mainList = "Основные объекты программы:\n" +
                                        "1. Перечисления.\n" +
                                        "2. Список книг.\n" +
                                        "3. Приобретение книг.\n" +
                                        "4. Продажа книг.\n" +
                                        "Enter. Выход.\n";
        public static string enumList = "Список перечислений:\n" +
                                        "1. Авторы.\n" +
                                        "2. Физические лица.\n" +
                                        "3. Издательства.\n" +
                                        "Enter. Вернуться назад.\n";
        public static string funcList = "Функции:\n" +
                                        "1. Создание.\n" +
                                        "2. Просмотр.\n" +
                                        "3. Выборка.\n" +
                                        "4. Изменение.\n" +
                                        "5. Удаление.\n" +
                                        "Enter. Вернуться назад.\n";
        public static string idInput = "Введите ID.";
        public static string nameInput = "Введите наименование.";
        public static string bookNameInput = "Введите наименование книги.";
        public static string authorInput = "Введите имя автора.";
        public static string priceInput = "Введите цену книги.";
        public static string publisherInput = "Введите наименование издательства.";
        public static string yearInput = "Введите год издания.";
        public static string countInput = "Введите количество страниц.";
        public static string personInput = "Введите имя физического лица.";
        public static string numberInput = "Введите количество книг.";
        public static string amountInput = "Введите обзую стоимость.";
        public static string dateInput = "Введите дату.";
        public static string[] enumFields = { idInput, nameInput };
        public static string[] booksElementFields = { bookNameInput, authorInput, priceInput, publisherInput, yearInput, countInput };
        public static string[] movesElementFields = { personInput, nameInput, numberInput };
        public static string[] booksFields = { idInput, nameInput, authorInput, priceInput, publisherInput, yearInput, countInput };
        public static string[] movesFields = { idInput, personInput, bookNameInput, numberInput, priceInput, amountInput, dateInput };
        public static string next = "Нажмите любую клавишу, что бы продолжить.";
        public static string notEdited = "Введены неверные денные!\n" +
                                         "Повторите еще раз.\n";
        public static string[] authorsHeader = { "ID", "ФИО" };
        public static string[] personsHeader = { "ID", "ФИО" };
        public static string[] publishersHeader = { "ID", "Наименование" };
        public static string[] booksHeader = { "ID", "Наименование", "Автор", "Цена",
                                               "Издательство", "Год издания", "Количество страниц" };
        public static string[] movesHeader = { "ID", "Физическое лицо", "Книга", "Количество",
                                               "Цена", "Стоимость", "Дата" };
    }
}
