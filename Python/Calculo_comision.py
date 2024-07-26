# Solicita el nombre del vendedor
nombre = input("Ingrese su nombre por favor: ")

# Solicita el total de ventas del mes
ventas_str = input("Ingresa el total de ventas del mes: ")

# Convierte la cadena de ventas a un número flotante
ventas_totales = float(ventas_str)

# Calcula la comisión (20% de las ventas totales)
comision = ventas_totales * 0.20

# Muestra el resultado
print(f"Hola {nombre}, sus comisiónes este mes son de: ${comision:.2f}")
