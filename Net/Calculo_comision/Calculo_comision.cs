using System;

class Calculo_comision
{
    static void Main()
    {
        // Pregunta por el nombre del vendedor
        Console.Write("Ingrese su nombre por favor: ");
        string nombre = Console.ReadLine();

        // Pregunta por las ventas totales del mes
        Console.Write("Ingresa el total de ventas del mes: ");
        string ventasStr = Console.ReadLine();

        // Convierte el string de ventas a float
        float ventasTotales = float.Parse(ventasStr);

        // Calcula la comisión (20% de las ventas totales)
        float comision = ventasTotales * 0.20f;

        // Muestra el resultado
        Console.WriteLine($"Hola {nombre}, sus comisiónes este mes son de: {comision:C}");

        // Espera antes de cerrar
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
