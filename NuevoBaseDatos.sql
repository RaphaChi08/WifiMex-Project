create database dbwifimex;
use dbwifimex;

create table proveedores
(
	idProveedores			char(10)			primary key,
	nomProveedor			varchar(50)			not null,
	RFC						varchar(13)			not null,
	Direccion				varchar(100)		not null,
	Telefono				char(10)			not null,
	Correo					varchar(100)		not null,
	fechaRegistro			varchar(30)			not null,
	Estatus					boolean				not null
);

create table productos
(
	codigoBarra				int(12)			primary key,
	nomProducto				varchar(50)			not null,
	fechaRegistro			varchar(30)			not null,
	idProveedores			char(10)			not null,
	Estatus					boolean				not null, 
	constraint fk_prov_prod foreign key (idProveedores) references proveedores(idProveedores)
);

create table clientes
(
	idCliente				char(10)			primary key,
	RFC						varchar(13)			not null,
	CURP					char(18)			not null,
	nomCliente				varchar(50)			not null,
	Direccion				varchar(100)		not null,
	Telefono				char(10)			not null,
	Correo					varchar(100) 		not null,
	Estatus					boolean				not null
);

create table contratos
(
	idContrato				char(10)			primary key,
	precioServicio			double(5,2)			not null,
	inicioContrato			varchar(30)			not null,
	finContrato				varchar(30) 		not null,
	idCliente				char(10) 			not null,
	Estatus					boolean				not null,
    constraint fk_cont_client foreign key (idCliente) references clientes(idCliente)
);

create table empleados
(
	idEmpleado				char(10)			primary key,
	nomEmpleados			varchar(50)			not null,
	RFC						varchar(13)			not null,
	CURP					char(18)			not null,
	Edad					int(3) 				not null,
	Direccion				varchar(100) 		not null,
	Telefono				char(10)			not null,
	Correo					varchar(100)		not null,
	fechaContratacion		varchar(30) 		not null,
	Rol						varchar(30)			not null,			
	Estatus					boolean				not null
);

create table instalaciones
(
	idInstalacion			char(10)			primary key,		
	fechaInstalacion		double(5,2)			not null,
	idEmpleado				char(10)			not null,
	idContrato				char(10)			not null,
	Estatus					boolean				not null,
    constraint fk_cont_empl foreign key (idEmpleado) references empleados(idEmpleado),
    constraint fk_cont_cont foreign key (idContrato) references contratos(idContrato)
);

create table almacen 
(
	idAlmacen				char(10)			primary key,
	cantProducto			int(3)				not null,
	codigoBarra				int(12)				not null,			
	idEmpleado				char(10)			not null,
	Estatus					boolean				not null,
    constraint fk_prod_alm foreign key (codigoBarra) references productos(codigoBarra),
    constraint fk_empl_alm foreign key (idEmpleado) references empleados(idEmpleado)
);