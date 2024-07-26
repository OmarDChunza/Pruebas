using System;

public class Empleado
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public decimal Salario { get; set; }

    public Empleado(string nombre, string apellido, decimal salario)
    {
        Nombre = nombre;
        Apellido = apellido;
        Salario = salario;
    }

    public decimal CalcularSalarioAnual()
    {
        return Salario * 12;
    }
}

public class Gerente : Empleado
{
    public string Departamento { get; set; }

    public Gerente(string nombre, string apellido, decimal salario, string departamento)
        : base(nombre, apellido, salario)
    {
        Departamento = departamento;
    }

    public void IncrementarSalario(decimal porcentaje)
    {
        Salario += Salario * (porcentaje / 100);
    }
}

public class Program
{
    public static void Main()
    {
        // Crear una instancia de la clase Gerente
        Gerente gerente = new Gerente("Ana", "García", 5000, "Ventas");

        // Incrementar el salario del gerente en un 10%
        gerente.IncrementarSalario(10);

        // Mostrar el nuevo salario anual
        Console.WriteLine($"El nuevo salario anual de {gerente.Nombre} {gerente.Apellido} es: {gerente.CalcularSalarioAnual()}");

        // Espera antes de cerrar
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
