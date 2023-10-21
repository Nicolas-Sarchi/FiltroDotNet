# NicolasSarchi-Ropa

## Consultas

### Listar los proveedores que sean persona natural.

  * Ruta : `http://localhost:5096/api/Proveedor/personas-naturales`

    ![image](https://github.com/Nicolas-Sarchi/NicolasSarchi-Ropa/assets/131916765/2b758998-f47f-4104-a6ad-d9e884ce4619)

### Listar las prendas de una orden de producción cuyo estado sea en producción. El usuario debe ingresar el número de orden de producción.
  * Ruta : `http://localhost:5096/api/orden/Prendas/Produccion?id=1`

    ![image](https://github.com/Nicolas-Sarchi/NicolasSarchi-Ropa/assets/131916765/ea416e60-c1ee-4292-bc2e-d4016b30a1f0)

### Listar las prendas agrupadas por el tipo de protección.
  * Ruta: `http://localhost:5096/api/prenda/tipo-proteccion`

    ![image](https://github.com/Nicolas-Sarchi/NicolasSarchi-Ropa/assets/131916765/11de070c-f51c-42e8-8c3b-e3e9f329b761)
    
### Listar las ordenes de producción que pertenecen a un cliente especifico

  * Ruta: `http://localhost:5096/api/orden/cliente?id=1101622982`
  * PayLoad : Ids de clientes: `1101622962`, ` 113451682`}

    ![image](https://github.com/Nicolas-Sarchi/NicolasSarchi-Ropa/assets/131916765/99329eac-22f9-4047-96a8-250e1a3fad67)

### Listar los insumos de una prenda y calcular cuanto cuesta producir una prenda especifica
  * Ruta: `http://localhost:5096/api/prenda/costo?id=2343`,
  * Payload : id prendas : `2343` , `2342343`

### Listar los insumos que son vendidos por un determinado proveedor. El usuario debe ingresar el Nit de proveedor.
  * Ruta: `http://localhost:5096/api/insumo/proveedor?id=23423`
  * *PayLoad : NitProveedor : `23423`, `445332`

    ![image](https://github.com/Nicolas-Sarchi/NicolasSarchi-Ropa/assets/131916765/364e2015-adfa-41d0-866f-115fafab3239)

### Listar las ventas realizadas por un empleado especifico. }
  * Ruta: `http://localhost:5096/api/empleado/facturas?id=1234324`
  * PayLoad: Ids EMpleado: `1234324`, ` 44444`,  ` 3432`

  ![image](https://github.com/Nicolas-Sarchi/NicolasSarchi-Ropa/assets/131916765/cd3ee6b2-b8de-43d5-aa6b-a5f2206ff246)


  




    


