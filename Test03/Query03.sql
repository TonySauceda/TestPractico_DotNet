UPDATE O
	SET OrdenesMontoTotal = OrdenesMontoTotal * 1.1
FROM Ordenes O
INNER JOIN Clientes C ON C.ClientesCodigo = O.ClientesCodigo
WHERE C.ClientesNombre = 'Juan Perez'