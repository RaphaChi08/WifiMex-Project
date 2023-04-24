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
	codigoBarra				char(12)			primary key,
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
insert into clientes value ('CLI0000001','PGJR010907001','PAGJ010907HGTNRNA2','Juan Roman Pantoja Garica','Pintores #6','4451402013'
,'s20120160@alumnos.itsur.edu.mx',true);
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
insert into contratos value ('CON0000001',250.79,'27-03-2023','27-03-2025','CLI0000001',true);

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
    pas						varchar(200)		not null,
	Estatus					boolean				not null
);
insert into empleados value ('PGJP070901','Pantoja Garcia Juan Roman','PGJR010907001','PAGJ010907HGTNRNA2',22,
'Uriangato, Col. Emilinano Zapata, Pintores #6','4451075608','s20120160@alumnos.itsur.edu.mx','03-04-20023','Instalador',sha1('12345'),true);
create table instalaciones
(
	idInstalacion			char(10)			primary key,		
	fechaInstalacion		varchar(30)			not null,
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