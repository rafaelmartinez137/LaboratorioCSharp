# LaboratorioCSharp

Repositorio de ejercicios de laboratorio del curso de C#. Cada carpeta corresponde a un entregable desarrollado como aplicación de consola (.NET 10).

## Estructuras de datos avanzadas

| Proyecto | Tema | Contenido |
|---|---|---|
| `Entregable1_Calculadora` | Operaciones básicas | Suma, resta, multiplicación y división con validaciones |
| `Entregable2_Ordenamiento` | Listas y arreglos | Carga de números, ordenamiento, búsqueda y estadísticas |
| `Entregable3_GestionNombres` | `List<string>` | Alta, búsqueda y ordenamiento alfabético de nombres |
| `Entregable4_ColaAtencion` | `Queue<T>` (FIFO) | Registro, atención, pendientes y siguiente turno |
| `Entregable5_HistorialNavegacion` | `Stack<T>` (LIFO) | Visitar páginas, retroceder y ver historial |
| `Entregable6_DiccionarioProductos` | `Dictionary<int, Producto>` | Búsqueda por ID, stock, eliminación y stock bajo |

## Programación orientada a objetos

| Proyecto | Tema | Contenido |
|---|---|---|
| `Entregable7_SistemaEmpleados` | Herencia y sobrescritura | `Empleado`, `Developer`, `TeamLeader`, `Manager` con `CalcularBono()` y encapsulamiento |
| `Entregable8_Notificaciones` | Interfaces | `INotificador` implementado por `EmailNotificador`, `SmsNotificador` y `TeamsNotificador` |
| `Entregable9_DelegadosEventos` | Delegados y eventos | Evento `OrdenCreada`, suscriptores múltiples y delegado intercambiable |

## Ejecución

Cada proyecto se ejecuta de forma independiente:

```
dotnet run --project Entregable7_SistemaEmpleados
```
