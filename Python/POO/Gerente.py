import Empleado

class Gerente(Empleado):
    def __init__(self, nombre, apellido, salario, departamento):
        super().__init__(nombre, apellido, salario)
        self.departamento = departamento

    def incrementar_salario(self, porcentaje):
        self.salario += self.salario * (porcentaje / 100)

# Crear una instancia de la clase Gerente
gerente = Gerente("Ana", "García", 5000, "Ventas")

# Incrementar el salario del gerente en un 10%
gerente.incrementar_salario(10)

# Mostrar el nuevo salario anual
print(f"El nuevo salario anual de {gerente.nombre} {gerente.apellido} es: {gerente.calcular_salario_anual()}")
