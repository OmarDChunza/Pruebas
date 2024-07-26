using System;
using System.Collections.Generic;

class Adivina_la_palabra
{
    static void Main()
    {
        AdivinaPalabra();
    }

    static void AdivinaPalabra()
    {
        string palabraSecreta = SeleccionarPalabra();
        HashSet<char> letrasAdivinadas = new HashSet<char>();
        int vidas = 6;

        Console.WriteLine("¡Bienvenido al juego del ahorcado!");
        Console.WriteLine("Adivina la palabra secreta letra por letra.");
        Console.WriteLine($"La palabra tiene {palabraSecreta.Length} letras.");

        while (vidas > 0)
        {
            string estadoActual = EstadoVidas(palabraSecreta, letrasAdivinadas);
            Console.WriteLine("Palabra: " + estadoActual);
            Console.WriteLine($"Vidas restantes: {vidas}");

            if (!estadoActual.Contains('_'))
            {
                Console.WriteLine("¡Felicidades!, ha encontrado la palabra correcta.");
                break;
            }

            Console.Write("Ingresa una letra: ");
            char letra = Console.ReadLine().ToLower()[0];

            if (letrasAdivinadas.Contains(letra))
            {
                Console.WriteLine("Esta letra ya fue ingresada, intente nuevamente.");
                continue;
            }

            letrasAdivinadas.Add(letra);

            if (palabraSecreta.Contains(letra))
            {
                Console.WriteLine("La letra se encuentra en la palabra.");
            }
            else
            {
                vidas--;
                Console.WriteLine("La letra no se encuentra en la palabra.");
            }
        }

        if (vidas == 0)
        {
            Console.WriteLine($"Utilizo todas las vidad que tenias, la palabra secreta era: {palabraSecreta}");
        }

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    static string SeleccionarPalabra()
    {
        string[] palabras = { "lenguaje", "programacion", "juego", "desarrollo", "computadora" };
        Random random = new Random();
        int indice = random.Next(palabras.Length);
        return palabras[indice];
    }

    static string EstadoVidas(string palabra, HashSet<char> letrasAdivinadas)
    {
        char[] estado = new char[palabra.Length];
        for (int i = 0; i < palabra.Length; i++)
        {
            estado[i] = letrasAdivinadas.Contains(palabra[i]) ? palabra[i] : '_';
        }
        return new string(estado);
    }
}
