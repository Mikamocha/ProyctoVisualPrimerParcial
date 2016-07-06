Imports System.Xml

Public Class Producto
    Private _codigo As String
    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Private _nombreProducto As String
    Public Property NombreProducto() As String
        Get
            Return _nombreProducto
        End Get
        Set(ByVal value As String)
            _nombreProducto = value
        End Set
    End Property

    Private _precioUnitario As Double
    Public Property PrecioUnitario() As Double
        Get
            Return _precioUnitario
        End Get
        Set(ByVal value As Double)
            _precioUnitario = value
        End Set
    End Property
    Private _registraIva As Boolean
    Public Property RegistraIva As Boolean
        Get
            Return _registraIva
        End Get
        Set(value As Boolean)
            _registraIva = value
        End Set
    End Property

    Public Sub New()

    End Sub


    Sub New(codigo As String, nombreProducto As String, precioUnitario As Double, registraIva As Boolean)
        Me.Codigo = codigo
        Me.NombreProducto = nombreProducto
        Me.PrecioUnitario = precioUnitario
        Me.RegistraIva = registraIva
    End Sub

    Public Sub New(codigo As String)
        Me.Codigo = codigo
    End Sub

    Public Overrides Function tostring() As String
        Return "Codigo: " & Codigo & vbNewLine & "Producto: " & NombreProducto & vbTab & "Precio unitario: " & PrecioUnitario & "   Registra Iva:" & RegistraIva & vbNewLine & "------------------------------------------------------------------ "
    End Function


    Public Function agregarProducto(xmlDocProducto As XmlDocument)
        Dim producto As XmlElement = xmlDocProducto.CreateElement("producto")
        producto.SetAttribute("codigo", Me.Codigo)
        Dim nombre As XmlElement = xmlDocProducto.CreateElement("nombre")
        Dim precioUnit As XmlElement = xmlDocProducto.CreateElement("pUnitario")
        Dim iva As XmlElement = xmlDocProducto.CreateElement("iva")

        nombre.InnerText = Me.NombreProducto
        precioUnit.InnerText = Me.PrecioUnitario
        iva.InnerText = Me.RegistraIva

        producto.AppendChild(nombre)
        producto.AppendChild(precioUnit)
        producto.AppendChild(iva)

        Return producto
    End Function
End Class
