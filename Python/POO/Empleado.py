class Empleado:
    def __init__(self, nombre, apellido, salario):
        self.nombre = nombre
        self.apellido = apellido
        self.salario = salario

    def calcular_salario_anual(self):
        return self.salario * 12

    # Método getter para el salario
    def get_salario(self):
        return self.salario

    # Método setter para el salario
    def set_salario(self, nuevo_salario):
        if nuevo_salario > 0:
            self.salario = nuevo_salario
        else:
            print("El salario debe ser un valor positivo.")

# Crear una instancia de la clase Empleado
empleado = Empleado("Juan", "Pérez", 3000)

# Mostrar el salario anual
print(f"El salario anual de {empleado.nombre} {empleado.apellido} es: {empleado.calcular_salario_anual()}")

# Modificar el salario del empleado
empleado.set_salario(3500)

# Mostrar el nuevo salario anual
print(f"El nuevo salario anual de {empleado.nombre} {empleado.apellido} es: {empleado.calcular_salario_anual()}")


