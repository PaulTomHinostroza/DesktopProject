Create database ElAmigo
use ElAmigo
create table tblCargo
(
IdCargo		int IDENTITY (100,1) NOT NULL,
Nombre_Car	varchar(60) NOT NULL,
Descripcion_Car	varchar(500) NULL

constraint pk_IdCargo PRIMARY KEY (IdCargo)
)

create table tblCliente
(
IdCliente	int IDENTITY (100000,1) NOT NULL,
Nombres_Cli	varchar(60) NOT NULL,
Apellidos_Cli	varchar(100) NOT NULL,
DNI_Cli		varchar(20) NOT NULL,
Direccion_Cli	varchar(100) NOT NULL,
Telefono_Cli	varchar(20) NULL,
Genero_Cli		char(1) NOT NULL,
RUC_Cli			varchar(30) NULL,
FechaInscrip_Cli	datetime NOT NULL,
Email_Cli	varchar(50) NULL

constraint pk_IdCliente primary key (IdCliente)
)

create table tblProducto
(
IdProducto	int IDENTITY(10000000,1) NOT NULL,
Descripcion_Prod	varchar(200) NOT NULL

CONSTRAINT pk_IdProducto primary key(IdProducto)
)

create table tblProveedor
(
IdProveedor	int IDENTITY (1000,1) NOT NULL,
Nombre_Empresa_Prov varchar(100) NOT NULL,
Nombre_Contacto_Prov varchar(150) NOT NULL,
Celular_Contacto_Prov varchar(20) NOT NULL,
Direccion_Prov varchar(100) NULL,
Telefono_Prov varchar(20) NOT NULL,
Email_Prov varchar(50) NULL,
NroCuenta_Prov varchar(100) NULL

constraint pk_IdProveedor primary key(IdProveedor)
)

create table tblAlmacen
(
IdAlmacen	int Identity (100,1) NOT NULL,
Direccion_Alm	varchar(100) NOT NULL,
Telefono_Alm	varchar(20) NOT NULL,
Descripcion_Alm	varchar(500)	NULL,
Tipo_Alm		varchar(20)	NOT NULL

constraint pk_IdAlmacen primary key(IdAlmacen)
)

create table tblMedida
(
IdMedida	int IDENTITY (1000,1) NOT NULL,
Descripcion_Med	varchar(50) NOT NULL,
Abreviatura_Med	varchar(10) NOT NULL,
EquilvalenteEnUnidades	int NOT NULL

constraint pk_IdMedida primary key(IdMedida)
)

create table tblEmpleado
(
IdEmpleado	int IDENTITY (100000,1) NOT NULL,
Nombre_Emp	varchar(60) NOT NULL,
Apellidos_Emp	varchar(100) NOT NULL,
DNI_Emp		varchar(20) NOT NULL,
Direccion_Emp	varchar(100) NOT NULL,
Telefono_Emp	varchar(20) NULL,
Genero_Emp		char(1) NOT NULL,
Email_Emp	varchar(50) NULL,
FechaNac_Emp	date NOT NULL,
FechaIncrip_Emp	datetime NOT NULL,
IdCargo_Emp int NOT NULL,
Usuario_Emp	varchar(50)	NOT NULL,
Password_Emp varchar(100)	NOT NULL


constraint pk_IdEmpleado primary key (IdEmpleado),
constraint fk_IdCargo_Emp foreign key (IdCargo_Emp) references tblCargo(IdCargo)
)

create table tblVenta
(
NroVenta		int IDENTITY (8000,1) NOT NULL,
IdCliente_V		int NOT NULL,
IdEmpleado_V	int NOT NULL,
FechaEmision	datetime NOT NULL,
Serie			int NOT NULL,
TipoDocumento	varchar(50) NOT NULL,
TotalVenta		decimal(20,2) NOT NULL

constraint pk_NroVenta primary key (NroVenta),
constraint fk_IdCliente_v foreign key(IdCliente_V) references tblCliente(IdCliente),
constraint fk_IdEmpleado_V foreign key(IdEmpleado_V) references tblEmpleado(IdEmpleado),
)

create table tblDetalleVenta
(
NroVenta_DV		int NOT NULL,
IdProducto_DV	int NOT NULL,
IdMedida_DV		int NOT NULL,
Precio_DV		decimal (20,2) NOT NULL,
Cantidad_DV		decimal(20,2),

constraint fk_NroVenta_DV foreign key (NroVenta_DV) references tblVenta(NroVenta),
constraint fk_IdProducto_DV foreign key (IdProducto_DV) references tblProducto(IdProducto),
constraint fk_IdMedida_DV foreign key (IdMedida_DV) references tblMedida(IdMedida)
)

create table tblProductoProveedor
(
IdProducto_PP	int NOT NULL,
IdProveedor_PP	int NOT NULL,
Descripcion_PP	varchar(1000)

constraint fk_IdProducto_PP foreign key (IdProducto_PP) references tblProducto(IdProducto),
constraint fk_IdProveedor_PP foreign key (IdProveedor_PP) references tblProveedor(IdProveedor)
)

create table tblPrecio
(
IdMedida_P		int NOT NULL,
IdProducto_P	int NOT NULL,
Precio			decimal(20,2) NOT NULL,

constraint fk_IdMedida_P foreign key (IdMedida_P) references tblMedida(IdMedida),
constraint fk_IdProducto_P foreign key (IdProducto_P) references tblProducto(IdProducto)
)

create table tblStock
(
IdProducto_St	int NOT NULL,
IdAlmacen_St	int NOT NULL,
IdMedida_St		int NOT NULL,
CantidadStock	decimal(20,2)

constraint fk_IdProducto_St foreign key(IdProducto_St) references tblProducto(IdProducto),
constraint fk_IdAlmacen_St foreign key(IdAlmacen_St) references tblAlmacen(IdAlmacen),
constraint fk_IdMedida_St foreign key(IdMedida_St) references tblMedida(IdMedida)
)