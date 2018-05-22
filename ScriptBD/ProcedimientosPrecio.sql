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

