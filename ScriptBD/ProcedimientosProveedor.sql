create proc usp_Proveedor_Insertar
	@parNombre_Empresa_Prov          varchar(100),
	@parNombre_Contacto_Prov	varchar(150),
	@parCelular_Contacto_Prov   varchar(20),
	@parDireccion_Prov        varchar(100),
	@parTelefono_Prov         varchar(20),
	@parEmail_Prov			varchar(50),
	@parNroCuenta_Prov		varchar(100)
as
insert into tblProveedor
(
	Nombre_Empresa_Prov,
	Nombre_Contacto_Prov,
	Celular_Contacto_Prov,
	Direccion_Prov,
	Telefono_Prov,
	Email_Prov,
	NroCuenta_Prov           
)
values
(
	@parNombre_Empresa_Prov,
	@parNombre_Contacto_Prov,
	@parCelular_Contacto_Prov,
	@parDireccion_Prov,
	@parTelefono_Prov,
	@parEmail_Prov,
	@parNroCuenta_Prov
)

--///////////////////////////////////////////////////////////////

create proc usp_Proveedor_Listar_Todos
as
select IdProveedor,Nombre_Empresa_Prov,Nombre_Contacto_Prov,Celular_Contacto_Prov,Direccion_Prov,Telefono_Prov,Email_Prov,NroCuenta_Prov
from tblProveedor
order by Nombre_Empresa_Prov

--////////////////////////////////////////////////////////////

create proc usp_Proveedor_ListarPorNombre
@parNombre_Prov	varchar(200)
as
select IdProveedor,Nombre_Empresa_Prov,Nombre_Contacto_Prov,Celular_Contacto_Prov,Direccion_Prov,Telefono_Prov,Email_Prov,NroCuenta_Prov
from tblProveedor
where Nombre_Empresa_Prov like '%' + @parNombre_Prov + '%' 
order by Nombre_Empresa_Prov

 --/////////////////////////////////////////////////////

create proc usp_Proveedor_ListarPorId
@parIdProveedor int
as
select IdProveedor,Nombre_Empresa_Prov,Nombre_Contacto_Prov,Celular_Contacto_Prov,Direccion_Prov,Telefono_Prov,Email_Prov,NroCuenta_Prov
from tblProveedor
where IdProveedor>=@parIdProveedor
order by IdProveedor

--/////////////////////////////////////////////////////

create proc usp_Proveedor_Actualizar
@parIdProveedor	int,
@parNUEVO_Nombre_Empresa_Prov          varchar(100),
@parNUEVO_Nombre_Contacto_Prov		varchar(150),
@parNUEVO_Celular_Contacto_Prov		varchar(20),
@parNUEVO_Direccion_Prov        varchar(100),
@parNUEVO_Telefono_Prov         varchar(20),
@parNUEVO_Email_Prov			varchar(50),
@parNUEVO_NroCuenta_Prov		varchar(100)
as
UPDATE tblProveedor
set
Nombre_Empresa_Prov=@parNUEVO_Nombre_Empresa_Prov,
Nombre_Contacto_Prov=@parNUEVO_Nombre_Contacto_Prov,
Celular_Contacto_Prov=@parNUEVO_Celular_Contacto_Prov,
Direccion_Prov=@parNUEVO_Direccion_Prov,
Telefono_Prov=@parNUEVO_Telefono_Prov,
Email_Prov=@parNUEVO_Email_Prov,
NroCuenta_Prov=@parNUEVO_NroCuenta_Prov
where IdProveedor=@parIdProveedor