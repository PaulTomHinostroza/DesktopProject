create proc usp_Venta_Insertar
	@parNroVenta          int,
	@parIdCliente_DV        int,
	@parIdEmpleado_DV         int,
	@parFechaEmision          datetime,
	@parSerie          int,
	@parTipoDocumento	varchar(50),
	@parTotalVenta		decimal(20,2)
as
insert into tblVenta
(
	NroVenta,
	IdCliente_V,
	IdEmpleado_V,
	FechaEmision,
	Serie,
	TipoDocumento,
	TotalVenta            
)
values
(
	@parNroVenta          ,
	@parIdCliente_DV        ,
	@parIdEmpleado_DV              ,
	@parFechaEmision        ,
	@parSerie         ,
	@parTipoDocumento            ,
	@parTotalVenta              
)