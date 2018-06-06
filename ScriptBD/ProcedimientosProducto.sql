create proc usp_Producto_Insertar
	@parDescripcion_Prod          varchar(200)
as
if exists 
	(
		select Descripcion_Prod from tblProducto where Descripcion_Prod=@parDescripcion_Prod
	)
	begin
		raiserror('El producto ya está registrado.',16,1)
	end
else
	begin
		insert into tblProducto
		(
			Descripcion_Prod         
		)
		values
		(
			@parDescripcion_Prod 
		)
	end

	

--///////////////////////////////////////////////////////////////////////////////////////////

create proc usp_Producto_Listar_Todos
as
select IdProducto,Descripcion_Prod
from tblProducto
order by Descripcion_Prod

--/////////////////////////////////////////////////////

create proc usp_Producto_ListarPorDescripcion
@parDescripcion_Prod	varchar(200)
as
select IdProducto,Descripcion_Prod
 from tblProducto
 where Descripcion_Prod like '%' + @parDescripcion_Prod + '%' 
 order by Descripcion_Prod

 --/////////////////////////////////////////////////////

create proc usp_Producto_ListarPorDescripcionVenta
@parDescripcion_Prod	varchar(200)
as
select IdAlmacen_St,IdProducto_St,Descripcion_Prod,Tipo_Alm,IdProducto
 from tblStock inner join tblProducto
 on tblStock.IdProducto_St=tblProducto.IdProducto
 inner join tblAlmacen
 on tblStock.IdAlmacen_St=tblAlmacen.IdAlmacen
 where Descripcion_Prod like '%' + @parDescripcion_Prod + '%' and Tipo_Alm='PRINCIPAL'
 order by Descripcion_Prod

 --/////////////////////////////////////////////////////

create proc usp_Producto_ListarPorId
@parIdProducto int
as
select IdProducto,Descripcion_Prod
 from tblProducto
 where IdProducto>=@parIdProducto
 order by IdProducto

 --///////////////////////////////////////////////////

create proc usp_Producto_ListarPorIdVenta
@parIdProducto int
as
select IdAlmacen_St,IdProducto_St,Tipo_Alm,IdProducto,Descripcion_Prod
 from tblStock inner join tblProducto
 on tblStock.IdProducto_St=tblProducto.IdProducto
 inner join tblAlmacen
 on tblStock.IdAlmacen_St=tblAlmacen.IdAlmacen
 where IdProducto>=@parIdProducto and Tipo_Alm='PRINCIPAL'
 order by Descripcion_Prod

 --///////////////////////////////////////////////////

create proc usp_Producto_Listar_MedidaPrecio
@parIdProducto	int
as
select IdProducto_P,Precio,Descripcion_Med,IdMedida_P
from tblPrecio inner join tblMedida
on tblPrecio.IdMedida_P=tblMedida.IdMedida
where IdProducto_P=@parIdProducto
order by Descripcion_Med

--//////////////////////////////////////////////////////

create proc usp_Producto_Actualizar
@parIdProducto	int,
@parNUEVO_Descripcion_Prod varchar(50)
as
if exists 
	(
		select Descripcion_Prod from tblProducto where Descripcion_Prod=@parNuevo_Descripcion_Prod
	)
	begin
		raiserror('El producto ya está registrado.',16,1)
	end
else
	begin
		UPDATE tblProducto
		set
		Descripcion_Prod = @parNUEVO_Descripcion_Prod
		where IdProducto=@parIdProducto
	end

--///////////////////////////////////////////////////////////

create proc usp_Producto_Eliminar
@parIdProducto int
as
delete
from tblProducto
where IdProducto=@parIdProducto

