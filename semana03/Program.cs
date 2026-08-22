using System.Threading.Channels;

namespace semana03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ALGORITMOS II - SEMANA 03");

            Console.WriteLine("What's her name?");
            String chica = Console.ReadLine();
            Console.WriteLine($"Hello, {chica}!");

            Console.WriteLine("How old are her?");
            int age = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"She was {age - 10} years old 10 years ago");

        }
    }
}
