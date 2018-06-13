create proc usp_Stock_Insertar
	@parIdAlmacen_St	 int,
	@parIdProducto_St	 int,
	@parIdMedida_St		 int,
	@parCantidadStock	decimal(20,2)
as
if exists
(
	select IdAlmacen_St,IdProducto_St,IdMedida_St from tblStock where IdAlmacen_St=@parIdAlmacen_St and IdProducto_St=@parIdProducto_St
)
	begin
		raiserror('Dicho Stock Ya está Registrado.',16,1)
	end
else
	begin
		insert into	tblStock
		(
			 IdAlmacen_St, 
			 IdProducto_St, 
			 IdMedida_St,
			 CantidadStock
		)
		values
		(
			@parIdAlmacen_St,
			@parIdProducto_St,
			@parIdMedida_St,
			@parCantidadStock
		)
	end

--//////////////////////////////////////////////////
create proc usp_Stock_Listar_AlmCantMed
@parIdProducto	int
as
select IdProducto_St,Descripcion_Prod,IdAlmacen_St,Direccion_Alm,IdMedida_St,Descripcion_Med,CantidadStock
from tblStock inner join tblProducto
on tblStock.IdProducto_St=tblProducto.IdProducto
inner join tblAlmacen
on tblStock.IdAlmacen_St=tblAlmacen.IdAlmacen
inner join tblMedida
on tblStock.IdMedida_St=tblMedida.IdMedida
where IdProducto_St=@parIdProducto

--//////////////////////////////////////////////////
create proc usp_Stock_Actualizar_Aniadir
@parIdProducto_St	int,
@parIdAlmacen_St	int,
@parEquivalencia	int,
@parCantidad		decimal
as
UPDATE tblStock
set 
CantidadStock = CantidadStock+(@parCantidad*@parEquivalencia)
where IdProducto_St=@parIdProducto_St and IdAlmacen_St=@parIdAlmacen_St

--////////////////////////////////////////////////////////////////////

create proc usp_Stock_Actualizar_Quitar
@parIdProducto_St	int,
@parIdAlmacen_St	int,
@parEquivalencia	int,
@parCantidad		decimal
as
if exists
(
	select IdProducto_St,CantidadStock,IdAlmacen_St from tblStock 
	where IdAlmacen_St=@parIdAlmacen_St and IdProducto_St=@parIdProducto_St
	and CantidadStock<@parCantidad*@parEquivalencia
)
	begin
		raiserror('No hay suficientes productos para realizar dicha venta',16,1)
	end
else
	begin
		UPDATE tblStock
		set 
		CantidadStock = CantidadStock-(@parCantidad*@parEquivalencia)
		where IdProducto_St=@parIdProducto_St and IdAlmacen_St=@parIdAlmacen_St
	end