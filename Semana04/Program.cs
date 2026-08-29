namespace Semana04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double nota;

            Console.WriteLine("Digite la nota del estudiante");
            nota = double.Parse(Console.ReadLine());
            Console.WriteLine();

            if (nota == 0) {
                Console.WriteLine("No tiene nota en esta materia");
            }
            else if (nota > 0 && nota < 6)
            {
                Console.WriteLine("Su nota es inferior al valor de aprobación");
            }
            else if (nota >= 6 && nota <=10)
            {
                Console.WriteLine("Su nota es superior al valor de aprobación");
                if (nota >= 8 && nota < 10)
                {
                    Console.WriteLine("Felicidades su nota es destacable");
                }
                else if (nota == 10)
                {
                    Console.WriteLine("Felicidades su nota es excelente");
                }
            }
            else
            {
                Console.WriteLine("Nota invalida - Sale de rango (0 - 10)");
            }

        }
    }
}
