# Sistema de Gestión de Productos

**Curso:** Programación II  
**Estudiante:** Kendall Campos  
**Proyecto:** Tarea_Programada_KendallCampos

## Descripción del sistema

Sistema de escritorio desarrollado en C# con Windows Forms para administrar las categorías y los productos de una tienda.

El programa permite registrar, consultar, modificar, eliminar y buscar información, utilizando una base de datos SQL Server.

## Tecnologías utilizadas

- C# y Windows Forms.
- Visual Studio 2022.
- .NET 8.
- Microsoft SQL Server.
- SQL Server Management Studio (SSMS).
- Microsoft.Data.SqlClient.

## Funcionalidades principales

**Gestión de categorías**
- Registrar categorías.
- Consultar las categorías existentes.
- Modificar categorías.
- Eliminar categorías con confirmación.
- Impedir la eliminación de categorías con productos asociados.

**Gestión de productos**
- Registrar, consultar, modificar y eliminar productos.
- Buscar productos por nombre.
- Asignar una categoría a cada producto.
- Mostrar los productos mediante un DataGridView.
- Calcular automáticamente el valor del inventario multiplicando el precio por el stock.
- Registrar automáticamente la fecha de creación.

El sistema utiliza ErrorProvider para señalar campos incorrectos y MessageBox para mostrar advertencias y confirmaciones.

## Base de datos

**Nombre:** BD_GestionProductos

La base de datos contiene dos tablas:

- Categorias: IdCategoria, Nombre y Descripcion.
- Productos: IdProducto, Nombre, Precio, Stock, FechaRegistro e IdCategoria.

Ambas tablas están relacionadas mediante el campo IdCategoria.

El archivo `BD_GestionProductos.sql` contiene el script de la base de datos y los registros de prueba.

## Requisitos para ejecutar el programa

- Windows.
- Visual Studio 2022 con soporte para desarrollo de escritorio con .NET.
- .NET 8.
- SQL Server.
- SQL Server Management Studio.
- Paquete NuGet Microsoft.Data.SqlClient.

## Instalación y ejecución

1. Descargar el proyecto y abrirlo en Visual Studio.
2. Crear la base de datos BD_GestionProductos en SQL Server, si todavía no existe.
3. Ejecutar el archivo BD_GestionProductos.sql para crear las tablas y cargar los datos, siguiendo las instrucciones del script.
4. Abrir `RepositorioSqlServer.cs`, ubicado en la carpeta Datos.
5. Comprobar que la cadena de conexión utilice el nombre correcto del servidor SQL Server y la base de datos BD_GestionProductos.
6. Compilar el proyecto y ejecutarlo con F5.

La conexión utilizada durante el desarrollo fue `localhost\SQLEXPRESS`, con autenticación de Windows. En otra computadora puede ser necesario cambiar el nombre del servidor.

## Organización del proyecto

- **Formularios:** interfaz de categorías y productos.
- **Modelos:** clases Categoria y Producto, con propiedades get y set.
- **Logica:** clase GestionServicio, encargada de las reglas y validaciones.
- **Datos:** interfaz IRepositorio y clases RepositorioSqlServer y RepositorioTemporal.
- **Program.cs:** punto de inicio de la aplicación.

El programa está configurado para utilizar RepositorioSqlServer y almacenar la información permanentemente.

## Pruebas realizadas

Se comprobó el funcionamiento de:

- Registro y consulta de categorías y productos.
- Modificación y eliminación de registros.
- Confirmación antes de eliminar.
- Búsqueda de productos.
- Validaciones con ErrorProvider.
- Cálculo del valor del inventario.
- Persistencia de los datos después de cerrar y volver a ejecutar el programa.
- Restricción que impide eliminar categorías con productos asociados.

## Uso de inteligencia artificial

Se utilizó ChatGPT de OpenAI como herramienta de apoyo para preparar la estructura inicial de los formularios, las clases, la lógica de programación, las validaciones y los ejemplos de código.

Posteriormente, se configuró la conexión con SQL Server, se integraron las operaciones con la base de datos y se realizaron pruebas del funcionamiento del programa en Visual Studio.

El uso de inteligencia artificial se declara de acuerdo con las indicaciones de la tarea. El código y su funcionamiento deberán ser comprendidos y explicados durante la defensa.