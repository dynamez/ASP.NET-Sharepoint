select * from
(
select PlandeCuentas.Plan_Grupo, PlandeCuentas.Plan_Nombre, 
Cuenta.Cuenta_Valor, convert(char(7),dateadd(month, datediff(month, 0,Cuenta.Cuenta_FechaProceso),0),120) as [Cuenta_FechaProceso]
from PlandeCuentas, Cuenta where Cuenta.Plan_Id=PlandeCuentas.Plan_Id
) x
PIVOT
(
	sum(Cuenta_Valor)
	for Cuenta_FechaProceso in ([2016-01],[2016-04])
	)p