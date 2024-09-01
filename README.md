# ToDoAPI

![iamge](https://github.com/user-attachments/assets/13b94e06-f8c7-4739-ac48-0be6db3acffc)

## Descripción

ToDoAPI es una API RESTful construida con .NET que proporciona un backend para una aplicación de lista de tareas (ToDo List). La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre las tareas. Este proyecto está diseñado para interactuar con una interfaz de usuario que permite a los usuarios gestionar sus tareas de manera eficiente.

## Funcionalidades

- **Crear una tarea:** Permite agregar una nueva tarea a la lista.
- **Leer tareas:** Obtiene la lista de tareas activas y completadas.
- **Actualizar una tarea:** Permite modificar los detalles de una tarea existente.
- **Eliminar una tarea:** Permite eliminar una tarea de la lista.

## Tecnologías Utilizadas

- **Backend:** .NET 8
- **Base de Datos:** Microsoft SQL Server
- **Otros:** Dapper

## Instalación

1. **Clona el repositorio:**

    ```bash
    git clone https://github.com/tu-usuario/ToDoAPI.git
    cd ToDoAPI
    ```

2. **Restaurar las dependencias del proyecto:**

    ```bash
    dotnet restore
    ```

3. **Configura la base de datos:**
   - Modifica el archivo `appsettings.json` para configurar la cadena de conexión a tu base de datos.
   - Ejecuta las migraciones para crear las tablas necesarias:


4. **Iniciar la aplicación:**

    ```bash
    dotnet run
    ```

5. **La API estará disponible en `http://localhost:5000`** (o en el puerto configurado en tu `launchSettings.json`).

## Uso

Puedes interactuar con la API utilizando herramientas como [Postman](https://www.postman.com/) o [curl](https://curl.se/). A continuación se muestran algunos ejemplos de las solicitudes disponibles:

- **Crear una tarea:**

    ```http
    POST /api/tasks
    Content-Type: application/json

    {
      "title": "Mi nueva tarea",
      "description": "Descripción de la tarea"
    }
    ```

- **Obtener todas las tareas activas:**

    ```http
    GET /api/tasks
    ```

- **Obtener una tarea específica:**

    ```http
    GET /api/tasks/{id}
    ```

- **Actualizar una tarea:**

    ```http
    PUT /api/tasks/{id}
    Content-Type: application/json

    {
      "title": "Título actualizado",
      "description": "Descripción actualizada"
    }
    ```

- **Eliminar una tarea:**

    ```http
    DELETE /api/tasks/{id}
    ```

## Notas

- Asegúrate de tener .NET 8 instalado en tu máquina para ejecutar el proyecto.

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

---

Si tienes alguna pregunta o necesitas más información, no dudes en abrir un issue en el repositorio.
