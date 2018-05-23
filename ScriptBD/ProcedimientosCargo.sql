create proc usp_Cargo_Insertar
	@parNombre_Car varchar(60),
	@parDescripcion_Car varchar(500)
as
if exists
(
	select Nombre_Car from tblCargo where Nombre_Car=@parNombre_Car
)
	begin
		raiserror('El cargo ya está registrado.',16,1)
	end
else
	begin
		insert into	tblCargo
		(
			 Nombre_Car, 
			 Descripcion_Car
		)
		values
		(
			@parNombre_Car,
			@parDescripcion_Car
		)
	end

--////////////////////////////////////////////////
create proc usp_Cargo_ListarPorNombre
@parNombre_Car	varchar(60)
as
select IdCargo,Nombre_Car,Descripcion_Car
 from tblCargo
 where Nombre_Car like '%' + @parNombre_Car + '%' 
 order by Nombre_Car

--////////////////////////////////////////////////////

create proc usp_Cargo_ListarPorId
@parIdCargo int
as
select IdCargo,Nombre_Car,Descripcion_Car
 from tblCargo
 where IdCargo>=@parIdCargo
 order by IdCargo


 --///////////////////////////////////////////////////

create proc usp_Cargo_Listar_Todos
as
select IdCargo,Nombre_Car,Descripcion_Car
from tblCargo
order by Nombre_Car

--////////////////////////////////////////////////////
create proc usp_Cargo_Actualizar
@parIdCargo	int,
@parNUEVO_Nombre_Car varchar(60),
@parNUEVO_Descripcion_Car varchar(500)
as
if exists 
	(
		select Nombre_Car,IdCargo from tblCargo where Nombre_Car=@parNUEVO_Nombre_Car and IdCargo<>@parIdCargo
	)
	begin
		raiserror('El cargo ya está registrado.',16,1)
	end
else
	begin
		UPDATE tblCargo
		set
		Nombre_Car=@parNUEVO_Nombre_Car,
		Descripcion_Car=@parNUEVO_Descripcion_Car
		where IdCargo=@parIdCargo
	end