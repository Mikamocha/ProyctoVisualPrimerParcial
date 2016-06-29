Module Module1

    Sub Main()
        Console.WriteLine("Bienvenidos a ........")
        Console.WriteLine("Escoga una opcion... :")
        Console.WriteLine("1.   Inicie sesion como Vendedor")
        Console.WriteLine("2.   Inicie sesion como Administrador")
        Console.WriteLine("Opcion:     ")
        Dim usuario, contraseña As String
        Dim opcion As Integer = Console.ReadLine()
        Select Case opcion
            Case 1
                Dim vendedor As Vendedor
                Console.Write("Digite su usuario    :")
                usuario = Console.ReadLine()
                Console.Write("Digite su contraseña     :")
                contraseña = Console.ReadLine()
                vendedor = New Vendedor(usuario, contraseña)

                'leer xml y validar
                'if usuario y contraseña son iguales...entra

                Console.WriteLine("Escoga una opcion... :")
                Console.WriteLine("1.   Nueva Factura")
                Console.WriteLine("2.   Buscar Factura")
                Console.Write("Opcion:     ")

                Dim opcion2 As Integer = Console.ReadLine()
                Select Case opcion2
                    Case 1
                        'aqui se creara la factura 
                        'Dim factura As Factura
                        'factura.ClienteComprador.Nombre = Console.ReadLine()
                        'factura = New Factura()
                End Select

            Case 2
                Dim administrador As Administrador
                Console.Write("Digite su usuario    :")
                usuario = Console.ReadLine()
                Console.Write("Digite su contraseña     :")
                contraseña = Console.ReadLine()
                administrador = New Administrador(usuario, contraseña)

                'leer xml administrador para hacer la validacion

                Console.WriteLine("Escoga una operacion que desee realizar:")
                Console.WriteLine("1.   Añadir un producto")
                Console.WriteLine("2.   Registrar Vendedor")
                Console.WriteLine("3.   Listar vendedores a cargo")
                Console.Write("Opcion #:")
                Dim opcion1 As Integer = Console.ReadLine()
                Select Case opcion1
                    Case 1
                        Dim codigo, nombreProducto, registraIva As String
                        Dim precioUnitario As Double
                        Dim producto As Producto
                        Console.Write("codigo    :")
                        codigo = Console.ReadLine()
                        Console.Write("Producto     :")
                        nombreProducto = Console.ReadLine()
                        Console.Write("P.Unitario    :")
                        precioUnitario = Console.ReadLine()
                        Console.Write("Registra IVA     :")
                        registraIva = Console.ReadLine()
                        producto = New Producto(codigo, nombreProducto, precioUnitario, registraIva)
                        Console.WriteLine(producto.tostring())
                    Case 2
                        Dim nombre, apellido, email, telefono, genero, cedula, id, fechaContrato, contacto As String
                        Dim edad As Integer
                        Dim vendedor As Vendedor
                        Console.WriteLine("A continuacion digite los datos del vendedor a registrar")
                        Console.Write("Nombre    :")
                        nombre = Console.ReadLine()
                        Console.Write("Apellido    :")
                        apellido = Console.ReadLine()
                        Console.Write("Edad    :")
                        edad = Console.ReadLine()
                        Console.Write("Email    :")
                        email = Console.ReadLine()
                        Console.Write("Telefono   :")
                        telefono = Console.ReadLine()
                        Console.Write(" Genero    :")
                        genero = Console.ReadLine()
                        Console.Write("Cedula    :")
                        cedula = Console.ReadLine()
                        Console.Write("Usuario    :")
                        usuario = Console.ReadLine()
                        Console.Write("Contraseña    :")
                        contraseña = Console.ReadLine()
                        Console.Write("Id    :")
                        id = Console.ReadLine()
                        Console.Write("Fecha de Contrato    :")
                        fechaContrato = Console.ReadLine()
                        Console.Write("Contacto    :")
                        contacto = Console.ReadLine()
                        vendedor = New Vendedor(nombre, apellido, edad, email, telefono, genero, cedula, usuario, contraseña, id, fechaContrato, contacto)
                        Console.WriteLine(vendedor.toString())
                    Case 3
                        'leer xml y listar todos los vendedores
                End Select
        End Select

        Console.ReadLine()

    End Sub

End Module
