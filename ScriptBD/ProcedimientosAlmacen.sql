create proc usp_Almacen_Insertar
	@parDireccion_Alm          varchar(100),
	@parTelefono_Alm        varchar(20),
	@parDescripcion_Alm		varchar(500)
as
insert into tblAlmacen
(
	Direccion_Alm,
	Telefono_Alm,
	Descripcion_Alm        
)
values
(
	@parDireccion_Alm,
	@parTelefono_Alm,
	@parDescripcion_Alm
)

--///////////////////////////////////////////////////////////////

create proc usp_Almacen_Listar_Todos
as
select IdAlmacen,Direccion_Alm,Telefono_Alm,Descripcion_Alm
from tblAlmacen
order by IdAlmacen

--////////////////////////////////////////////////////////////

create proc usp_Almacen_ListarPorDireccion
@parDireccion_Alm	varchar(200)
as
select IdAlmacen,Direccion_Alm,Telefono_Alm,Descripcion_Alm
from tblAlmacen
where Direccion_Alm like '%' + @parDireccion_Alm + '%' 
order by Direccion_Alm

 --/////////////////////////////////////////////////////

create proc usp_Almacen_ListarPorId
@parIdAlmacen int
as
select IdAlmacen,Direccion_Alm,Telefono_Alm,Descripcion_Alm
from tblAlmacen
where IdAlmacen>=@parIdAlmacen
order by IdAlmacen

--/////////////////////////////////////////////////////

create proc usp_Almacen_Actualizar
@parIdAlmacen	int,
@parNUEVO_Direccion_Alm        varchar(100),
@parNUEVO_Telefono_Alm         varchar(20),
@parNUEVO_Descripcion_Alm         varchar(500)
as
UPDATE tblAlmacen
set
Direccion_Alm=@parNUEVO_Direccion_Alm,
Telefono_Alm=@parNUEVO_Telefono_Alm,
Descripcion_Alm=@parNUEVO_Descripcion_Alm
where IdAlmacen=@parIdAlmacen