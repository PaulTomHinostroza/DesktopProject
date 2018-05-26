create proc usp_Precio_Insertar
	@parIdMedida_P int,
	@parIdProducto_P int,
	@parPrecio	decimal(20,2)
as
if exists
(
	select IdMedida_P,IdProducto_P from tblPrecio where IdMedida_P=@parIdMedida_P and IdProducto_P=@parIdProducto_P
)
	begin
		raiserror('El precio del producto con dicha medida ya está registrada.',16,1)
	end
else
	begin
		insert into	tblPrecio
		(
			 IdMedida_P, 
			 IdProducto_P, 
			 Precio
		)
		values
		(
			@parIdMedida_P,
			@parIdProducto_P,
			@parPrecio
		)
	end

--/////////////////////////////////////////////////////////

create proc usp_Precio_Actualizar
	@parIdProducto_P int,
	@parIdMedida_P int,
	@parNUEVO_Precio	decimal(20,2)
as
UPDATE tblPrecio
set
Precio = @parNUEVO_Precio
where IdProducto_P=@parIdProducto_P and IdMedida_P=@parIdMedida_P

--/////////////////////////////////////////////////////////////////

create proc usp_Precio_Listar_ProductoMedida
@parIdProducto_P int,
@parDescripcion_Med varchar(200)
as
select IdProducto_P,Precio,Descripcion_Med,IdMedida
from tblPrecio inner join tblMedida
on tblPrecio.IdMedida_P=tblMedida.IdMedida
where IdProducto_P=@parIdProducto_P and Descripcion_Med=@parDescripcion_Med
