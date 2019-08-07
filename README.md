### INICIAR REPOSITORIO
```
git clone https://github.com/spk27/biblioteca.git
```
### El directorio raiz se llama 'biblioteca'

## SERVIDOR

#### Ir al subdirectorio biblioteca/servidor y ejecutar en consola:
```
dotnet restore
```

#### Ir al archivo biblioteca/servidor/appsettings.json y configurar la base de datos local en la seccion 'ConnectionStrings' -> 'DefaultConn'. Ej:
```
"ConnectionStrings": {
    "DefaultConn": "Server=desktop-jmo9g3m\\SQLEXPRESS;Database=biblioteca;Trusted_Connection=True;MultipleActiveResultSets=true"
  },

```

#### Ejecutar los siguientes comandos de migracion para crear la Base de datos, esquemas y tablas. (SQL Server)
```
dotnet ef database update --context AppUserContext
```
```
dotnet ef database update --context LibraryContext
```

#### Compilar y ejecuta el servidor bajo localhost:5000
```
dotnet run
```

#### Ó

```
Presiona f5 bajo la configuracion VSCODE
```

## CLIENTE

#### Ir al subdirectorio biblioteca/cliente y ejecutar en consola:
```
npm install
```

#### Compilar y ejecuta el cliente bajo localhost:8081
```
npm run serve
```

## NOTAS

#### 1) He dejado una coleccion de PostMan bajo el nombre de 'BlueSoft-Biblioteca.postman_collection'
##### Posee dos variables Globales:
```
url: http://localhost:5000/api/
```
```
token: ey... (token de acceso proporcionado en la llamada 'auth/login')
```
#### 2) Lo comandos de migración bastan, sin embargo he dejado un backup de la Base de datos bajo el nombre de 'biblioteca.bak'

#### 3) Una vez ejecutado el cliente, éste debe escuchar bajo 'localhost:8081', sin embargo he dejado unos captures de pantalla como muestra de la interfaz

#### 4) El requerimiento mínimo para la contraseña es tener 6 dígitos y/o letras (puesto así adrede)