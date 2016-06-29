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

    Public Sub New(nombre As String, apellido As String, edad As Short, email As String, telefono As String, genero As String, cedula As String, nroPersonasCargo As Integer, contraseña As String)
        MyBase.New(nombre, apellido, edad, email, telefono, genero, cedula)
        Me.NroPersonasAcargo = nroPersonasCargo
        Me.Contraseña = contraseña
    End Sub

    Public Overrides Function tostring() As String
        Return MyBase.toString() + "Nro Personas a Cargo:  " & NroPersonasAcargo & "  Contraseña" & Contraseña
    End Function
End Class
