Imports System.Xml
Module Module1
    Public almacen As New ArrayList()
    Public provincias As New ArrayList()
    Public ind As Integer = 0
    Public path As String = "..\..\usuarios.xml"
    Public xmldoc As New XmlDocument()
    Public raiz As XmlNodeList = xmldoc.GetElementsByTagName("Registro_Usuarios")
    Sub Main()
        crearProvincias()
        leerXmlProductos()
        xmldoc.Load(path)

        Dim opcion, opcion1, opcion2 As Integer
        Dim usuario, contraseña As String
        Dim seguir As Boolean = True


        Do
            'Console.Clear()
            Console.WriteLine("--------------------------------------------------------------------------------")
            Console.WriteLine("******** Sistema de Facturacion ********")
            Console.WriteLine("Bienvenidos a ........")
            Console.WriteLine("Escoga una opcion... :")
            Console.WriteLine("1.   Inicie sesion como Vendedor")
            Console.WriteLine("2.   Inicie sesion como Administrador")
            Console.WriteLine("Opcion:     ")
            opcion = validarDatosnumerico()
        Loop Until opcion < 3 And opcion > 0
        Select Case opcion
            Case 1
                Dim existe
                Do
                    Dim vendedor As Vendedor
                    Console.Write("Digite su usuario    :")
                    usuario = Console.ReadLine()
                    Console.Write("Digite su contraseña     :")
                    contraseña = Console.ReadLine()
                    vendedor = New Vendedor(usuario, contraseña)
                    existe = leerXmlPersonas(vendedor, opcion)
                    If existe <> True Then
                        Console.Clear()
                        Console.WriteLine("Usuario No existe")
                        Console.WriteLine("Digite Nuevamente su usuario " & vbNewLine)
                    End If

                Loop Until existe = True
                If existe Then
                    Console.Clear()
                    Do
                        Console.WriteLine("Escoga una opcion... :")
                        Console.WriteLine("1.   Nueva Factura")
                        Console.WriteLine("2.   Buscar Factura")
                        Console.Write("Opcion:     ")
                        opcion2 = validarDatosnumerico()
                    Loop Until opcion2 > 0 And opcion1 < 2
                    Select Case opcion2
                        Case 1
                            Dim factura As New Factura()
                            factura.ClienteComprador.Nombre = Console.ReadLine()

                            Dim existeProvincia As Boolean = False
                            Do
                                Console.WriteLine("Ingrese Provincia")
                                factura.Provincia = Console.ReadLine()

                                existeProvincia = validarProvinvicias(factura.Provincia)
                                'Console.WriteLine(validarProvinvicias(factura.Provincia))
                                If existeProvincia <> True Then
                                    ' Console.Clear()
                                    Console.WriteLine("Provincia No existe")

                                End If
                            Loop Until existeProvincia = True
                            Console.WriteLine("Provincia  existe")
                            'aqui se creara la factura 
                            'Dim factura As Factura
                            'factura.ClienteComprador.Nombre = Console.ReadLine()
                            'factura = New Factura()
                    End Select
                End If


            Case 2
                Dim existe
                Do

                    Dim administrador As Administrador
                    Console.Write("Digite su usuario    :")
                    usuario = Console.ReadLine()
                    Console.Write("Digite su contraseña     :")
                    contraseña = Console.ReadLine()
                    administrador = New Administrador(usuario, contraseña)
                    existe = leerXmlPersonas(administrador, opcion)
                    If existe <> True Then
                        Console.Clear()
                        Console.WriteLine("Usuario No existe")
                        Console.WriteLine("Digite Nuevamente su usuario " & vbNewLine)
                    End If

                Loop Until existe = True
                If existe Then
                    Console.Clear()
                    Do

                        Console.WriteLine("Escoga una operacion que desee realizar:")
                        Console.WriteLine("1.   Añadir un producto")
                        Console.WriteLine("2.   Registrar Vendedor")
                        Console.WriteLine("3.   Mostrar lista de vendedores ")
                        Console.WriteLine("4.   Mostrar lista de Productos ")
                        Console.Write("Opcion #:")
                        opcion1 = validarDatosnumerico()

                    Loop Until opcion1 > 0 And opcion1 < 5
                    Dim vendedor As Vendedor
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
                            'Console.WriteLine(producto.tostring())
                            Dim xmlDocProducto As New XmlDocument()
                            Dim rutaProdutos As String = "..\..\productos.xml"
                            Dim raizProductos As XmlNodeList = xmlDocProducto.GetElementsByTagName("productos")
                            Dim nodos As XmlNode = producto.agregarProducto(xmlDocProducto)
                            Console.WriteLine(producto.tostring())
                            For Each nodo As XmlNode In raizProductos
                                For Each nodoSecundario In nodo
                                    Console.WriteLine("Registrando...")
                                    nodo.AppendChild(nodos)
                                Next
                            Next
                            Console.WriteLine("Su producto se ha registrado con exito")
                            xmlDocProducto.Save(rutaProdutos)

                        Case 2
                            Dim nombre, apellido, email, telefono, genero, cedula, id, fechaContrato, contacto As String
                            Dim edad As Integer
                            'Dim vendedor As Vendedor
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
                            Dim nodos As XmlNode = vendedor.agregarVendedor(xmldoc)


                            For Each nodo As XmlNode In raiz
                                Console.WriteLine("Registrando...")
                                nodo.AppendChild(nodos)
                            Next
                            Console.WriteLine("El nuevo vendedor fue agregado con exito")
                            xmldoc.Save(path)
                        Case 3
                            'leer xml y listar todos los vendedores
                            Dim nvendedor As Vendedor = New Vendedor(raiz.Item(0))

                        Case 4
                            For i As Integer = 0 To almacen.Count Step 1
                                almacen.Item(i).mostrarProductosDelAlmacen()
                                i = i + 1
                            Next


                    End Select
                End If


        End Select

        Console.ReadLine()

    End Sub
    Public Function validarDatosnumerico() As Integer
        Dim numero As Integer = 0
        Dim aux As Object = 0
        Dim bol As Boolean = True
        Do While True
            aux = Console.ReadLine()
            bol = IsNumeric(aux)
            If bol Then
                numero = aux
                Return numero
            Else
                Console.WriteLine("-----Error Vuelva a Ingresar-----")
            End If
        Loop
        numero = aux
        Return numero
    End Function

    Public Sub leerXmlProductos()
        Dim xmlDocProducto As New XmlDocument()
        Dim rutaProdutos As String = "..\..\productos.xml"
        Dim raizProductos As XmlNodeList = xmlDocProducto.GetElementsByTagName("productos")
        Dim reader As XmlTextReader = New XmlTextReader(rutaProdutos)
        xmlDocProducto.Load(rutaProdutos)
        For Each nodoPrincipal As XmlNode In raizProductos
            Dim producto As New Almacen_de_Productos(nodoPrincipal.Attributes(0).Value)
            For Each nodoSecundario As XmlNode In nodoPrincipal
                producto.añadirProductos(nodoSecundario)

            Next
            almacen.Add(producto)
        Next
    End Sub

    Public Function leerXmlPersonas(user As Object, cargo As Integer) As Boolean
        Dim confimarExistencia = False
        Dim coincidencias As Integer = 0
        If cargo = 1 Then
            For Each nodoPadre As XmlNode In raiz
                For Each nodoHijo As XmlNode In nodoPadre
                    If nodoHijo.Name = "Vendedor" Then
                        For Each nodoChid As XmlNode In nodoHijo.ChildNodes
                            If (nodoChid.Name = "Usuario") Then
                                If String.Compare(nodoChid.InnerText, user.Usuario, True) = 0 Then
                                    Console.WriteLine("----------Bienvenido ---------- ")
                                    Console.WriteLine("Usuario" & vbTab & nodoChid.InnerText)
                                    coincidencias = coincidencias + 1
                                End If
                            End If
                            If (nodoChid.Name = "Contraseña") Then
                                If String.Compare(nodoChid.InnerText, user.Contraseña, True) = 0 Then
                                    coincidencias = coincidencias + 1
                                    Console.WriteLine("Constraseña" & vbTab & "*****************" & vbNewLine)
                                End If
                            End If
                        Next
                    End If
                Next
            Next
            If coincidencias = 2 Then
                Return True
            End If
        Else
            For Each nodoPadre As XmlNode In raiz
                For Each nodoHijo As XmlNode In nodoPadre
                    If nodoHijo.Name = "Administrador" Then

                        For Each nodoChid As XmlNode In nodoHijo.ChildNodes
                            If (nodoChid.Name = "Usuario") Then
                                Console.WriteLine()
                                Dim k = String.Compare(nodoChid.InnerText, user.Usuario, True)
                                If k = 0 Then
                                    Console.WriteLine("----------Bienvenido ---------- ")
                                    Console.WriteLine("Usuario" & vbTab & nodoChid.InnerText)
                                    coincidencias = coincidencias + 1
                                End If
                            End If
                            If (nodoChid.Name = "Contraseña") Then
                                Dim i = String.Compare(nodoChid.InnerText, user.Contraseña, True)
                                If i = 0 Then
                                    coincidencias = coincidencias + 1
                                    Console.WriteLine("Constraseña" & vbTab & "*****************" & vbNewLine)
                                End If
                            End If
                        Next
                    End If
                Next
            Next
            If coincidencias = 2 Then
                Return True
            End If
        End If

    End Function



    Public Sub crearProvincias()
        provincias.Add("Azuay")
        provincias.Add("Bolivar")
        provincias.Add("Cañar")
        provincias.Add("Carchi")
        provincias.Add("Chimborazo")
        provincias.Add("Cotopaxi")
        provincias.Add("El Oro")
        provincias.Add("Esmeraldas")
        provincias.Add("Galapagos")
        provincias.Add("Guayas")
        provincias.Add("Imbabura")
        provincias.Add("Loja")
        provincias.Add("Los Rios")
        provincias.Add("Manabi")
        provincias.Add("Morona santiago")
        provincias.Add("Napo")
        provincias.Add("Orellana")
        provincias.Add("Pastaza")
        provincias.Add("Pichincha")
        provincias.Add("Santa Elena")
        provincias.Add("Santo Domingo de los Tsachilas")
        provincias.Add("Sucumbios")
        provincias.Add("Tungurahua")
        provincias.Add("Zamora Chinchipe")
    End Sub


    Public Function validarProvinvicias(nombreProvi As String) As Boolean
        Dim encontro As Integer = 0 'si no existe es 0 si existe es 1
        For Each prov As String In provincias
            If String.Compare(prov, nombreProvi, True) = 0 Then
                Console.WriteLine(prov)

                encontro = 1

            End If

        Next
        If encontro = 1 Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
