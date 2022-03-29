using System.IO;
using static BookStore.StoredData;

namespace BookStore
{
    internal class Files
    {
        static void Authors(out string import)
        {
            import = "";
            string path = $@"{directory}\authors.txt";
            try
            {
                using (StreamReader authors = new StreamReader(path))
                {
                    import = authors.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
        }
        static void Authors(string export)
        {
            string path = $@"{directory}\authors.txt";
            using (StreamWriter authors = new StreamWriter(path))
            {
                authors.Write(export);
            }
        }
        static void Persons(out string import)
        {
            import = "";
            string path = $@"{directory}\persons.txt";
            try
            {
                using (StreamReader persons = new StreamReader(path))
                {
                    import = persons.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
        }
        static void Persons(string export)
        {
            string path = $@"{directory}\persons.txt";
            using (StreamWriter persons = new StreamWriter(path))
            {
                persons.Write(export);
            }
        }
        static void Publishers(out string import)
        {
            import = "";
            string path = $@"{directory}\publishers.txt";
            try
            {
                using (StreamReader publishers = new StreamReader(path))
                {
                    import = publishers.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
        }
        static void Publishers(string export)
        {
            string path = $@"{directory}\publishers.txt";
            using (StreamWriter publishers = new StreamWriter(path))
            {
                publishers.Write(export);
            }
        }
        static void Books(out string import)
        {
            import = "";
            string path = $@"{directory}\books.txt";
            try
            {
                using (StreamReader books = new StreamReader(path))
                {
                    import = books.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
        }
        static void Books(string export)
        {
            string path = $@"{directory}\books.txt";
            using (StreamWriter books = new StreamWriter(path))
            {
                books.Write(export);
            }
        }
        static void Buy(out string import)
        {
            import = "";
            string path = $@"{directory}\buy.txt";
            try
            {
                using (StreamReader buy = new StreamReader(path))
                {
                    import = buy.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
        }
        static void Buy(string export)
        {
            string path = $@"{directory}\buy.txt";
            using (StreamWriter buy = new StreamWriter(path))
            {
                buy.Write(export);
            }
        }
        static void Sell(out string import)
        {
            import = "";
            string path = $@"{directory}\sell.txt";
            try
            {
                using (StreamReader sell = new StreamReader(path))
                {
                    import = sell.ReadToEnd();
                }
            }
            catch (FileNotFoundException) { }
        }
        static void Sell(string export)
        {
            string path = $@"{directory}\sell.txt";
            using (StreamWriter sell = new StreamWriter(path))
            {
                sell.Write(export);
            }
        }
        public static string[] Deinitialize()
        {
            string[] import = new string[6];
            Authors(out import[0]);
            Persons(out import[1]);
            Publishers(out import[2]);
            Books(out import[3]);
            Buy(out import[4]);
            Sell(out import[5]);
            return import;
        }
        public static void Initialize(string[] export)
        {
            Authors(export[0]);
            Persons(export[1]);
            Publishers(export[2]);
            Books(export[3]);
            Buy(export[4]);
            Sell(export[5]);
        }
    }
}
