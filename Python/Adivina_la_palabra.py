import random

def seleccionar_palabra():
    palabras = ["lenguaje", "programacion", "juego", "desarrollo", "computadora"]
    return random.choice(palabras)

def mostrar_estado(palabra, letras_adivinadas):
    estado = ""
    for letra in palabra:
        if letra in letras_adivinadas:
            estado += letra
        else:
            estado += "_"
    return estado

def adivina_palabra():
    palabra_secreta = seleccionar_palabra()
    letras_adivinadas = set()
    vidas = 6

    print("¡Bienvenido al juego de adivinar palabras!")
    print("Adivina la palabra secreta letra por letra.")
    print(f"La palabra tiene {len(palabra_secreta)} letras.")
    
    while vidas > 0:
        estado_actual = mostrar_estado(palabra_secreta, letras_adivinadas)
        print("Palabra:", estado_actual)
        print(f"Vidas restantes: {vidas}")

        if "_" not in estado_actual:
            print("¡Felicidades!, ha encontrado la palabra correcta.")
            break

        letra = input("Ingresa una letra: ").lower()

        if letra in letras_adivinadas:
            print("Esta letra ya fue ingresada, intente nuevamente.")
            continue

        letras_adivinadas.add(letra)

        if letra in palabra_secreta:
            print("La letra se encuentra en la palabra.")
        else:
            vidas -= 1
            print("La letra no se encuentra en la palabra.")
        
    if vidas == 0:
        print(f"Utilizo todas las vidad que tenias, la palabra secreta era: {palabra_secreta}")

adivina_palabra()
