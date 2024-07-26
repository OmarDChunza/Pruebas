using System;
using System.IO;

class Informes
{
    static void Main()
    {
        string directorioBase = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Kosmos");

        // Crear estructura de directorios y archivos si no existe.
        CrearEstructuraInicial(directorioBase);

        Console.WriteLine("¡Bienvenido al sistema de gestión de informes!");
        Console.WriteLine($"La ruta de acceso al directorio de informes es: {directorioBase}");
        Console.WriteLine($"Hay {ContarInformes(directorioBase)} informes en total.");

        while (true)
        {
            Console.WriteLine("\nElige una opción:");
            Console.WriteLine("1. Leer un informe");
            Console.WriteLine("2. Crear un nuevo informe");
            Console.WriteLine("3. Crear una nueva categoría");
            Console.WriteLine("4. Eliminar un informe");
            Console.WriteLine("5. Eliminar una categoría");
            Console.WriteLine("6. Salir");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    LeerInforme(directorioBase);
                    break;
                case "2":
                    CrearInforme(directorioBase);
                    break;
                case "3":
                    CrearCategoria(directorioBase);
                    break;
                case "4":
                    EliminarInforme(directorioBase);
                    break;
                case "5":
                    EliminarCategoria(directorioBase);
                    break;
                case "6":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }
    }

    static void CrearEstructuraInicial(string directorioBase)
    {
        string[] categorias = { "Marketing", "Ventas", "Compras", "Métricas" };

        foreach (var categoria in categorias)
        {
            string rutaCategoria = Path.Combine(directorioBase, categoria);
            Directory.CreateDirectory(rutaCategoria);

            for (int i = 1; i <= 2; i++)
            {
                string archivoInforme = Path.Combine(rutaCategoria, $"informe{i}.txt");
                if (!File.Exists(archivoInforme))
                {
                    File.WriteAllText(archivoInforme, $"Este es el contenido del informe {i} de la categoría {categoria}.");
                }
            }
        }
    }

    static int ContarInformes(string directorioBase)
    {
        int contador = 0;
        foreach (var directorio in Directory.GetDirectories(directorioBase))
        {
            contador += Directory.GetFiles(directorio, "*.txt").Length;
        }
        return contador;
    }

    static void LeerInforme(string directorioBase)
    {
        Console.WriteLine("Elige una categoría:");
        string[] categorias = Directory.GetDirectories(directorioBase);

        for (int i = 0; i < categorias.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(categorias[i])}");
        }

        int categoriaElegida = int.Parse(Console.ReadLine()) - 1;
        string categoriaPath = categorias[categoriaElegida];

        Console.WriteLine("Elige un informe:");
        string[] informes = Directory.GetFiles(categoriaPath, "*.txt");

        for (int i = 0; i < informes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(informes[i])}");
        }

        int informeElegido = int.Parse(Console.ReadLine()) - 1;
        string informePath = informes[informeElegido];

        string contenido = File.ReadAllText(informePath);
        Console.WriteLine($"Contenido del informe:\n{contenido}");
    }

    static void CrearInforme(string directorioBase)
    {
        Console.WriteLine("Elige una categoría:");
        string[] categorias = Directory.GetDirectories(directorioBase);

        for (int i = 0; i < categorias.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(categorias[i])}");
        }

        int categoriaElegida = int.Parse(Console.ReadLine()) - 1;
        string categoriaPath = categorias[categoriaElegida];

        Console.Write("Ingresa el nombre del nuevo informe (sin extensión): ");
        string nombreInforme = Console.ReadLine();

        Console.Write("Ingresa el contenido del nuevo informe: ");
        string contenidoInforme = Console.ReadLine();

        string informePath = Path.Combine(categoriaPath, $"{nombreInforme}.txt");
        File.WriteAllText(informePath, contenidoInforme);

        Console.WriteLine("Informe creado exitosamente.");
    }

    static void CrearCategoria(string directorioBase)
    {
        Console.Write("Ingresa el nombre de la nueva categoría: ");
        string nombreCategoria = Console.ReadLine();

        string categoriaPath = Path.Combine(directorioBase, nombreCategoria);
        Directory.CreateDirectory(categoriaPath);

        Console.WriteLine("Categoría creada exitosamente.");
    }

    static void EliminarInforme(string directorioBase)
    {
        Console.WriteLine("Elige una categoría:");
        string[] categorias = Directory.GetDirectories(directorioBase);

        for (int i = 0; i < categorias.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(categorias[i])}");
        }

        int categoriaElegida = int.Parse(Console.ReadLine()) - 1;
        string categoriaPath = categorias[categoriaElegida];

        Console.WriteLine("Elige un informe para eliminar:");
        string[] informes = Directory.GetFiles(categoriaPath, "*.txt");

        for (int i = 0; i < informes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(informes[i])}");
        }

        int informeElegido = int.Parse(Console.ReadLine()) - 1;
        string informePath = informes[informeElegido];

        File.Delete(informePath);
        Console.WriteLine("Informe eliminado exitosamente.");
    }

    static void EliminarCategoria(string directorioBase)
    {
        Console.WriteLine("Elige una categoría para eliminar:");
        string[] categorias = Directory.GetDirectories(directorioBase);

        for (int i = 0; i < categorias.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(categorias[i])}");
        }

        int categoriaElegida = int.Parse(Console.ReadLine()) - 1;
        string categoriaPath = categorias[categoriaElegida];

        Directory.Delete(categoriaPath, true);
        Console.WriteLine("Categoría eliminada exitosamente.");
    }
}
