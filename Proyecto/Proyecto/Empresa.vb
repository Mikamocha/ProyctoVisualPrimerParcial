Public Class Empresa
    Private _razonSocial As String
    Public Property RazonSocial() As String
        Get
            Return _razonSocial
        End Get
        Set(ByVal value As String)
            _razonSocial = value
        End Set
    End Property

    Private _nombreComercial As String
    Public Property NombreComercial() As String
        Get
            Return _nombreComercial
        End Get
        Set(ByVal value As String)
            _nombreComercial = value
        End Set
    End Property
    Private _ruc As String
    Public Property Ruc() As String
        Get
            Return _ruc
        End Get
        Set(ByVal value As String)
            _ruc = value
        End Set
    End Property


    Private _dirMatriz As String
    Public Property DirMatriz() As String
        Get
            Return _dirMatriz
        End Get
        Set(value As String)
            _dirMatriz = value
        End Set
    End Property


    Overrides Function tostring() As String
        Return "Empresa:" & vbTab + Me.RazonSocial & vbTab & " RUC: " + Me.Ruc
    End Function
End Class
