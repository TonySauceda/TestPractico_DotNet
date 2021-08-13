SELECT
	P.ProductosCodigo,
	P.ProductosDescripcion,
	COUNT(O.OrdenesNumero) Total
FROM Ordenes O
INNER JOIN DetalleOrdenes DO ON DO.OrdenesNumero = O.OrdenesNumero
INNER JOIN Productos P ON P.ProductosCodigo = DO.ProductosCodigo
INNER JOIN Clientes C ON C.ClientesCodigo = O.ClientesCodigo
WHERE P.ProductosDescripcion IN('Leche', 'Harina', 'Huevo')
	AND O.OrdenesFecha BETWEEN '2020-01-01' AND '2020-03-31'
	AND C.ClientesNombre IN('Juan Perez', 'Pedro Hernandez')
	AND O.EmpleadosCodigo LIKE '%A01%'
GROUP BY P.ProductosCodigo, P.ProductosDescripcion