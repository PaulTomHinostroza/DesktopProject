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
--///////////////////////////////////////////////////////////////////////////////////////////

create proc usp_Cliente_Listar_Todos
as
select IdCliente,Nombres_Cli,Apellidos_Cli,DNI_Cli,Direccion_Cli,Telefono_Cli,Genero_Cli,RUC_Cli,FechaInscrip_Cli,Email_Cli
from tblCliente

--///////////////////////////////////////////////////////////////////////////////////////////