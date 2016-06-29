Public Class Vendedor
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

    Private _contraseña As String
    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property
    Private _id As Short

    Public Property Id As Short
        Get
            Return _id
        End Get
        Set(value As Short)
            _id = value
        End Set
    End Property
    Private _fechaDeContrato As Date
    Public Property FechaDeContrato As Date
        Get
            Return _fechaDeContrato
        End Get
        Set(value As Date)
            _fechaDeContrato = value
        End Set
    End Property

    Private _contacto As String

    Public Property Contacto As String
        Get
            Return _contacto
        End Get
        Set(value As String)
            _contacto = value
        End Set
    End Property


    Public Sub New(nombre As String, apellido As String, edad As Short, email As String, telefono As String, genero As String, cedula As String, usuario As String, contraseña As String, id As Short, fechaContrato As Date, contacto As String)
        MyBase.New(nombre, apellido, edad, email, telefono, genero, cedula)
        Me.Usuario = usuario
        Me.Contraseña = contraseña
        Me.Id = id
        Me.FechaDeContrato = fechaContrato
        Me.Contacto = contacto

    End Sub

    Public Sub New(usuario As String, contraseña As String)
        MyBase.New()
        Me.Usuario = usuario
        Me.Contraseña = contraseña
    End Sub

    Public Overrides Function toString() As String
        Return MyBase.toString() & "   Id:  " & Id & "Fecha de contrato:     " & FechaDeContrato & "Contacto:    " & Contacto
    End Function
End Class
