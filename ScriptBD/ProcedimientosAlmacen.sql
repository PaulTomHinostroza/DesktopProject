create proc usp_Almacen_Insertar
	@parDireccion_Alm          varchar(100),
	@parTelefono_Alm        varchar(20),
	@parDescripcion_Alm		varchar(500),
	@parTipo_Alm			varchar(20)
as
if exists
(
	select IdAlmacen,Tipo_Alm from tblAlmacen where Tipo_Alm='PRINCIPAL' and @parTipo_Alm='PRINCIPAL'
)
	begin
		raiserror('El tipo "Principal" de almacen ya està registrado.',16,1)
	end
else
	begin
		insert into tblAlmacen
		(
			Direccion_Alm,
			Telefono_Alm,
			Descripcion_Alm,
			Tipo_Alm       
		)
		values
		(
			@parDireccion_Alm,
			@parTelefono_Alm,
			@parDescripcion_Alm,
			@parTipo_Alm
		)
	end


--///////////////////////////////////////////////////////////////

create proc usp_Almacen_Listar_Todos
as
select IdAlmacen,Direccion_Alm,Telefono_Alm,Descripcion_Alm,Tipo_Alm
from tblAlmacen
order by IdAlmacen

--////////////////////////////////////////////////////////////

create proc usp_Almacen_ListarPorDireccion
@parDireccion_Alm	varchar(200)
as
select IdAlmacen,Direccion_Alm,Telefono_Alm,Descripcion_Alm,Tipo_Alm
from tblAlmacen
where Direccion_Alm like '%' + @parDireccion_Alm + '%' 
order by Direccion_Alm

 --/////////////////////////////////////////////////////

create proc usp_Almacen_ListarPorId
@parIdAlmacen int
as
select IdAlmacen,Direccion_Alm,Telefono_Alm,Descripcion_Alm,Tipo_Alm
from tblAlmacen
where IdAlmacen>=@parIdAlmacen
order by IdAlmacen

--/////////////////////////////////////////////////////

create proc usp_Almacen_Actualizar
@parIdAlmacen	int,
@parNUEVO_Direccion_Alm        varchar(100),
@parNUEVO_Telefono_Alm         varchar(20),
@parNUEVO_Descripcion_Alm         varchar(500),
@parNUEVO_Tipo_Alm         varchar(20)
as
if exists
(
	select IdAlmacen,Tipo_Alm from tblAlmacen where Tipo_Alm='PRINCIPAL' and @parNUEVO_Tipo_Alm='PRINCIPAL' and IdAlmacen<>@parIdAlmacen
)
	begin
		raiserror('El tipo "Principal" de almacen ya està registrado.',16,1)
	end
else
	begin
	UPDATE tblAlmacen
	set
	Direccion_Alm=@parNUEVO_Direccion_Alm,
	Telefono_Alm=@parNUEVO_Telefono_Alm,
	Descripcion_Alm=@parNUEVO_Descripcion_Alm,
	Tipo_Alm=@parNUEVO_Tipo_Alm
	where IdAlmacen=@parIdAlmacen
	end
