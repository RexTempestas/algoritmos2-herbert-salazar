
namespace semana04___Ejercicio02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String clientName;
            int clientAge;
            decimal normalPrice = 6.00m, specialPrice = 3.00m;

            Console.Write("ALGORITMOS II - SEMANA 04 - EJERCICIO 02\n" +
                              "Enter client name: ");
            clientName = Console.ReadLine();

            Console.Write("Enter client age: ");
            clientAge = int.Parse(Console.ReadLine());

            if (clientAge < 12 || clientAge >= 60)
            {
                Console.WriteLine($"El cliente \"{clientName}\" obtiene una tarifa preferencial de {specialPrice:C}.");
            }
            else {
                Console.WriteLine($"El cliente \"{clientName}\" obtiene una tarifa regular de {normalPrice:C}.");
            }


        }
    }
}
