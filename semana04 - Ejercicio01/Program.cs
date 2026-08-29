namespace semana04___Ejercicios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String studentName;
            double gradesAverage, attendancePercentage;

            Console.Write("ALGORITMOS II - SEMANA 04 - EJERCICIO 01\n" +
                              "Enter student name: ");
            studentName = Console.ReadLine();

            Console.Write("Enter grades average: ");
            gradesAverage = double.Parse(Console.ReadLine());

            Console.Write("Enter attendance percentage: ");
            attendancePercentage = (double.Parse(Console.ReadLine()))/100;

            if (gradesAverage >= 8 && attendancePercentage >= 0.85)
            {
                Console.WriteLine("El estudiante cumple los requisitos para solicitar la beca.");
            }
            else {
                Console.WriteLine("El estudiante no cumple los requisitos para solicitar la beca.");
            }
        }
    }
}
