Imports Proyecto

Public Class Factura


    Private _numero As String
    Private _estab As String
    Private _ptoEmi As String
    Private _secuencial As String
    Private _fecha As String
    Private _impuestos As String
    Private _cliente As Cliente
    Private _empresa As Empresa
    Private _totalSimImpuestos As Double
    Private _total As String
    Private _totalDescuento As Double
    Private _provincia As String
    Public Property Numero() As String
        Get
            Return _numero
        End Get
        Set(value As String)
            _numero = value
        End Set
    End Property

    Public Property Establecimiento() As String
        Get
            Return _estab
        End Get
        Set(ByVal value As String)
            _estab = value
        End Set
    End Property


    Public Property PuntoEmision() As String
        Get
            Return _ptoEmi
        End Get
        Set(ByVal value As String)
            _ptoEmi = value
        End Set
    End Property


    Public Property Secuencial() As String
        Get
            Return _secuencial
        End Get
        Set(ByVal value As String)
            _secuencial = value
        End Set
    End Property


    Public Property Fecha() As String
        Get
            Return _fecha
        End Get
        Set(value As String)
            _fecha = value
        End Set
    End Property


    Public Property Impuestos() As String
        Get
            Return _impuestos
        End Get
        Set(value As String)
            _impuestos = value
        End Set
    End Property

    Public Property Total() As String
        Get
            Return _total
        End Get
        Set(ByVal value As String)
            _total = value
        End Set
    End Property
    Public detalles As ArrayList

    Public Sub New(numero As String, estab As String, ptoEmi As String, secuencial As String, fecha As String, impuestos As String, cliente As Cliente, empresa As Empresa, totalSimImpuestos As Double, total As String, totalDescuento As Double, provincia As String)
        Me._numero = numero
        Me._estab = estab
        Me._ptoEmi = ptoEmi
        Me._secuencial = secuencial
        Me._fecha = fecha
        Me._impuestos = impuestos
        Me._cliente = cliente
        Me._empresa = empresa
        Me._totalSimImpuestos = totalSimImpuestos
        Me._total = total
        Me._totalDescuento = totalDescuento
        Me._provincia = provincia
    End Sub

    Public Sub New()

    End Sub

    Public Property EmpresaFactura() As Empresa
        Get
            Return _empresa
        End Get
        Set(value As Empresa)
            _empresa = value
        End Set
    End Property


    Public Property ClienteComprador() As Cliente
        Get
            Return _cliente
        End Get
        Set(value As Cliente)
            _cliente = value
        End Set
    End Property

    Public Property TotalSinImpuestos() As Double
        Get
            Return _totalSimImpuestos
        End Get
        Set(ByVal value As Double)
            _totalSimImpuestos = value
        End Set
    End Property


    Public Property TotalDescuento() As Double
        Get
            Return _totalDescuento
        End Get
        Set(ByVal value As Double)
            _totalDescuento = value
        End Set
    End Property


    Public Property Provincia As String
        Get
            Return _provincia
        End Get
        Set(value As String)
            _provincia = value
        End Set
    End Property



End Class
