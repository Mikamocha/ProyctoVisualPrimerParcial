﻿Imports System.Xml
Module Module1
    Public almacen As New ArrayList()
    Public provincias As New ArrayList()
    Public ind As Integer = 0
    Public codigoProducto As String
    Public path As String = "..\..\usuarios.xml"
    Public xmldoc As New XmlDocument()
    Public raiz As XmlNodeList = xmldoc.GetElementsByTagName("Registro_Usuarios")
    Public numFactura As Integer
    Sub Main()
        Dim seguirMenu As Boolean = True
        crearProvincias()
        leerXmlProductos()
        xmldoc.Load(path)

        Dim opcion, opcion1, opcion2 As Integer
        Dim usuario, contraseña As String
        Dim seguir As Boolean = True
        While seguirMenu

            Do
                Console.Clear()
                Console.WriteLine("--------------------------------------------------------------------------------")
                Console.WriteLine("******** Sistema de Facturacion ********")
                Console.WriteLine("Bienvenidos a ........")
                Console.WriteLine("Escoga una opcion... :")
                Console.WriteLine("1.   Inicie sesion como Vendedor")
                Console.WriteLine("2.   Inicie sesion como Administrador")
                Console.WriteLine("Opcion:     ")
                opcion = validarDatosnumerico()
                Console.WriteLine("--------------------------------------------------------------------------------")
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
                            Console.WriteLine("2.   Salir")
                            Console.Write("Opcion:     ")
                            opcion2 = validarDatosnumerico()
                        Loop Until opcion2 > 0 And opcion1 < 2
                        Select Case opcion2
                            Case 1
                                Dim facturar As Boolean = True
                                While facturar
                                    Dim factura As New Factura()
                                    Dim cliente As New Cliente
                                    Dim empresa As New Empresa
                                    Dim existeProvincia As Boolean = False
                                    Do
                                        'Console.WriteLine(llenarDatosCabeceraFact())

                                        'Console.Write("Nombre del cliente   :")

                                        'cliente.Nombre = Console.ReadLine()
                                        'Console.Write("Apellido del cliente  :")
                                        'cliente.Apellido = Console.ReadLine()
                                        'Console.Write("Telefono     :")
                                        'cliente.Telefono = Console.ReadLine()
                                        'Console.Write("Cedula   :")
                                        'cliente.CedulaIdentidad = Console.ReadLine()
                                        Console.WriteLine("**************   Detalle      ***************")
                                        Console.Write("Codigo   :")
                                        codigoProducto = Console.ReadLine()
                                        leerCodigo(codigoProducto)


                                        Console.WriteLine("Provincia    :")
                                        factura.Provincia = Console.ReadLine()

                                        existeProvincia = validarProvinvicias(factura.Provincia)
                                        If existeProvincia <> True Then
                                            Console.Clear()
                                            Console.WriteLine("Provincia No existe")

                                        End If
                                    Loop Until existeProvincia = True
                                    numFactura = numFactura + 1
                                    factura.NumeroFactura = CStr(numFactura)
                                    Console.WriteLine("#" & "Probando:" & factura.NumeroFactura)
                                    Console.WriteLine("Provincia  existe")
                                    Dim resFactura As Integer
                                    Do
                                        Console.WriteLine("Desea Ingresar otra factura")
                                        Console.WriteLine("1.- Si")
                                        Console.WriteLine("2.- No")
                                        resFactura = validarDatosnumerico()
                                    Loop Until resFactura > 0 And resFactura < 3

                                    If resFactura = 1 Then
                                        facturar = True
                                    Else
                                        facturar = False
                                    End If

                                End While

                                'aqui se creara la factura 
                                'Dim factura As Factura
                                'factura.ClienteComprador.Nombre = Console.ReadLine()
                                'factura = New Factura()
                            Case 2
                                FileClose()

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
                            Console.WriteLine("5.   Buscar Factura")
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
                                'Console.WriteLine("Su producto se ha registrado con exito")
                                xmlDocProducto.Save(rutaProdutos)
                                Loop Until opcion1 > 0 And opcion1 < 6
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
                                        xmlDocProducto.Load(rutaProdutos)
                                        Dim nodos As XmlNode = producto.agregarProducto(xmlDocProducto)
                                        Console.WriteLine(producto.tostring())
                                        For Each nodo As XmlNode In raizProductos

                                            Console.WriteLine("Registrando...")
                                            nodo.AppendChild(nodos)

                                        Next
                                        'Console.WriteLine("Su producto se ha registrado con exito")
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
            Dim seguirOp As Integer
            Do
                Console.WriteLine("Desea Ingresar como otro usuario")
                Console.WriteLine("1.- Si")
                Console.WriteLine("2.- No")
                seguirOp = validarDatosnumerico()
            Loop Until seguirOp > 0 And seguirOp < 3
            If seguirOp = 1 Then
                seguirMenu = True
            Else
                seguirMenu = False
                Console.WriteLine("Adios que tenga un buen dia :)")
            End If
        End While


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

    Public Function llenarDatosCabeceraFact() As Empresa
        Dim empresa As Empresa
        'empresa.NombreComercial = "Tienda de Viveres K&Y"
        Dim RazonSocial As String = "Tienda de Viveres K&Y"
        Dim DirMatriz As String = "Av.Olmedo y Chimborazo"
        Dim Ruc As String = "0923849501"
        empresa = New Empresa(RazonSocial, Ruc, DirMatriz)
        Return empresa
        'Dim factura As New Factura
        'factura.NumeroFactura = generarNumeroFactura()
    End Function

    Public Function generarNumeroFactura() As Integer
        Dim numero As Integer = 0
        leerXmlFacturas()
        Return numero
    End Function

    Public Sub leerXmlFacturas()
        Dim xmlDocFactura As New XmlDocument()
        Dim rutaFactura As String = "..\..\facturas.xml"
        Dim raizProductos As XmlNodeList = xmlDocFactura.GetElementsByTagName("Facturas")
        Dim reader As XmlTextReader = New XmlTextReader(rutaFactura)
        xmlDocFactura.Load(rutaFactura)
        Dim numero As Integer = 0
        For Each nodo As XmlNode In raizProductos
            For Each nodoHijo As XmlNode In nodo.ChildNodes
                If nodoHijo.Name = "NumFactura" Then
                    numero = nodoHijo.InnerText
                End If
            Next
        Next
        numero = numero + 1
        Console.WriteLine(numero)
    End Sub

    Public Sub leerCodigo(codigoProducto)

        Console.WriteLine("entro")
        Dim codigo, nombre, precio As String
        Dim xmlDocProducto As New XmlDocument()
        Dim rutaProdutos As String = "..\..\productos.xml"
        Dim raizProductos As XmlNodeList = xmlDocProducto.GetElementsByTagName("productos")
        Dim reader As XmlTextReader = New XmlTextReader(rutaProdutos)
        xmlDocProducto.Load(rutaProdutos)
        For Each nodoPrincipal As XmlNode In raizProductos
            'Console.WriteLine(nodoPrincipal.InnerText)
            Console.WriteLine("entro2")
            For Each nodoHijo As XmlNode In nodoPrincipal.ChildNodes
                'Console.WriteLine(nodoHijo.InnerText)
                Console.WriteLine("entro3")
                If nodoHijo.Attributes(0).Name = "codigo" Then
                    Console.WriteLine("entro jajaaj")
                    codigo = nodoHijo.Attributes(0).InnerText
                    Console.WriteLine(nodoHijo.Attributes(0).InnerText)
                    Console.WriteLine(codigo)
                    'Console.WriteLine(nodoHijo.InnerText)

                    If codigoProducto = codigo Then
                        Console.WriteLine("entro4")
                        If nodoHijo.Name = "nombre" Then
                            Console.WriteLine("xfin entro")
                            nombre = nodoHijo.InnerText
                            Console.WriteLine(nodoHijo.InnerText)
                        End If
                        If nodoHijo.Name = "pUnitario" Then
                            precio = nodoHijo.InnerText
                            Console.WriteLine(nodoHijo.InnerText)
                        End If
                        'Select Case nodoHijo.Name
                        '        Case "nombre"
                        '            Console.WriteLine("entro5")
                        '            nombre = nodoHijo.InnerText
                        '        Case "pUnitario"
                        '            precio = nodoHijo.InnerText
                        '    End Select
                        Console.WriteLine(nombre & precio)
                    End If



                End If
            Next
        Next
        'Console.WriteLine(codigo & "Nombre: " & nombre & precio)
    End Sub
End Module
