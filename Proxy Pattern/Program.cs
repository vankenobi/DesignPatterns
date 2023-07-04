using System;

namespace ProxyPattern // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new FileLogger();
            logger.Log("The rocket is landing");
        }
    }

    public interface ILogger
    {
        void Log(string message);
        void Log(IEnumerable<string> messages);
    }

    public class BufferedFileLoggerProxy
    {
        private readonly int bufferSize;
        private readonly FileLogger fileLogger;
        private List<string> buffer;

        public BufferedFileLoggerProxy(int bufferSize)
        {
            this.bufferSize = bufferSize;
            this.fileLogger = new FileLogger();
            buffer = new List<string>(capacity: bufferSize);
        }

        public void Log(string message)
        {
            buffer.Add(message);
            if (bufferSize <= buffer.Count)
            {
                //foreach (var log in buffer)
                //{
                //    fileLogger.Log(log);
                //}

                fileLogger.Log(buffer);
                buffer.Clear(); 
            }
        }
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            message = $"[{DateTime.Now:dd.MM.yyyy}] - {message}";
            File.AppendAllText("./message.txt", message);
        }

        public void Log(IEnumerable<string> messages)
        {
            File.AppendAllText("./message.txt", string.Join(Environment.NewLine, messages));
        }

    }
}