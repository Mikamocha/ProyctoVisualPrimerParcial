Module Module1

    Sub Main()
        Console.WriteLine("Bienvenidos a ........")
        Console.WriteLine("Escoga una opcion... :")
        Console.WriteLine("1.   Inicie sesion como Vendedor")
        Console.WriteLine("2.   Inicie sesion como Administrador")
        Console.WriteLine("Opcion:     ")
        Dim usuario, contraseña As String
        Dim opcion As Integer = Console.ReadLine()
        Select Case opcion
            Case 1
                Dim vendedor As Vendedor
                Console.Write("Digite su usuario    :")
                usuario = Console.ReadLine()
                Console.Write("Digite su contraseña     :")
                contraseña = Console.ReadLine()
                vendedor = New Vendedor(usuario, contraseña)
            Case 2
                Dim administrador As Administrador
                Console.Write("Digite su usuario    :")
                usuario = Console.ReadLine()
                Console.Write("Digite su contraseña     :")
                contraseña = Console.ReadLine()
                administrador = New Administrador(usuario, contraseña)
        End Select

        Console.ReadLine()

    End Sub

End Module
