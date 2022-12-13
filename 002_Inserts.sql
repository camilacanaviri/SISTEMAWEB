
--________________________________ INSERTAR Cargo ________________________________
insert into Cargo(descripcion,Estado) values
('Administrador',1),
('Empleado',1),
('Supervisor',1)


--________________________________ INSERTAR USUARIO ________________________________
SELECT * FROM Usuario
--clave : 123
insert into Usuario(nombre,correo,telefono,idCargo,urlFoto,nombreFoto,clave,Estado) values
('Fredy Daza','Fredy@example.com','78956321',1,'','','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',1)

--________________________________ RECURSOS DE FIREBASE_STORAGE Y CORREO ________________________________
-

insert into Configuracion(recurso,propiedad,valor) values
('FireBase_Storage','email',''),
('FireBase_Storage','clave',''),
('FireBase_Storage','ruta',''),
('FireBase_Storage','api_key',''),
('FireBase_Storage','carpeta_usuario','IMAGENES_USUARIO'),
('FireBase_Storage','carpeta_producto','IMAGENES_Servicio'),
('FireBase_Storage','carpeta_logo','IMAGENES_LOGO')

insert into Configuracion(recurso,propiedad,valor) values
('Servicio_Correo','correo',''),
('Servicio_Correo','clave',''),
('Servicio_Correo','alias','MiTallerMecanico.com'),
('Servicio_Correo','host','TmV.gmail.com'),
('Servicio_Correo','puerto','587')


--________________________________ INSERTAR empresa ________________________________
select * from Empresa

insert into Empresa(idEmpresa,urlLogo,nombreLogo,numeroDocumento,nombre,correo,direccion,telefono,porcentajeImpuesto,simboloMoneda)
values(1,'','','Taller mecanico Velmotor','','','','',0,'')


--________________________________ INSERTAR VEHICULO ________________________________
select * from Vehiculo

insert into Vehiculo(idPlaca,idCompra,idServicio,modelo,marca)
values(1,1,1,'Nissan','Navarra')

--________________________________ INSERTAR VEHICULO ________________________________
select * from Fichaje

insert into Fichaje(idFichaje,idPlaca,Cambio_kms,Fecha)
values(1,'4762Zui',78956,12/01/2022)


--________________________________ INSERTAR CATEGORIAS ________________________________
SELECT * FROM Categoria

INSERT INTO Categoria(descripcion,Estado) values
('MANTENIMIENTO GENERAL',1),
('MOTOR',1),
('SISTEMA DE DIRECCIÓN  ',1),
('SISTEMA DE SUSPENSIÓN',1),
('SISTEMA DE FRENOS',1),
('SISTEMA DE TRANSMISIÓN Y TRACCION',1),
('SISTEMA DE REFRIGERACIÓN',1),
('AIRE ACONDICIONADO Y SISTEMA ELÉCTRICO',1),
('CAMBIO DE REGLAJE DE CORREAS O CADENA',1),
('CARROCERÍA Y OTROS',1),
('SERVICIO DE AUXILIO MECÁNICO ',1)


--________________________________ INSERTAR TIPO DOCUMENTO VENTA ________________________________

select * from TipoDocumentoCompra

insert into TipoDocumentoCompra(descripcion,Estado) values
('Fichaje',1),
('Factura',1)
('Orden',1)


--________________________________ INSERTAR NUMERO CORRELATIVO ________________________________
select * from NumeroCorrelativo
--000001
insert into NumeroCorrelativo(ultimoNumero,cantidadDigitos,gestion,fechaActualizacion) values
(0,6,'compra',getdate())


--________________________________ INSERTAR MENUS ________________________________
select * from Menu

--*menu padre
insert into Menu(descripcion,icono,controlador,paginaAccion,Estado) values
('Velmotor','fas fa-fw fa-tachometer-alt','Velmotor','Index',1)

insert into Menu(descripcion,icono,	Estado) values
('Administración','fas fa-fw fa-cog',1),
('Inventario','fas fa-fw fa-clipboard-list',1),
('Compra','fas fa-fw fa-tags',1),
('Reportes','fas fa-fw fa-chart-area',1)


--*menu hijos Administracion
insert into Menu(descripcion,idMenuMayor, controlador,paginaAccion,esActivo) values
('Usuarios',2,'Usuario','Index',1),
('eMPRESA',2,'Empresa','Index',1)


--*menu hijos - Inventario
insert into Menu(descripcion,idMenuMayor, controlador,paginaAccion,esActivo) values
('Categorias',3,'Categoria','Index',1),
('Servicio',3,'Servicio','Index',1)

--*menu hijos - Ventas
insert into Menu(descripcion,idMenuMayor, controlador,paginaAccion,esActivo) values
('Nueva Compra',4,'Compra','NuevaCompra',1),
('Historial Compra',4,'Compra','HistorialCompra',1)

--*menu hijos - Reportes
insert into Menu(descripcion,idMenuMayor, controlador,paginaAccion,esActivo) values
('Reporte de Compra',5,'Reporte','Index',1)


UPDATE Menu SET idMenuMayor = idMenu where idMenuMayor is null


--________________________________ INSERTAR ROL MENU ________________________________
select * from Menu
select * from CargoMenu
SELECT * FROM Cargo

--*administrador
INSERT INTO CargoMenu(idCargo,idMenu,Estado) values
(1,1,1),
(1,6,1),
(1,7,1),
(1,8,1),
(1,9,1),
(1,10,1),
(1,11,1),
(1,12,1)

--*Empleado
INSERT INTO CargoMenu(idCargo,idMenu,Estado) values
(2,10,1),
(2,11,1)

--*Supervisor
INSERT INTO CargoMenu(idCargo,idMenu,Estado) values
(3,8,1),
(3,9,1),
(3,10,1),
(3,11,1)