using System.Diagnostics;
using static System.DateTime;
using static BookStore.StoredData;

namespace BookStore
{
    internal class TraceLog
    {
        public static void Initialize()
        {
            TextWriterTraceListener log = new TextWriterTraceListener($@"{directory}\log.txt");
            Trace.Listeners.Add(log);
            Trace.WriteLine($"Запуск программы {Now}.\n");
            Trace.Flush();
        }
        public static void WriteLog(string text)
        {
            Trace.WriteLine($"Произведено действие {Now}.\n{text}");
            Trace.Flush();
        }
    }
}
