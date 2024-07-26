import os

def main():
    directorio_base = os.path.join(os.path.expanduser("~"), "Kosmos")

    # Crear estructura de directorios y archivos si no existe
    crear_estructura_inicial(directorio_base)

    print("¡Bienvenido al sistema de gestión de informes!")
    print(f"La ruta de acceso al directorio de informes es: {directorio_base}")
    print(f"Hay {contar_informes(directorio_base)} informes en total.")

    while True:
        print("\nElige una opción:")
        print("1. Leer un informe")
        print("2. Crear un nuevo informe")
        print("3. Crear una nueva categoría")
        print("4. Eliminar un informe")
        print("5. Eliminar una categoría")
        print("6. Salir")

        opcion = input()

        if opcion == "1":
            leer_informe(directorio_base)
        elif opcion == "2":
            crear_informe(directorio_base)
        elif opcion == "3":
            crear_categoria(directorio_base)
        elif opcion == "4":
            eliminar_informe(directorio_base)
        elif opcion == "5":
            eliminar_categoria(directorio_base)
        elif opcion == "6":
            print("Saliendo del programa...")
            break
        else:
            print("Opción no válida. Inténtalo de nuevo.")

def crear_estructura_inicial(directorio_base):
    categorias = ["Marketing", "Ventas", "Compras", "Métricas"]

    for categoria in categorias:
        ruta_categoria = os.path.join(directorio_base, categoria)
        os.makedirs(ruta_categoria, exist_ok=True)

        for i in range(1, 3):
            archivo_informe = os.path.join(ruta_categoria, f"informe{i}.txt")
            if not os.path.exists(archivo_informe):
                with open(archivo_informe, 'w') as f:
                    f.write(f"Este es el contenido del informe {i} de la categoría {categoria}.")

def contar_informes(directorio_base):
    contador = 0
    for directorio in os.listdir(directorio_base):
        ruta_directorio = os.path.join(directorio_base, directorio)
        if os.path.isdir(ruta_directorio):
            contador += len([archivo for archivo in os.listdir(ruta_directorio) if archivo.endswith('.txt')])
    return contador

def leer_informe(directorio_base):
    categorias = listar_categorias(directorio_base)
    categoria_elegida = seleccionar_opcion("Elige una categoría:", categorias)
    informes = listar_informes(os.path.join(directorio_base, categoria_elegida))
    informe_elegido = seleccionar_opcion("Elige un informe:", informes)

    ruta_informe = os.path.join(directorio_base, categoria_elegida, informe_elegido)
    with open(ruta_informe, 'r') as f:
        contenido = f.read()
        print(f"Contenido del informe:\n{contenido}")

def crear_informe(directorio_base):
    categorias = listar_categorias(directorio_base)
    categoria_elegida = seleccionar_opcion("Elige una categoría:", categorias)

    nombre_informe = input("Ingresa el nombre del nuevo informe (sin extensión): ") + ".txt"
    contenido_informe = input("Ingresa el contenido del nuevo informe: ")

    ruta_informe = os.path.join(directorio_base, categoria_elegida, nombre_informe)
    with open(ruta_informe, 'w') as f:
        f.write(contenido_informe)

    print("Informe creado exitosamente.")

def crear_categoria(directorio_base):
    nombre_categoria = input("Ingresa el nombre de la nueva categoría: ")

    ruta_categoria = os.path.join(directorio_base, nombre_categoria)
    os.makedirs(ruta_categoria, exist_ok=True)

    print("Categoría creada exitosamente.")

def eliminar_informe(directorio_base):
    categorias = listar_categorias(directorio_base)
    categoria_elegida = seleccionar_opcion("Elige una categoría:", categorias)
    informes = listar_informes(os.path.join(directorio_base, categoria_elegida))
    informe_elegido = seleccionar_opcion("Elige un informe para eliminar:", informes)

    ruta_informe = os.path.join(directorio_base, categoria_elegida, informe_elegido)
    os.remove(ruta_informe)

    print("Informe eliminado exitosamente.")

def eliminar_categoria(directorio_base):
    categorias = listar_categorias(directorio_base)
    categoria_elegida = seleccionar_opcion("Elige una categoría para eliminar:", categorias)

    ruta_categoria = os.path.join(directorio_base, categoria_elegida)
    os.rmdir(ruta_categoria)

    print("Categoría eliminada exitosamente.")

def listar_categorias(directorio_base):
    return [d for d in os.listdir(directorio_base) if os.path.isdir(os.path.join(directorio_base, d))]

def listar_informes(ruta_categoria):
    return [f for f in os.listdir(ruta_categoria) if f.endswith('.txt')]

def seleccionar_opcion(mensaje, opciones):
    print(mensaje)
    for i, opcion in enumerate(opciones, 1):
        print(f"{i}. {opcion}")

    indice = int(input()) - 1
    return opciones[indice]

if __name__ == "__main__":
    main()
