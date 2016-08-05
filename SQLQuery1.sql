select * into DetalleCuenta
from
(
declare @cols as nvarchar(max),
@query as nvarchar(max)

select @cols = stuff((select ',' + quotename(convert(char(7),dateadd(month, datediff(month, 0,Cuenta_FechaProceso),0),120)) from Cuenta
group by Cuenta_FechaProceso
order by Cuenta_FechaProceso
for xml path(''), type
).value('.','nvarchar(max)'),1,1,'')

set @query= 'select detalle,' + @cols + ' from
(
select PlandeCuentas.Plan_Grupo as [detalle], PlandeCuentas.Plan_Nombre as [nombre], 
Cuenta.Cuenta_Valor as [valor], convert(char(7),dateadd(month, datediff(month, 0,Cuenta.Cuenta_FechaProceso),0),120) 
as [Fecha] from PlandeCuentas, Cuenta where Cuenta.Plan_Id=PlandeCuentas.Plan_Id
) x
PIVOT
(
	sum(valor)
	for Fecha in (' + @cols + ')
	)p'

	execute(@query);)
