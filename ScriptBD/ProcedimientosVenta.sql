create proc usp_Venta_Insertar
	@parIdVenta          int,
	@parIdCliente_DV        int,
	@parIdEmpleado_DV         int,
	@parFechaEmision          datetime,
	@parNroVenta		int,
	@parSerie          int,
	@parTipoDocumento	varchar(50),
	@parTotalVenta		decimal(20,2)
as
insert into tblVenta
(
	IdCliente_V,
	IdEmpleado_V,
	FechaEmision,
	NroVenta,
	Serie,
	TipoDocumento,
	TotalVenta            
)
values
(
	@parIdCliente_DV        ,
	@parIdEmpleado_DV              ,
	@parFechaEmision        ,
	@parIdVenta,
	@parSerie         ,
	@parTipoDocumento            ,
	@parTotalVenta              
)
--//////////////////////////////////////////
create proc sp_venta_generar_serie_numero_comprobante

@parTipoDocumento varchar(50)

as

select NroVenta,Serie
from tblVenta
where serie =(select Serie
				FROM tblVenta
				where TipoDocumento='FACTURA' 
				)