using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecursosHumanos;

namespace RecursosHumanos
{
    public class Menu
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Sistema de Recursos Humanos");
                Console.WriteLine("1. Agregar Empleado");
                Console.WriteLine("2. Consultar Empleados");
                Console.WriteLine("3. Modificar Empleado");
                Console.WriteLine("4. Borrar Empleado");
                Console.WriteLine("5. Inicializar Arreglos");
                Console.WriteLine("6. Reportes");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                switch (opcion)
                {
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        ConsultarEmpleados();
                        break;
                    case 3:
                        ModificarEmpleado();
                        break;
                    case 4:
                        BorrarEmpleado();
                        break;
                    case 5:
                        InicializarArreglos();
                        break;
                    case 6:
                        MostrarReportes();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción invalida, intente nuevamente.");
                        break;
                }

                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            } while (opcion != 7);
        }

        private void AgregarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("Agregar Empleado");

            Console.Write("Ingrese la cédula: ");
            string cedula = Console.ReadLine();
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese el numero de teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingrese el salario: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salario))
            {
                Console.WriteLine("Salario inválido.");
                return;
            }

            Empleado nuevoEmpleado = new Empleado(cedula, nombre, direccion, telefono, salario);
            empleados.Add(nuevoEmpleado);

            Console.WriteLine("Empleado agregado exitosamente.");
        }

        private void ConsultarEmpleados()
        {
            Console.Clear();
            Console.WriteLine("Consultar Empleados");

            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                foreach (Empleado emp in empleados)
                {
                    Console.WriteLine($"Cédula: {emp.Cedula}, Nombre: {emp.Nombre}, Dirección: {emp.Direccion}, Teléfono: {emp.Telefono}, Salario: {emp.Salario:C}");
                }
            }
        }

        private void ModificarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("Modificar Empleado");

            Console.Write("Ingrese la cédula del empleado que desea modificar: ");
            string cedula = Console.ReadLine();
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);

            if (empleado != null)
            {
                Console.Write("Ingrese el nuevo nombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.Write("Ingrese la nueva dirección: ");
                empleado.Direccion = Console.ReadLine();
                Console.Write("Ingrese el nuevo teléfono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Ingrese nuevo salario: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal nuevoSalario))
                {
                    Console.WriteLine("Salario inválido.");
                    return;
                }
                empleado.Salario = nuevoSalario;

                Console.WriteLine("El empleado ha sido modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        private void BorrarEmpleado()
        {
            Console.Clear();
            Console.WriteLine("Borrar Empleado");

            Console.Write("Ingrese la cédula del empleado que desea eliminar: ");
            string cedula = Console.ReadLine();
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);

            if (empleado != null)
            {
                empleados.Remove(empleado);
                Console.WriteLine("Empleado borrado exitosamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        private void InicializarArreglos()
        {
            empleados = new List<Empleado>();
            Console.WriteLine("Arreglo de empleados inicializado.");
        }

        private void MostrarReportes()
        {
            int opcion;
            Console.Clear();
            Console.WriteLine("Reportes");
            Console.WriteLine("1. Listar empleados ordenados por nombre");
            Console.WriteLine("2. Calcular el promedio de salarios");
            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion)) return;

            switch (opcion)
            {
                case 1:
                    ListarEmpleadosPorNombre();
                    break;
                case 2:
                    CalcularPromedioSalarios();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void ListarEmpleadosPorNombre()
        {
            Console.Clear();
            Console.WriteLine("Listado de Empleados Ordenados por Nombre");
            var empleadosOrdenados = empleados.OrderBy(e => e.Nombre).ToList();

            foreach (Empleado emp in empleadosOrdenados)
            {
                Console.WriteLine($"Cédula: {emp.Cedula}, Nombre: {emp.Nombre}, Dirección: {emp.Direccion}, Teléfono: {emp.Telefono}, Salario: {emp.Salario:C}");
            }
        }

        private void CalcularPromedioSalarios()
        {
            Console.Clear();
            Console.WriteLine("Calcular Promedio de Salarios");
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                decimal promedio = empleados.Average(e => e.Salario);
                Console.WriteLine($"El promedio de los salarios es: {promedio:C}");
            }
        }
    }
}