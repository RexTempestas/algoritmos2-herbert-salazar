
namespace ResumenCompra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String cliente, producto;
            decimal precioUnitario, costoEnvio, porcentajeDescuento, descuento, pago, subtotal, total, cambio;
            int cantidad;

            Console.Write("Cliente: ");
            cliente = Console.ReadLine();

            Console.Write("Producto: ");
            producto = Console.ReadLine();

            Console.Write("Precio unitario: ");
            precioUnitario = decimal.Parse(Console.ReadLine());

            Console.Write("Cantidad: ");
            cantidad = int.Parse(Console.ReadLine());

            Console.Write("Porcentaje descuento: ");
            porcentajeDescuento = decimal.Parse(Console.ReadLine());

            Console.Write("Costo de envio: ");
            costoEnvio = decimal.Parse(Console.ReadLine());

            Console.Write("Pago recibido: ");
            pago = decimal.Parse(Console.ReadLine());

            subtotal = precioUnitario *  cantidad;
            descuento = subtotal * (porcentajeDescuento / 100);
            total = subtotal - descuento + costoEnvio;
            cambio = pago - total;

            Console.WriteLine($"\n\tRESUMEN DE COMPRA\n" +
                              $"Cliente:\t\"{cliente}\"\n" + 
                              $"Producto:\t\"{producto}\"\n" +
                              $"Precio:\t\t{precioUnitario:c}\n" +
                              $"Cantidad:\t{cantidad}\n" +
                              $"Envio:\t\t{costoEnvio:c}\n" +
                              $"Subtotal:\t{subtotal:c}\n" +
                              $"Descuento:\t{descuento:c}\n" +
                              $"TOTAL:\t\t{total:c}\n" +
                              $"Pago:\t\t{pago:c}\n" +
                              $"Cambio:\t\t{cambio:c}\n$" +
                              $"Carpeta:\tC:\\AlgoritmosII\\Lab02");

        }
    }
}
