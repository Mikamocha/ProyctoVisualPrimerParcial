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
    Public Property RegistraIva() As Boolean
        Get
            Return _registraIva
        End Get
        Set(ByVal value As Boolean)
            _registraIva = value
        End Set
    End Property

    Sub New(codigo As String, nombreProducto As String, registraIva As Boolean)
        Me.Codigo = codigo
        Me.NombreProducto = nombreProducto
        Me.RegistraIva = registraIva
    End Sub


    Public Overrides Function tostring() As String
        Return "Codigo:     " & Codigo & "   Producto:   " & NombreProducto & "   Registra Iva:   " & RegistraIva
    End Function
End Class
