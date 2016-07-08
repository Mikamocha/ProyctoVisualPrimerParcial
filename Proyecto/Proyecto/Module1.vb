Imports System.Xml
Module Module1
    Public almacen As New ArrayList()
    Public provincias As New ArrayList()
    Public ind As Integer = 0
    Public codigoProducto As String
    Public path As String = "..\..\usuarios.xml"
    Public xmldoc As New XmlDocument()
    Public raiz As XmlNodeList = xmldoc.GetElementsByTagName("Registro_Usuarios")
    Dim rutaXML As XmlTextWriter = New XmlTextWriter("factura.xml", System.Text.Encoding.UTF8)

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
                                crearXMLfactura()
                                Dim contadorfacturas As Integer = 0
                                Dim seguirLLenandofactura As Boolean = True
                                While seguirLLenandofactura
                                    Dim codigo As String
                                    Dim factura As New Factura()
                                    Dim cliente As New Cliente()
                                    Console.WriteLine("Escriba el Nombre del Cliente")
                                    cliente.Nombre = Console.ReadLine()
                                    Console.WriteLine("Escriba el Nombre del Apellido")
                                    cliente.Apellido = Console.ReadLine()
                                    factura.NumeroFactura = contadorfacturas + 1
                                    factura.EmpresaFactura = llenarDatosCabeceraFact()
                                    factura.ClienteComprador = cliente
                                    Dim thisDate As Date
                                    thisDate = Today
                                    factura.Fecha = Today.ToString
                                    Dim existeProvincia As Boolean = False
                                    Do
                                        Console.WriteLine("Ingrese Provincia")
                                        factura.Provincia = Console.ReadLine()
                                        existeProvincia = validarProvinvicias(factura.Provincia)

                                        If existeProvincia <> True Then
                                            Console.Clear()
                                            Console.WriteLine("Provincia No existe")

                                        End If
                                    Loop Until existeProvincia = True
                                    Dim ingresarProductos As Boolean = True
                                    While ingresarProductos
                                        Dim producto As New Producto()
                                        Dim existeProducto As Boolean = False
                                        Do

                                            Console.Write("codigo  de Producto  :")
                                            codigo = Console.ReadLine()
                                            existeProducto = validarProductos(codigo)
                                            If existeProducto <> True Then
                                                Console.WriteLine("Producto No Existe")
                                                Console.WriteLine("Por favor Ingrese un codigo valido ")
                                            End If

                                        Loop Until existeProducto = True

                                        producto = llenarDatosProdcuto(codigo)
                                        Console.WriteLine(producto.NombreProducto)
                                        factura.detalles.Add(producto)
                                        Dim seguirllenandoProdcutos As Integer
                                        Do
                                            Console.WriteLine("Desea Ingresar como otro Producto")
                                            Console.WriteLine("1.- Si")
                                            Console.WriteLine("2.- No")
                                            seguirllenandoProdcutos = validarDatosnumerico()
                                        Loop Until seguirllenandoProdcutos > 0 And seguirllenandoProdcutos < 3
                                        If seguirllenandoProdcutos = 1 Then
                                            ingresarProductos = True
                                        Else
                                            ingresarProductos = False
                                        End If
                                    End While

                                    factura.TotalSinImpuestos = calcularTotalSinImpuestos(factura)
                                    Dim modoDePago As Integer = 0
                                    Do
                                        Console.WriteLine("Modo de pago")
                                        Console.WriteLine("1.-EFECTIVO")
                                        Console.WriteLine("2.-TARJETA")
                                        Console.WriteLine("3.-DINERO ELECTRONICO")
                                        modoDePago = validarDatosnumerico()
                                    Loop Until modoDePago > 0 And modoDePago < 4
                                    If modoDePago = 1 Then
                                        factura.TotalDescuento = 0
                                    End If
                                    If modoDePago = 2 Then
                                        factura.TotalDescuento = factura.TotalSinImpuestos * 0.1
                                    End If
                                    If modoDePago = 3 Then
                                        factura.TotalDescuento = factura.TotalSinImpuestos * 0.4
                                    End If
                                    factura.Impuestos = calcularImpuestos(factura)
                                    factura.Total = calculartotal(factura)
                                    guardarXmlFactura(factura)
                                    Dim res As Integer = 0
                                    Do
                                        Console.WriteLine("Desea Ingresar como otra Factura")
                                        Console.WriteLine("1.- Si")
                                        Console.WriteLine("2.- No")
                                        res = validarDatosnumerico()
                                    Loop Until res > 0 And res < 3
                                    If res = 1 Then
                                        seguirLLenandofactura = True


                                    Else
                                        seguirLLenandofactura = False

                                        rutaXML.Flush()
                                        rutaXML.Close()
                                    End If

                                End While
                                leerFactura()

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
                            Console.WriteLine("5.   Buscar Producto")
                            Console.Write("Opcion #:")
                            opcion1 = validarDatosnumerico()

                        Loop Until opcion1 > 0 And opcion1 < 5
                        Dim vendedor As Vendedor




                        Select Case opcion1
                            Case 1
                                Dim codigo, nombreProducto, registraIva As String
                                Dim precioUnitario As Double
                                Dim producto As New Producto()
                                Dim existeProducto = True
                                Do
                                    Console.Write("codigo    :")
                                    codigo = Console.ReadLine()
                                    existeProducto = validarProductos(codigo)
                                    If existeProducto Then
                                        Console.WriteLine("Producto  Existe")
                                        Console.WriteLine("Por favor Ingrese un codigo valido ")
                                    End If

                                Loop Until existeProducto = False
                                Console.Write("Producto     :")
                                nombreProducto = Console.ReadLine()
                                Console.Write("P.Unitario    :")
                                precioUnitario = Console.ReadLine()
                                Console.Write("Registra IVA     :")
                                registraIva = Console.ReadLine()
                                producto = New Producto(codigo, nombreProducto, precioUnitario, registraIva)
                                'Console.WriteLine(producto.tostring())


                                'Console.WriteLine(producto.tostring())
                                Dim xmlDocProducto As New XmlDocument()
                                Dim rutaProdutos As String = "..\..\productos.xml"
                                Dim raizProductos As XmlNodeList = xmlDocProducto.GetElementsByTagName("productos")
                                'Console.WriteLine(producto.tostring())
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
                            Case 5
                                Console.WriteLine("Ingrese el nombre que desa consultar")

                                Dim producto As Producto = almacen.Item(0).buscarProductosDelAlmacen
                                Console.WriteLine(producto.tostring)
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

        Dim nombre As String = "Tienda de Viveres K&Y"
        Dim RazonSocial As String = "Tienda de Viveres K&Y"
        Dim DirMatriz As String = "Av.Olmedo y Chimborazo"
        Dim Ruc As String = "0923849501"
        Dim empresa As New Empresa(nombre, RazonSocial, Ruc, DirMatriz)
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
        Dim codigo, nombre, precio As String
        Dim xmlDocProducto As New XmlDocument()
        Dim rutaProdutos As String = "..\..\productos.xml"
        Dim raizProductos As XmlNodeList = xmlDocProducto.GetElementsByTagName("productos")
        Dim reader As XmlTextReader = New XmlTextReader(rutaProdutos)
        xmlDocProducto.Load(rutaProdutos)
        For Each nodoPrincipal As XmlNode In raizProductos
            For Each nodoHijo As XmlNode In nodoPrincipal.ChildNodes
                If nodoHijo.Attributes(0).Name = "codigo" Then
                    codigo = nodoHijo.Attributes(0).InnerText
                    If codigoProducto = codigo Then
                        For Each nodonieto As XmlNode In nodoHijo.ChildNodes
                            Select Case nodonieto.Name
                                Case "nombre"
                                    nombre = nodonieto.InnerText
                                Case "pUnitario"
                                    precio = nodonieto.InnerText
                            End Select
                        Next
                        Console.WriteLine(nombre & vbTab & precio)
                    End If
                End If
            Next
        Next
    End Sub
    Public Sub crearXMLfactura()

        rutaXML.Formatting = System.Xml.Formatting.Indented
        rutaXML.WriteStartDocument(False)
        rutaXML.WriteStartElement("facturas")
    End Sub
    Public Sub guardarXmlFactura(fac As Factura)
        rutaXML.WriteStartElement("factura")
        rutaXML.WriteElementString("codigo", fac.NumeroFactura)
        rutaXML.WriteElementString("empresa", fac.EmpresaFactura.NombreComercial)
        rutaXML.WriteElementString("fecha", fac.Fecha)
        rutaXML.WriteElementString("provincia", fac.Provincia)
        rutaXML.WriteElementString("cliente", fac.ClienteComprador.Nombre & " " & fac.ClienteComprador.Apellido)


        Dim contador As Integer = 1
        For Each producto As Producto In fac.detalles
            contador = contador + 1
            rutaXML.WriteElementString("productoCodigo" & CStr(contador), producto.Codigo)
            rutaXML.WriteElementString("productoNombre" & CStr(contador), producto.NombreProducto)
        Next
        rutaXML.WriteElementString("totalSinImpuestos", fac.TotalSinImpuestos)
        rutaXML.WriteElementString("totalDescuento", fac.TotalDescuento)
        rutaXML.WriteElementString("impuestos", fac.Impuestos)
        rutaXML.WriteElementString("total", fac.Total)
        rutaXML.WriteEndElement()
        Console.WriteLine(vbNewLine & "Se ha guardado un XML si desea visualizarlo ubiquese en el bin\Debug de esta carpeta")
    End Sub
    Public Function llenarDatosProdcuto(codigo As String) As Producto
        Dim prod As New Producto(codigo)
        For Each p As Almacen_de_Productos In almacen
            For Each producto As Producto In p._almacenProductos
                If String.Compare(producto.Codigo, codigo, True) = 0 Then
                    prod.NombreProducto = producto.NombreProducto
                    prod.PrecioUnitario = producto.PrecioUnitario
                    prod.Codigo = producto.Codigo
                    prod.RegistraIva = prod.RegistraIva
                    Return prod
                End If
            Next
        Next

        Return prod
    End Function


    Public Function validarProductos(codigo As String) As Boolean
        For Each p As Almacen_de_Productos In almacen
            For Each producto As Producto In p._almacenProductos
                If String.Compare(producto.Codigo, codigo, True) = 0 Then
                    Console.WriteLine(producto.NombreProducto)
                    Return True
                End If
            Next
        Next
        Return False
    End Function

    Public Function validarIva(codigo As String) As Boolean

        For Each id As Almacen_de_Productos In almacen
            If id._almacenProductos.Item(0).RegistraIva Then

                Return True
            End If
        Next
        Return False
    End Function
    Public Function calcularTotalSinImpuestos(factura As Factura) As Integer
        Dim total As Integer
        For Each producto As Producto In factura.detalles
            Console.WriteLine(producto.PrecioUnitario)
            total = total + producto.PrecioUnitario
        Next

        Return total
    End Function
    Public Function calcularImpuestos(factura As Factura) As Integer
        Dim total As Integer
        For i As Integer = 0 To factura.detalles.Count Step 1
            If String.Compare(factura.Provincia, provincias.Item(8), True) = 0 Then
                Return 0
            End If
            If String.Compare(factura.Provincia, provincias.Item(14), True) = 0 Then
                Return 0
            End If

            Return factura.TotalSinImpuestos * 0.14
            total = total + factura.detalles.Item(i).PrecioUnitario
        Next
        Return total
    End Function
    Public Function calculartotal(factura As Factura) As Integer


        Return factura.TotalSinImpuestos + CDbl(factura.Impuestos) + CDbl(factura.TotalDescuento)

    End Function
    Public Sub leerFactura()
        Dim xmlDocProducto As New XmlDocument()
        Dim rutaProdutos As String = "factura.xml"
        Dim raizProductos As XmlNodeList = xmlDocProducto.GetElementsByTagName("facturas")
        Dim reader As XmlTextReader = New XmlTextReader(rutaProdutos)
        xmlDocProducto.Load(rutaProdutos)
        For Each nodoPrincipal As XmlNode In raizProductos
            Console.WriteLine(nodoPrincipal.Name & vbNewLine)
            For Each nodoSecundario As XmlNode In nodoPrincipal.ChildNodes
                Console.WriteLine(nodoSecundario.Name & vbTab & nodoSecundario.InnerText & vbNewLine)
            Next

        Next
    End Sub
End Module
