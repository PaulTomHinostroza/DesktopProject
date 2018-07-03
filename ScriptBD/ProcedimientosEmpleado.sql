create proc usp_Empleado_Insertar
	@parNombres_Emp          varchar(60),
	@parApellidos_Emp        varchar(100),
	@parDNI_Emp              varchar(20),
	@parDireccion_Emp        varchar(100),
	@parTelefono_Emp         varchar(20),
	@parGenero_Emp           char(1) ,
	@parEmail_Emp            varchar(50),
	@parFechaNac_Emp		date,
	@parIdCargo_Emp			int,
	@parUsuario_Emp				varchar(50),
	@parPassword_Emp		varchar(100)
as
insert into tblEmpleado
(
	Nombre_Emp          ,
	Apellidos_Emp        ,
	DNI_Emp              ,
	Direccion_Emp        ,
	Telefono_Emp         ,
	Genero_Emp            ,
	Email_Emp            ,
	FechaNac_Emp		,
	FechaInscrip_Emp		,
	IdCargo_Emp         ,
	Usuario_Emp			,
	Password_Emp  
)
values
(
	@parNombres_Emp          ,
	@parApellidos_Emp        ,
	@parDNI_Emp              ,
	@parDireccion_Emp        ,
	@parTelefono_Emp         ,
	@parGenero_Emp            ,
	@parEmail_Emp			,
	@parFechaNac_Emp		,
	GETDATE()				,
	@parIdCargo_Emp			,
	@parUsuario_Emp		,
	@parPassword_Emp
)

--//////////////////////////////////////////////////////
create proc usp_Empleado_Listar_Todos
as 
select IdEmpleado,Nombre_Emp,Apellidos_Emp,DNI_Emp,Direccion_Emp,Telefono_Emp,Genero_Emp,
		Email_Emp,FechaNac_Emp,FechaInscrip_Emp,Nombre_Car,Usuario_Emp,Password_Emp
from tblEmpleado inner join tblCargo
on tblEmpleado.IdCargo_Emp=tblCargo.IdCargo
order by Nombre_Emp

--//////////////////////////////////////////////////////

create proc usp_Empleado_ListarPorNombre
@parNombre_Emp	varchar(200)
as
select IdEmpleado,Nombre_Emp,Apellidos_Emp,DNI_Emp,Direccion_Emp,Telefono_Emp,Genero_Emp,
		Email_Emp,FechaNac_Emp,FechaInscrip_Emp,Nombre_Car,Usuario_Emp,Password_Emp
from tblEmpleado inner join tblCargo
on tblEmpleado.IdCargo_Emp=tblCargo.IdCargo
where Nombre_Emp like '%' + @parNombre_Emp + '%'
order by Nombre_Emp

--////////////////////////////////////////////////////////

create proc usp_Empleado_ListarPorApellido
@parApellidos_Emp	varchar(200)
as
select IdEmpleado,Nombre_Emp,Apellidos_Emp,DNI_Emp,Direccion_Emp,Telefono_Emp,Genero_Emp,
		Email_Emp,FechaNac_Emp,FechaInscrip_Emp,Nombre_Car,Usuario_Emp,Password_Emp
from tblEmpleado inner join tblCargo
on tblEmpleado.IdCargo_Emp=tblCargo.IdCargo
where Apellidos_Emp like '%' + @parApellidos_Emp + '%'
order by Nombre_Emp

--//////////////////////////////////////////////////////////

create proc usp_Empleado_ListarPorId
@parIdEmpleado int
as
select IdEmpleado,Nombre_Emp,Apellidos_Emp,DNI_Emp,Direccion_Emp,Telefono_Emp,Genero_Emp,
		Email_Emp,FechaNac_Emp,FechaInscrip_Emp,Nombre_Car,Usuario_Emp,Password_Emp
from tblEmpleado inner join tblCargo
on tblEmpleado.IdCargo_Emp=tblCargo.IdCargo
where IdEmpleado>=@parIdEmpleado
order by Nombre_Emp

--///////////////////////////////////////////////////////////

create proc usp_Empleado_ListarPorDNI
@parDNI_Emp	varchar(200)
as
select IdEmpleado,Nombre_Emp,Apellidos_Emp,DNI_Emp,Direccion_Emp,Telefono_Emp,Genero_Emp,
		Email_Emp,FechaNac_Emp,FechaInscrip_Emp,Nombre_Car,Usuario_Emp,Password_Emp
from tblEmpleado inner join tblCargo
on tblEmpleado.IdCargo_Emp=tblCargo.IdCargo
where DNI_Emp like '%' + @parDNI_Emp + '%'
order by Nombre_Emp

--//////////////////////////////////////////////////////////////

create proc usp_Empleado_ListarPorCargo
@parCargo_Emp	varchar(200)
as
select IdEmpleado,Nombre_Emp,Apellidos_Emp,DNI_Emp,Direccion_Emp,Telefono_Emp,Genero_Emp,
		Email_Emp,FechaNac_Emp,FechaInscrip_Emp,Nombre_Car,Usuario_Emp,Password_Emp
from tblEmpleado inner join tblCargo
on tblEmpleado.IdCargo_Emp=tblCargo.IdCargo
where Nombre_Car like '%' + @parCargo_Emp + '%'
order by Nombre_Emp

--//////////////////////////////////////////////////////////////////

create proc usp_Empleado_Actualizar
@parIdEmpleado	int,
@parNUEVO_Nombres_Emp          varchar(60),
@parNUEVO_Apellidos_Emp        varchar(100),
@parNUEVO_DNI_Emp              varchar(20),
@parNUEVO_Direccion_Emp        varchar(100),
@parNUEVO_Telefono_Emp         varchar(20),
@parNUEVO_Genero_Emp           char(1) ,
@parNUEVO_Email_Emp            varchar(50),
@parNUEVO_FechaNac_Emp		date,
@parNUEVO_IdCargo_Emp			int,
@parNUEVO_Usuario_Emp				varchar(50),
@parNUEVO_Password_Emp		varchar(100)
as
UPDATE tblEmpleado
set
Nombre_Emp		=@parNUEVO_Nombres_Emp,
Apellidos_Emp	=@parNUEVO_Apellidos_Emp      ,
DNI_Emp			=@parNUEVO_DNI_Emp     ,
Direccion_Emp	=@parNUEVO_Direccion_Emp    ,
Telefono_Emp	=@parNUEVO_Telefono_Emp   ,
Genero_Emp		=@parNUEVO_Genero_Emp   ,
Email_Emp		=@parNUEVO_Email_Emp   ,
FechaNac_Emp	=@parNUEVO_FechaNac_Emp,
IdCargo_Emp		=@parNUEVO_IdCargo_Emp,
Usuario_Emp		=@parNUEVO_Usuario_Emp,
Password_Emp	=@parNUEVO_Password_Emp
where IdEmpleado=@parIdEmpleado

--/////////////////////////////////////////////////////////////
create proc usp_Usuario_Validacion
@parUsuario_Emp varchar(50), 
@parPassword_Emp varchar(100)
AS
select IdEmpleado,Nombre_Emp,Apellidos_Emp,DNI_Emp,Direccion_Emp,Telefono_Emp,Genero_Emp,
		Email_Emp,FechaNac_Emp,FechaInscrip_Emp,Nombre_Car,Usuario_Emp,Password_Emp
from tblEmpleado inner join tblCargo
on tblEmpleado.IdCargo_Emp=tblCargo.IdCargo
where	Usuario_Emp = @parUsuario_Emp AND Password_Emp = @parPassword_Emp 