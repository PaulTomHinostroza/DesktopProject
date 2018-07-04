create proc usp_Cliente_Insertar
	@parNombres_Cli          varchar(60),
	@parApellidos_Cli        varchar(100),
	@parDNI_Cli              varchar(20),
	@parDireccion_Cli        varchar(100),
	@parTelefono_Cli         varchar(20),
	@parGenero_Cli           char(1) ,
	@parRUC_Cli              varchar(30),
	@parEmail_Cli            varchar(50)
as
insert into tblCliente
(
	Nombres_Cli          ,
	Apellidos_Cli        ,
	DNI_Cli              ,
	Direccion_Cli        ,
	Telefono_Cli         ,
	Genero_Cli            ,
	RUC_Cli              ,
	FechaInscrip_Cli	,
	Email_Cli            
)
values
(
	@parNombres_Cli          ,
	@parApellidos_Cli        ,
	@parDNI_Cli              ,
	@parDireccion_Cli        ,
	@parTelefono_Cli         ,
	@parGenero_Cli            ,
	@parRUC_Cli              ,
	GETDATE()				,
	@parEmail_Cli 
)

if exists
(
	select DNI_Cli from tblCliente where DNI_Cli=@parDNI_Cli
)
	begin
		raiserror('El DNI ya está registrado.',16,1)
	end
else
	begin
		insert into	tblCliente
		(
			Nombres_Cli          ,
			Apellidos_Cli        ,
			DNI_Cli              ,
			Direccion_Cli        ,
			Telefono_Cli         ,
			Genero_Cli            ,
			RUC_Cli              ,
			FechaInscrip_Cli	,
			Email_Cli
		)
		values
		(
			@parNombres_Cli          ,
			@parApellidos_Cli        ,
			@parDNI_Cli              ,
			@parDireccion_Cli        ,
			@parTelefono_Cli         ,
			@parGenero_Cli            ,
			@parRUC_Cli              ,
			GETDATE()				,
			@parEmail_Cli 
		)
	end
--///////////////////////////////////////////////////////////////////

create proc usp_Cliente_Listar_Todos
as
select IdCliente,Nombres_Cli,Apellidos_Cli,DNI_Cli,Direccion_Cli,
		Telefono_Cli,Genero_Cli,RUC_Cli,FechaInscrip_Cli,Email_Cli
from tblCliente

--///////////////////////////////////////////////////////////////////

create proc usp_Cliente_ListarPorNombre
@parNombres_Cli	varchar(200)
as
select IdCliente,Nombres_Cli,Apellidos_Cli,DNI_Cli,Direccion_Cli,
		Telefono_Cli,Genero_Cli,RUC_Cli,FechaInscrip_Cli,Email_Cli
from tblCliente
where Nombres_Cli like '%' + @parNombres_Cli + '%'
order by Nombres_Cli

--////////////////////////////////////////////////////////

create proc usp_Cliente_ListarPorApellido
@parApellidos_Cli	varchar(200)
as
select IdCliente,Nombres_Cli,Apellidos_Cli,DNI_Cli,Direccion_Cli,
		Telefono_Cli,Genero_Cli,RUC_Cli,FechaInscrip_Cli,Email_Cli
from tblCliente
where Apellidos_Cli like '%' + @parApellidos_Cli + '%'
order by Nombres_Cli

--//////////////////////////////////////////////////////////

create proc usp_Cliente_ListarPorId
@parIdCliente int
as
select IdCliente,Nombres_Cli,Apellidos_Cli,DNI_Cli,Direccion_Cli,
		Telefono_Cli,Genero_Cli,RUC_Cli,FechaInscrip_Cli,Email_Cli
from tblCliente
where IdCliente>=@parIdCliente
order by Nombres_Cli

--///////////////////////////////////////////////////////////

create proc usp_Cliente_ListarPorDNI
@parDNI_Cli	varchar(200)
as
select IdCliente,Nombres_Cli,Apellidos_Cli,DNI_Cli,Direccion_Cli,
		Telefono_Cli,Genero_Cli,RUC_Cli,FechaInscrip_Cli,Email_Cli
from tblCliente
where DNI_Cli like '%' + @parDNI_Cli + '%'
order by Nombres_Cli

--//////////////////////////////////////////////////////////////////

create proc usp_Cliente_Actualizar
@parIdCliente			int,
@parNUEVO_Nombres_Cli          varchar(60),
@parNUEVO_Apellidos_Cli        varchar(100),
@parNUEVO_DNI_Cli              varchar(20),
@parNUEVO_Direccion_Cli        varchar(100),
@parNUEVO_Telefono_Cli         varchar(20),
@parNUEVO_Genero_Cli           char(1) ,
@parNUEVO_RUC_Cli              varchar(30),
@parNUEVO_Email_Cli            varchar(50)
as
if exists
(
	select DNI_Cli,IdCliente from tblCliente where DNI_Cli=@parNUEVO_DNI_Cli and IdCliente<>@parIdCliente
)
	begin
		raiserror('El DNI ya está registrado.',16,1)
	end
else
	begin
		UPDATE tblCliente
		set
		Nombres_Cli		=@parNUEVO_Nombres_Cli,
		Apellidos_Cli	=@parNUEVO_Apellidos_Cli      ,
		DNI_Cli			=@parNUEVO_DNI_Cli     ,
		Direccion_Cli	=@parNUEVO_Direccion_Cli    ,
		Telefono_Cli	=@parNUEVO_Telefono_Cli   ,
		Genero_Cli		=@parNUEVO_Genero_Cli   ,
		RUC_Cli		=@parNUEVO_RUC_Cli   ,
		Email_Cli	=@parNUEVO_Email_Cli
		where IdCliente=@parIdCliente
	end

--///////////////////////////////////////////////////////////////////

create proc usp_Cliente_Listar_Entre_FechasRegistro
@parFechaDeRegistroDesde DATE,
@parFechaDeRegistroHasta DATE
AS
SELECT IdCliente,Nombres_Cli,Apellidos_Cli,DNI_Cli,Direccion_Cli,
		Telefono_Cli,Genero_Cli,RUC_Cli,FechaInscrip_Cli,Email_Cli
FROM tblCliente 
WHERE FechaInscrip_Cli BETWEEN @parFechaDeRegistroDesde AND @parFechaDeRegistroHasta
ORDER BY FechaInscrip_Cli  