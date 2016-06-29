Public Class Administrador
    Inherits Persona
    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

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

    Public Sub New(nombre As String, apellido As String, edad As Integer, email As String, telefono As String, genero As String, cedula As String, nroPersonasCargo As Integer, usuario As String, contraseña As String)
        MyBase.New(nombre, apellido, edad, email, telefono, genero, cedula)
        Me.NroPersonasAcargo = nroPersonasCargo
        Me.Usuario = usuario
        Me.Contraseña = contraseña
    End Sub


    Public Sub New(usuario As String, contraseña As String)
        MyBase.New()
        Me.Usuario = usuario
        Me.Contraseña = contraseña
    End Sub

    Public Overrides Function tostring() As String
        Return MyBase.toString() + "Nro Personas a Cargo:  " & NroPersonasAcargo
    End Function
End Class
