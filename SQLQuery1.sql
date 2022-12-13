
create database DBTallerMecanico

go

use DBCompraServicio
go

create table Menu(
idMenu int primary key identity(1,1),
descripcion varchar(30),
idMenuMayor int references Menu(idMenu),
icono varchar(30),
controlador varchar(30),
paginaAccion varchar(30),
Estado bit,
fechaRegistro datetime default getdate()
)

go

create table Cargo(
idCargo int primary key identity(1,1),
descripcion varchar(30),
Estado bit,
fechaRegistro datetime default getdate()
)

go
 
 create table CargoMenu(
 idCargoMenu int primary key identity(1,1),
 idCargo int references Cargo(idCargo),
 idMenu int references Menu(idMenu),
 Estado bit,
 fechaRegistro datetime default getdate()
 )

go

create table Usuario(
idUsuario int primary key identity(1,1),
nombre varchar(50),
correo varchar(50),
telefono varchar(50),
idRol int references Cargo(idCargo),
urlFoto varchar(500),
nombreFoto varchar(100),
clave varchar(100),
Estado bit,
fechaRegistro datetime default getdate()
)

go

create table Categoria(
idCategoria int primary key identity(1,1),
descripcion varchar(50),
Estado bit,
fechaRegistro datetime default getdate()
)

go

create table ServiciosGenerales(
idServicio int primary key identity(1,1),
descripcion varchar(100),
idCategoria int references Categoria(idCategoria),
Unidad int,
precio decimal(10,2),
Estado bit,
fechaRegistro datetime default getdate()
)

go

create table NumeroCorrelativo(
idNumeroCorrelativo int primary key identity(1,1),
ultimoNumero int,
cantidadDigitos int,
gestion varchar(100),
fechaActualizacion datetime
)

go

create table TipoDocumentoCompra(
idTipoDocumentoCompra int primary key identity(1,1),
descripcion varchar(50),
Estado bit,
fechaRegistro datetime default getdate()
)

go

create table CompraServicio(
idCompra int primary key identity(1,1),
numeroCompra varchar(6),
idTipoDocumentoCompra
int references TipoDocumentoCompra(idTipoDocumentoCompra),
idUsuario int references Usuario(idUsuario),
documentoCliente varchar(10),
nombreCliente varchar(20),
subTotal decimal(10,2),
Total decimal(10,2),
fechaRegistro datetime default getdate()
)

go

go

create table Vehiculo(
idPlaca varchar(50) primary key ,
idCompra int references CompraServicio(idCompra),
idServicio int,
Modelo varchar(100),
Marca varchar(100),

)

go
go

create table Fichaje(
idFichaje int primary key identity(1,1),
idPlaca varchar (50) references  Vehiculo(idPlaca),
cambio_Kms int,
Fecha datetime default getdate(),


)

go

create table DetalleCompra(
idDetalleCompra int primary key identity(1,1),
idCompra int references Compra(idCompra),
idServicio int,
descripcionServicio varchar(100),
categoriaServicio varchar(100),
cantidad int,
precio decimal(10,2),
total decimal(10,2)
)

go

create table Empresa(
idEmpresa int primary key,
urlLogo varchar(500),
nombreLogo varchar(100),
numeroDocumento varchar(50),
nombre varchar(50),
correo varchar(50),
direccion varchar(50),
telefono varchar(50),
simboloMoneda varchar(5)
)

go

create table Configuracion(
recurso varchar(50),
propiedad varchar(50),
valor varchar(60)
)


