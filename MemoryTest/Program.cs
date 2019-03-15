using System;

namespace MemoryTest
{
    class Program
    {
        private HundredMegabyte hundred;

        public void Run()
        {
            Console.WriteLine("ready to attach");
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine("iteration #{0}", i + 1);
                hundred = new HundredMegabyte();
                Console.WriteLine("{0} object was initialized", hundred);
                Console.ReadKey();
                hundred.Dispose();
                hundred = null;
            }
        }

        static void Main()
        {
            var test = new Program();
            test.Run();
        }
    }

    public class HundredMegabyte : IDisposable
    {
        private readonly Megabyte[] megabytes = new Megabyte[100];

        public HundredMegabyte()
        {
            for (var i = 0; i < megabytes.Length; i++)
            {
                megabytes[i] = new Megabyte();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~HundredMegabyte()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
        }

        public override string ToString()
        {
            return String.Format("{0}MB", megabytes.Length);
        }
    }

    public class Megabyte
    {
        private readonly Kilobyte[] kilobytes = new Kilobyte[1024];

        public Megabyte()
        {
            for (var i = 0; i < kilobytes.Length; i++)
            {
                kilobytes[i] = new Kilobyte();
            }
        }
    }

    public class Kilobyte
    {
        private byte[] bytes = new byte[1024];
    }
}
