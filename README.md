# Agenda de Contactos

Aplicación web desarrollada con ASP.NET Core para gestionar una agenda de contactos mediante operaciones CRUD. El proyecto utiliza Entity Framework Core con SQLite como base de datos y Docker para su ejecución en contenedores.

## Tecnologías utilizadas

- C#
- ASP.NET Core
- Entity Framework Core
- SQLite
- Swagger
- Docker
- Docker Compose
- Git y GitHub

## Funcionalidades

La aplicación permite:

- Registrar contactos.
- Consultar todos los contactos.
- Consultar un contacto por su ID.
- Editar contactos.
- Eliminar contactos.
- Buscar contactos por nombre o apellido.
- Almacenar la información en una base de datos SQLite.

### Datos del contacto

Cada contacto contiene:

- Nombre
- Apellido
- Teléfono
- Correo electrónico
- Empresa

## Estructura del proyecto

```text
ActividadAutoaprendizaje/
│
├── Controllers/
│   └── ContactosController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│
├── Models/
│   └── Contacto.cs
│
├── Properties/
│
├── Dockerfile
├── compose.yaml
├── Program.cs
├── appsettings.json
├── ActividadAutoaprendizaje.csproj
└── README.md
```

## Ejecución local

### Requisitos

- .NET SDK 10.0
- Visual Studio
- SQLite

### Pasos

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/BrisaCriales/ActividadAutoaprendizaje---6to---TA.git
   ```

2. Entrar a la carpeta del proyecto:

   ```bash
   cd ActividadAutoaprendizaje
   ```

3. Ejecutar la aplicación:

   ```bash
   dotnet run
   ```

4. Abrir Swagger desde la dirección HTTPS indicada por Visual Studio, por ejemplo:

   ```
   https://localhost:7178/swagger
   ```

## Ejecución con Docker

### Requisitos

- Docker Desktop
- Docker Compose

### Ejecutar el proyecto

Desde la carpeta donde se encuentran `Dockerfile` y `compose.yaml`:

```bash
docker compose up --build
```

La aplicación quedará disponible en:

```
http://localhost:8080/swagger
```

### Detener el contenedor

Presionar:

```
Ctrl + C
```

## Persistencia de datos

La aplicación utiliza un volumen de Docker llamado `agenda_data`, que se monta en:

```
/app/data
```

La base de datos SQLite se almacena como:

```
/app/data/contactos.db
```

Esto permite conservar los datos aunque el contenedor sea detenido.

## Endpoints principales

| Método | Endpoint                                | Descripción                        |
|--------|------------------------------------------|-------------------------------------|
| GET    | `/api/Contactos`                         | Obtener todos los contactos         |
| GET    | `/api/Contactos/{id}`                    | Obtener un contacto por ID          |
| GET    | `/api/Contactos/buscar?texto=ana`        | Buscar por nombre o apellido        |
| POST   | `/api/Contactos`                         | Crear un contacto                   |
| PUT    | `/api/Contactos/{id}`                    | Editar un contacto                  |
| DELETE | `/api/Contactos/{id}`                    | Eliminar un contacto                |

## Docker

El proyecto utiliza un `Dockerfile` con dos etapas:

- **Build:** utiliza el SDK de .NET para restaurar dependencias y publicar la aplicación.
- **Runtime:** utiliza la imagen de ASP.NET Core para ejecutar la aplicación.

Docker Compose permite construir y ejecutar el contenedor junto con el volumen utilizado para la base de datos.

## Evidencias

### Swagger

La aplicación puede probarse mediante Swagger utilizando:

```
http://localhost:8080/swagger
```

Desde Swagger se pueden probar las operaciones CRUD y la búsqueda de contactos.

### Docker

El contenedor puede verificarse mediante:

```bash
docker ps
```

## Autor

**Brisa Criales**

Proyecto de autoaprendizaje - Agenda de Contactos con ASP.NET Core y Docker.
