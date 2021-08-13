SELECT
	E.EmpleadosCodigo,
	E.EmpleadosNombre,
	COUNT(O.OrdenesNumero) Total
FROM Empleados E
INNER JOIN Ordenes O ON O.EmpleadosCodigo = E.EmpleadosCodigo
GROUP BY E.EmpleadosCodigo, E.EmpleadosNombre