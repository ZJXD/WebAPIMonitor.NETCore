using System;

namespace WebAPIMonitor.NETCore.KafkaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (true)
            {
                string pro = Console.ReadLine();
                KafkaProducer.Instance.ProducerAsync(pro);
            }
        }
    }
}
