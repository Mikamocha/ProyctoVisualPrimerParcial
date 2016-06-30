Imports System.Xml

Public Class Almacen_de_Productos
    Private _almacenProductos As ArrayList
    Public indice As Integer = 0
    Public Property AlmacenProductos As ArrayList
        Get
            Return _almacenProductos
        End Get
        Set(value As ArrayList)
            _almacenProductos = value
        End Set
    End Property

    Public Sub New()

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
End Class
