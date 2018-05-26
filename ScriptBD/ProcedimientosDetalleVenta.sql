create proc usp_DetalleVenta_Insertar
	@parNroVenta_DV          int,
	@parIdProducto_DV        int,
	@parIdMedida_DV         int,
	@parCantidad		decimal(20,2)
as
insert into tblDetalleVenta
(
	NroVenta_DV,
	IdProducto_DV,
	IdMedida_DV,
	Precio_DV         
)
values
(
	@parNroVenta_DV          ,
	@parIdProducto_DV        ,
	@parIdMedida_DV              ,
	@parCantidad                  
)
