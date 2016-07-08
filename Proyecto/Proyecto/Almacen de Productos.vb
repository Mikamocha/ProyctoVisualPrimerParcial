Imports System.Xml

Public Class Almacen_de_Productos
    Public _almacenProductos As New ArrayList()
    Public indice As Integer = 0
    Private _val As String

    Public Property Val As String
        Get
            Return _val
        End Get
        Set(value As String)
            _val = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(value As String)
        Me.Val = value
    End Sub

    Public Sub añadirProductos(producto As XmlNode)
        Dim pro As New Producto(producto.Attributes(0).Value)
        _almacenProductos.Add(pro)
        For Each atributo As XmlNode In producto.ChildNodes
            Select Case atributo.Name
                Case "nombre"
                    _almacenProductos.Item(indice).NombreProducto = atributo.InnerText
                Case "pUnitario"
                    _almacenProductos.Item(indice).PrecioUnitario = atributo.InnerText
                Case "iva"
                    _almacenProductos.Item(indice).RegistraIva = atributo.InnerText
            End Select

        Next
        indice = indice + 1
    End Sub


    Public Sub añadirNuevoProductoEnXml(lista As XmlDocument, producto As Producto)

    End Sub

    Public Sub mostrarProductosDelAlmacen()

        For Each producto As Producto In _almacenProductos
            Console.WriteLine(producto.tostring())

        Next

    End Sub


End Class
