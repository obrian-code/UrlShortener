# UrlShortener

Un servicio simple para acortar URLs en .NET. Este proyecto permite a los usuarios enviar una URL original y recibir una versión más corta que redirige al enlace original cuando se accede a través de un navegador.
Características

    Acortar URL: Envía una URL original y obtiene una versión más corta.
    Redirección: Al acceder a la URL acortada, se redirige al enlace original.
    Generación de IDs únicos: Cada URL acortada se asigna un identificador único basado en un GUID truncado.
    API RESTful: El servicio está basado en un controlador API que recibe y responde a solicitudes HTTP.

Tecnologías utilizadas

    .NET 8: Framework de desarrollo.
    ASP.NET Core: Para crear la API RESTful.
    Swagger: Para generar y documentar la API (solo en desarrollo).
    CORS: Soporte para solicitudes desde diferentes orígenes.

Cómo usar

    Clona el repositorio: git clone https://github.com/obrian-code/UrlShortener.git

Instalar dependencias:

    dotnet restore

Ejecutar la aplicación:

    dotnet run

    Acceder a la API:
        Para acortar una URL, realiza una solicitud POST a https://localhost:5184/api/urls con el cuerpo que contenga la URL original.
        Para redirigir, realiza una solicitud GET a https://localhost:5184/api/urls/{id}, donde {id} es el identificador de la URL acortada.

Ejemplos de uso

    Acortar una URL:
        Método: POST
        URL: https://localhost:5184/api/urls
        Cuerpo: "https://www.ejemplo.com"

Respuesta:

        "https://localhost:5184/api/urls/{id}"

    Redirigir una URL:
        Método: GET
        URL: https://localhost:5184/api/urls/{id}
        Respuesta: Redirige al enlace original.

Notas

    Actualmente, las URL acortadas se almacenan en memoria (en un diccionario), por lo que los datos no se persisten entre reinicios de la aplicación. No se está utilizando base de datos en esta versión.
    Puedes expandir el proyecto para añadir persistencia en bases de datos como MySQL o PostgreSQL.
