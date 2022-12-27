# ServicesAPIWatchLogs
Back-End Api WatchLogs donde podrás visualizar los distintos logs de tu aplicación en AspNet Cord usando la librería WatchDog.
Para dicho Backend se uso el SDK .NET 6.0, Micro-ORM Dapper, Entity-Framework, OpenApi, Jwt y SQL SERVER 2018.

Paso # 1
Crear las tablas a continuación: 

Users
WatchDog_Https
WatchDog_Logs
WatchDog_Status
WatchDog_WatchExceptionLog
WatchDog_WatchLog

Paso #2
Crear el Stored Procedures:

UsersGetByUserAndPassword


Paso #3 
Instalar swagger en la capa de servicio.

Paso #4
Configurar OpenApi.

Paso #5 
Configurar la BD donde estarán alojada las distintas tablas y stored procedure. 
Nota: Se realizó en el appsettings.json en la capa de servicio.

Esta pequeña aplicación nos permite hacer uso de los distintos HTTP-CRUD SQL SERVER, usar la injection de dependencia en .net core, usar el JWT con un tiempo de expiración y hacer unit test.

Cabe destacar que esto sirve de mucha ayuda cuando configuras tu Back-end, para que puedas interceptar la data rapidamente y ubicar el  error o si fue satisfactoria la consulta etc.




