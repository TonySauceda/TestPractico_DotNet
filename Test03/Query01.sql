SELECT
	O.OrdenesNumero,
	C.ClientesNombre,
	E.EmpleadosNombre
FROM Ordenes O
INNER JOIN Clientes C ON C.ClientesCodigo = O.ClientesCodigo
INNER JOIN Empleados E ON E.EmpleadosCodigo = O.EmpleadosCodigo
ORDER BY C.ClientesNombre, O.OrdenesNumero