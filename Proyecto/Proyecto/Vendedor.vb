Public Class Vendedor
    Inherits Persona
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


End Class
