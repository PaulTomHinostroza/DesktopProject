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