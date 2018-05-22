create proc usp_Medida_Insertar
	@parDescripcion_Med	varchar(50) ,
	@parAbreviatura_Med	varchar(10)

as 

if exists
(
	select Descripcion_Med,Abreviatura_Med from tblMedida
	where Descripcion_Med= @parDescripcion_Med or Abreviatura_Med=@parAbreviatura_Med
)
	begin
		raiserror('La Medida y/o Abreviatura ya está registrada.',16,1)
	end
else
	begin
		insert into tblMedida
		(
			Descripcion_Med,
			Abreviatura_Med
	
		)
	values
		(
			@parDescripcion_Med	,
			@parAbreviatura_Med		
		)
	end

--//////////////////////////////////////////////////////////////

create proc usp_Medida_Listar_Todos
as
select IdMedida,Descripcion_Med,Abreviatura_Med
from tblMedida
order by Descripcion_Med

--///////////////////////////////////////////////////////////

create proc usp_Medida_ListarPorDescripcion
@parDescripcion_Med varchar(50)
as
select IdMedida,Descripcion_Med,Abreviatura_Med
from tblMedida
where Descripcion_Med like @parDescripcion_Med + '%' 
order by Descripcion_Med