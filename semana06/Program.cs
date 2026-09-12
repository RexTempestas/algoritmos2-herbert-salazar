namespace semana06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] arreglo = new string[3];

            arreglo[0] = "A1";
            arreglo[1] = "A2";
            arreglo[2] = "A3";

            Console.WriteLine($"{arreglo[0]}, {arreglo[1]} y {arreglo[2]}");
            Console.WriteLine(arreglo.Length);
            Console.WriteLine(arreglo);
        }
    }
}
