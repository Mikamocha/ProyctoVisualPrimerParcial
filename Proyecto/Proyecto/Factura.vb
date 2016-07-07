Public Class Factura
    Private _numero As String
    Public Property Numero() As String
        Get
            Return _numero
        End Get
        Set(value As String)
            _numero = value
        End Set
    End Property
    Private _estab As String
    Public Property Establecimiento() As String
        Get
            Return _estab
        End Get
        Set(ByVal value As String)
            _estab = value
        End Set
    End Property

    Private _ptoEmi As String
    Public Property PuntoEmision() As String
        Get
            Return _ptoEmi
        End Get
        Set(ByVal value As String)
            _ptoEmi = value
        End Set
    End Property

    Private _secuencial As String
    Public Property Secuencial() As String
        Get
            Return _secuencial
        End Get
        Set(ByVal value As String)
            _secuencial = value
        End Set
    End Property

    Private _fecha As String
    Public Property Fecha() As String
        Get
            Return _fecha
        End Get
        Set(value As String)
            _fecha = value
        End Set
    End Property

    Private _impuestos As String
    Public Property Impuestos() As String
        Get
            Return _impuestos
        End Get
        Set(value As String)
            _impuestos = value
        End Set
    End Property

    Private _total As String
    Public Property Total() As String
        Get
            Return _total
        End Get
        Set(ByVal value As String)
            _total = value
        End Set
    End Property
    Public detalles As ArrayList

    Private _empresa As Empresa
    Public Property EmpresaFactura() As Empresa
        Get
            Return _empresa
        End Get
        Set(value As Empresa)
            _empresa = value
        End Set
    End Property

    Private _cliente As Cliente
    Public Property ClienteComprador() As Cliente
        Get
            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property

    Private _totalSimImpuestos As Double
    Public Property TotalSinImpuestos() As Double
        Get
            Return _totalSimImpuestos
        End Get
        Set(ByVal value As Double)
            _totalSimImpuestos = value
        End Set
    End Property

    Private _totalDescuento As Double
    Public Property TotalDescuento() As Double
        Get
            Return _totalDescuento
        End Get
        Set(ByVal value As Double)
            _totalDescuento = value
        End Set
    End Property


End Class
