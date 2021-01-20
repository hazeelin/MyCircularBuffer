using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCircularBuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CircularBuffer<int> buffer = new CircularBuffer<int>(20);

            for (int i = 0; i < 10; i++)
            {
                buffer.Enqueue(i);
            }

            var list = buffer.Peek();

            Console.WriteLine("peeking...");

            if (list != null)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.WriteLine("dequeueing...");
            while (!buffer.IsEmpty)
            {
                Console.WriteLine(buffer.Dequeue());
            }
        }
    }
}
