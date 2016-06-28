Public Class Administrador
    Inherits Persona
    Private _nroPersonasAcargo As Integer
    Public Property NroPersonasAcargo() As Integer
        Get
            Return _nroPersonasAcargo
        End Get
        Set(ByVal value As Integer)
            _nroPersonasAcargo = value
        End Set
    End Property

    Private _contraseña As String
    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property
End Class
