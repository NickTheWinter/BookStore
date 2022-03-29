namespace BookStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TraceLog.Initialize();
            Database.Initialize();
            Interface.Initialize();
            Database.Deinitialize();
        }
    }
}
