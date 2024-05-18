using System.Threading.Tasks;

namespace UnderwaterBot
{
    class Program
    {
        public static Task Main(string[] args)
            => Startup.RunAsync(args);
    }
}