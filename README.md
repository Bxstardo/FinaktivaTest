# Finaktiva Test

## Creación de base de datos

Ir a SQL Server y ejecutar el siguiente script para la creación de base de datos 

```bash
go
create database FinaktivaTest
go

use FinaktivaTest

go

create table documentType 
(
idDocumentType int primary key identity(1,1),
name varchar(5),
isActive bit 
)


create table provider
(
idProvider int primary key identity(1,1),
name varchar(50),
isActive bit 
)

create table client 
(
idClient int primary key identity(1,1),
names varchar(50),
surnames varchar(50),
documentNumber varchar(12),
idDocumentType int,
businessName varchar(50),
salesLastYear money,
isActive bit 
)

create table clientProvider
(
idClientProvider int primary key identity(1,1),
idClient int,
idProvider int

constraint FK_ClientProvider_Provider
foreign key(idProvider)
references provider(idProvider),
constraint FK_ClientProvider_Client
foreign key(idClient)
references client(idClient)
)



insert into provider values
('Microsoft',1),
('Amazon',1),
('Google',1),
('Space X',1),
('Tesla',1)

insert into documentType values
('C.C',1),
('C.E',1)

go
create view vwClientProviders
as
select 
p.idProvider, 
p.name,
cp.idClient,
cp.idClientProvider
from clientProvider cp
inner join provider p on cp.idProvider = p.idProvider

go

create view vwClients
as 
select 
	c.*,
	stuff(
	(SELECT ', '  + p.name
    FROM provider p
	inner join clientProvider cp on cp.idProvider = p.idProvider
	where cp.idClient = c.idClient
	FOR XML PATH('')),1, 2, ''
	) as providers
from client c

```

## Cadena de conexión
Dirigirse al appsettings.json. Reemplaze y utilize la siguiente cadena de conexion reemplazando los valores del "User ID" y "Password" segun sus credenciales

```python
  "ConnectionStrings": {
    "FinaktivaDB": "Data Source=localhost;Initial Catalog=FinaktivaTest;Persist Security Info=True;User ID=sa;Password=*****;MultipleActiveResultSets=True;Application Name=EntityFramework"
  }
```

## Ejecutar
Seleccion el proyecto CustomerFinaktiva.Api como proyecto de inicio
![image](https://user-images.githubusercontent.com/54759003/155899456-82bec727-6719-439f-9ffe-959f13b3ed0a.png)

![image](https://user-images.githubusercontent.com/54759003/155899464-145fb99e-0a38-4b85-8d1c-1393ba4f4809.png)

Por ultimo ejecute el IIS Express
![image](https://user-images.githubusercontent.com/54759003/155899473-fb7649bf-9908-4eb4-8fd8-a9f133c965d8.png)

