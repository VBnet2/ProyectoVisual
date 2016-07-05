﻿Public Class MenuPrincipal


    Protected vectorFacturas As VectorFacturas
    Protected arregloUsuarios As New ArrayList()
    Dim auxImpuesto As Double = 0.14
    Dim auxEspecial As Double = 0.12
    Dim auxTarjeta As Double = 0.01
    Dim auxElectronico As Double = 0.04
    Dim auxResta As Double = 0
    Dim detallesArray As New ArrayList
    Protected arregloCategorias As ArrayList


    Public Property Usuarios() As ArrayList
        Get
            Return arregloUsuarios
        End Get
        Set(ByVal value As ArrayList)
            arregloUsuarios = value
        End Set
    End Property


    Public Property Categorias() As ArrayList
        Get
            Return arregloCategorias
        End Get
        Set(ByVal value As ArrayList)
            arregloCategorias = value
        End Set
    End Property


    Public Sub Iniciar()

        Dim user, pass, idAux As String
        Dim activo As Usuario

        Do
            Console.Clear()
            Console.WriteLine("Aplicación en VB.Net para facturación..." & vbNewLine)
            Console.Write("Nombre de usuario:  ")
            user = Console.ReadLine()
            Console.Write("Contraseña:  ")
            pass = Console.ReadLine()
            idAux = ValidarUsuario(user, pass)
        Loop While idAux = "No existe"

        activo = ObtenerIdUsuario(idAux)


        Select Case activo.TipoUser

            Case "administrador"

                MenuAdministrador(user, pass, idAux)

            Case "vendedor"

                MenuVendedor(user, pass, idAux)

        End Select

    End Sub


    Public Sub MenuAdministrador(user As String, pass As String, idAux As String)
        Dim opcionAdmin As Integer
        Dim opcionProductos As Integer
        Dim opcionCategorias As Integer
        Dim opcionIva As Integer
        Dim auxCategoria As String
        Dim auxCantidad As Integer
        Dim auxNombre As String
        Dim auxPrecio As Double

        Do
            Console.Clear()
            Console.WriteLine("Usuario Administrador " & idAux & " Logeado... " & user & vbNewLine)
            Console.WriteLine("1.- Categorías")
            Console.WriteLine("2.- Productos")
            Console.WriteLine("3.- IVA diferenciado")
            Console.WriteLine("4.- Salir de la sesión")
            Console.WriteLine("5.- Salir del sistema")
            Console.Write("Ingrese una opción: ")
            opcionAdmin = Console.ReadLine()

            Select Case opcionAdmin

                Case "1"
                    'Administrador de categorias
                    Console.Clear()
                    Console.WriteLine("1.- Añadir categoria")
                    Console.WriteLine("2.- Borrar categoria")
                    Console.WriteLine("3.- Regresar")
                    Console.WriteLine("4.- Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    opcionCategorias = Console.ReadLine()

                    Select Case opcionCategorias
                        Case "1"

                            Console.Clear()
                            Console.WriteLine("Ingrese la categoria (añadir):  ")
                            auxCategoria = Console.ReadLine()
                            Categorias.Add(New Categoria(auxCategoria))

                            MenuAdministrador(user, pass, idAux)

                        Case "2"

                            Console.Clear()
                            Console.WriteLine("Ingrese la categoria (borrar): ")
                            auxCategoria = Console.ReadLine()

                            For Each cat As Categoria In Categorias
                                If cat.Nombre = auxCategoria Then
                                    Categorias.Remove(cat)
                                End If
                            Next

                            MenuAdministrador(user, pass, idAux)

                        Case "3"

                            MenuAdministrador(user, pass, idAux)

                        Case "4"

                            Environment.Exit(0)

                    End Select


                Case "2"
                    'Administrador de productos
                    Console.Clear()
                    Console.WriteLine("1.- Añadir productos")
                    Console.WriteLine("2.- Borrar productos")
                    Console.WriteLine("3.- Regresar")
                    Console.WriteLine("4.- Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    opcionCategorias = Console.ReadLine()

                    Select Case opcionProductos
                        Case "1"

                            Console.Clear()
                            Console.WriteLine("Ingrese la categoria del producto: ")

                            For Each cat As Categoria In Categorias
                                Console.WriteLine(cat.Nombre)
                            Next

                            Console.WriteLine()
                            auxCategoria = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese cantidad que desea añadir: " & vbNewLine)
                            auxCantidad = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese Nombre del producto: " & vbNewLine)
                            auxNombre = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese precio del producto: " & vbNewLine)
                            auxPrecio = Console.ReadLine()

                            For Each cat As Categoria In Categorias
                                If auxCategoria = cat.Nombre Then
                                    cat.AñadirProducto(auxCantidad, auxNombre, auxPrecio, auxCategoria)
                                End If
                            Next

                            'vectorProductos.AñadirProducto(auxCantidad, auxNombre, auxPrecio)
                            MenuAdministrador(user, pass, idAux)

                        Case "2"

                            Console.Clear()
                            Console.WriteLine("Ingrese la categoria del producto: ")

                            For Each cat As Categoria In Categorias
                                Console.WriteLine(cat.Nombre)
                            Next

                            Console.WriteLine()
                            auxCategoria = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese cantidad que desea Borrar: " & vbNewLine)
                            auxCantidad = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese Nombre del producto: " & vbNewLine)
                            auxNombre = Console.ReadLine()
                            Console.WriteLine(vbNewLine & "Ingrese precio del producto: " & vbNewLine)
                            auxPrecio = Console.ReadLine()

                            For Each cat As Categoria In Categorias
                                If auxCategoria = cat.Nombre Then
                                    cat.BorrarProducto(auxCantidad, auxNombre)
                                End If
                            Next

                            'vectorProductos.BorrarProducto(auxCantidad, auxNombre)

                            MenuAdministrador(user, pass, idAux)

                        Case "3"

                            MenuAdministrador(user, pass, idAux)

                        Case "4"

                            Environment.Exit(0)

                    End Select


                Case "3"

                    'Iva diferenciado
                    Console.Clear()
                    Console.WriteLine("1.- Ingresar IVA por provincia")
                    Console.WriteLine("2.- Ingresar Valor Devuelto por tipo de pago")
                    Console.WriteLine("3.- Regresar")
                    Console.WriteLine("4.- Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    opcionIva = Console.ReadLine()

                    Select Case opcionIva

                        Case "1"

                            Console.Clear()
                            Console.WriteLine("IVA Especial: 0.12 (Manabí - Esmeraldas) - IVA Normal: 0.14 (Resto del Ecuador)" & vbNewLine)
                            Console.WriteLine("Ingrese Iva Normal: ")
                            auxImpuesto = Console.ReadLine()
                            Console.WriteLine("Ingrese Iva Especial: ")
                            auxEspecial = Console.ReadLine()
                            MenuAdministrador(user, pass, idAux)

                        Case "2"

                            Console.Clear()
                            Console.WriteLine("Valor Devuelto: 0 (Efectivo)" & "-" & auxTarjeta & "(Tarjeta De Credito)" & "-" & auxElectronico & "(Dinero Electronico)" & vbNewLine)
                            Console.WriteLine("Ingrese Valor Devuelto (Tarjeta De Credito) :   ")
                            auxTarjeta = Console.ReadLine()
                            Console.WriteLine("Ingrese Valor Devuelto (Dinero Electronico): ")
                            auxElectronico = Console.ReadLine()
                            MenuAdministrador(user, pass, idAux)

                        Case "3"

                            MenuAdministrador(user, pass, idAux)

                        Case "4"

                            Environment.Exit(0)

                    End Select


                Case "4"

                    Iniciar()

                Case "5"

                    Environment.Exit(0)

            End Select

        Loop Until (opcionAdmin = "5")

    End Sub


    Public Sub MenuVendedor(user As String, pass As String, idAux As String)

        Dim opcionVendedor As Integer

        Console.Clear()
        Console.WriteLine("Usuario Vendedor " & idAux & " Logeado... " & user & vbNewLine)
        Console.WriteLine("1.- Facturar")
        Console.WriteLine("2.- Salir de la sesión")
        Console.WriteLine("3.- Salir del sistema")
        Console.Write("Ingrese una opción: ")
        opcionVendedor = Console.ReadLine()

        Select Case opcionVendedor

            Case "1"

                facturar()

            Case "2"

                Iniciar()

            Case "3"

                Environment.Exit(0)

        End Select

    End Sub


    Public Sub facturar()
        Dim siono As String
        Dim nombre As String
        Dim ruc_ci As String
        Dim cantidads As String = ""
        Dim cantidad As Integer
        Dim auxSecuencial As Long = 1001
        Dim descripcion As String
        Dim vunitario As Double = 0
        Dim vtotal As Double = 0
        Dim subtotal As Double = 0
        Dim iva As Double = 0.14
        Dim totalFactura As Double = 0
        Dim efectivo As Double = 0
        Dim tarjeta As Double = 0
        Dim dineroElect As Double = 0
        Dim cambio As Double = 0

        Dim formaPago As Integer = 0

        Dim cliente As Cliente
        Dim producto As Producto
        Dim posx As Integer = 0
        Dim posy As Integer = 0




        Console.Clear()
        Console.Write("¿Desea su factura con datos?s/n: ")


        siono = Console.ReadLine

        If siono = "s" Or siono = "S" Then

            Console.Clear()
            Console.Write("Sr(es): ")
            nombre = Console.ReadLine()
            Console.Write("R.U.C./C.I: ")
            ruc_ci = Console.ReadLine()

            cliente = New Cliente(nombre, ruc_ci)

            For Each f As Factura In vectorFacturas.ArrayFacturas
                auxSecuencial = f.Secuencial + 1

            Next


            Console.WriteLine("CANTIDAD           PRODUCTO      ValorUnit     ValorTotal     ")
            posy = 2
            Do While siono = "S" Or siono = "s"
                posx = 2
                posy += 1
                Console.SetCursorPosition(posx, posy)


                cantidads = Console.ReadLine()
                If cantidads = "" Then
                    Exit Do

                Else
                    cantidad = CInt(cantidads)
                End If

                posx += 19




                Console.WriteLine("")

                Console.SetCursorPosition(posx, posy)
                descripcion = Console.ReadLine()
                Console.WriteLine("")



                producto = ValidarProducto(cantidad, descripcion)
                posx += 16
                Console.SetCursorPosition(posx, posy)
                vunitario = producto.Precio
                Console.WriteLine(vunitario)
                Console.WriteLine("")
                posx += 14
                Console.SetCursorPosition(posx, posy)
                vtotal = producto.Precio * cantidad
                Console.WriteLine("$" & vtotal)

                Dim detalle As New Detalle(cantidad, descripcion, vunitario, vtotal) 'esto debe ir a factura
                detallesArray.Add(detalle)



                Console.WriteLine("")
                Console.Write("")





            Loop

            If cantidads = "" Then
                posx = 40
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("-----------------------")
                posy += 1
                Console.SetCursorPosition(posx, posy)
                For Each d As Detalle In detallesArray
                    subtotal += d.PrecioTotal
                Next

                Console.Write("SUBTOTAL: $" & subtotal)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                iva = iva * subtotal
                Console.Write(" IVA 14%: $" & iva)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                totalFactura = iva + subtotal
                Console.Write("   TOTAL: $" & totalFactura)




                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("EFECTIVO: $")
                efectivo = Console.ReadLine()
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("TCREDITO: $")
                tarjeta = Console.ReadLine()
                Dim auxta As Double = 0
                If tarjeta > 0 Then
                    auxta = auxTarjeta * totalFactura

                End If
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("D.ELECTR: $")
                dineroElect = Console.ReadLine()
                Dim auxel As Double = 0
                If dineroElect > 0 Then
                    auxel = auxElectronico * subtotal
                End If
                posy += 1
                Console.SetCursorPosition(posx, posy)
                'operacion(14%      -   4%    -      1%)
                cambio = ((efectivo + tarjeta + dineroElect) - totalFactura)
                'cambiar formato de cambio
                Console.Write("CAMBIO  : $" & cambio)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("--------------------")
                posy += 1

                auxResta = ((efectivo + tarjeta + dineroElect) - totalFactura) - auxel - auxta
                Console.SetCursorPosition(posx, posy)
                If efectivo > totalFactura Then
                    auxResta = 0
                End If
                Console.Write("Te ahorras: $" & auxResta)



                Dim factura As New Factura(auxSecuencial, cliente, detallesArray, subtotal, iva, totalFactura, efectivo, tarjeta, dineroElect, cambio, auxResta)
                vectorFacturas.ArrayFacturas.Add(factura)

                For Each fact As Factura In vectorFacturas.ArrayFacturas
                    fact.mostrarFactura()
                Next



                'factura.mostrarFactura()
                detallesArray.Clear()
                Console.ReadLine()
                Iniciar()
            End If




            Console.ReadLine()


        ElseIf siono = "n" Or siono = "N" Then
            'Console.WriteLine("Sr(es): Usuario final")

            Console.Clear()
            Console.WriteLine("Sr(es):  Usuario final")
            nombre = "Usuario final"


            cliente = New Cliente(nombre)

            For Each f As Factura In vectorFacturas.ArrayFacturas
                auxSecuencial = f.Secuencial + 1

            Next


            Console.WriteLine("CANTIDAD           PRODUCTO      ValorUnit     ValorTotal     ")
            posy = 2
            Do While siono = "n" Or siono = "N"
                posx = 2
                posy += 1
                Console.SetCursorPosition(posx, posy)


                cantidads = Console.ReadLine()
                If cantidads = "" Then
                    Exit Do

                Else
                    cantidad = CInt(cantidads)
                End If

                posx += 19




                Console.WriteLine("")

                Console.SetCursorPosition(posx, posy)
                descripcion = Console.ReadLine()
                Console.WriteLine("")



                producto = ValidarProducto(cantidad, descripcion)
                posx += 16
                Console.SetCursorPosition(posx, posy)
                vunitario = producto.Precio
                Console.WriteLine(vunitario)
                Console.WriteLine("")
                posx += 14
                Console.SetCursorPosition(posx, posy)
                vtotal = producto.Precio * cantidad
                Console.WriteLine("$" & vtotal)

                Dim detalle As New Detalle(cantidad, descripcion, vunitario, vtotal) 'esto debe ir a factura
                detallesArray.Add(detalle)



                Console.WriteLine("")
                Console.Write("")





            Loop

            If cantidads = "" Then
                posx = 40
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("-----------------------")
                posy += 1
                Console.SetCursorPosition(posx, posy)
                For Each d As Detalle In detallesArray
                    subtotal += d.PrecioTotal
                Next

                Console.Write("SUBTOTAL: $" & subtotal)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                iva = iva * subtotal
                Console.Write(" IVA 14%: $" & iva)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                totalFactura = iva + subtotal
                Console.Write("   TOTAL: $" & totalFactura)




                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("EFECTIVO: $")
                efectivo = Console.ReadLine()
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("TCREDITO: $")
                tarjeta = Console.ReadLine()
                Dim auxta As Double = 0
                If tarjeta > 0 Then
                    auxta = auxTarjeta * totalFactura

                End If
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("D.ELECTR: $")
                dineroElect = Console.ReadLine()
                Dim auxel As Double = 0
                If dineroElect > 0 Then
                    auxel = auxElectronico * subtotal
                End If
                posy += 1
                Console.SetCursorPosition(posx, posy)
                'operacion(14%      -   4%    -      1%)
                cambio = ((efectivo + tarjeta + dineroElect) - totalFactura)
                'cambiar formato de cambio
                Console.Write("CAMBIO  : $" & cambio)
                posy += 1
                Console.SetCursorPosition(posx, posy)
                Console.Write("--------------------")
                posy += 1

                auxResta = ((efectivo + tarjeta + dineroElect) - totalFactura) - auxel - auxta
                Console.SetCursorPosition(posx, posy)
                If efectivo > totalFactura Then
                    auxResta = 0
                End If
                Console.Write("Te ahorras: $" & auxResta)



                Dim factura As New Factura(auxSecuencial, cliente, detallesArray, subtotal, iva, totalFactura, efectivo, tarjeta, dineroElect, cambio, auxResta)
                vectorFacturas.ArrayFacturas.Add(factura)

                For Each fact As Factura In vectorFacturas.ArrayFacturas
                    fact.mostrarFactura()
                Next



                'factura.mostrarFactura()
                detallesArray.Clear()
                Console.ReadLine()
                Iniciar()
            End If




            Console.ReadLine()


        End If




    End Sub

    Public Function ValidarUsuario(usuario As String, pass As String)
        Dim id As String = "No existe"
        Dim tipo As String = "Ninguno"
        Dim nombre As String = "Sin nombre"
        For Each user As Usuario In arregloUsuarios
            If user.Usuario = usuario And user.Password = pass Then
                id = user.Id
                tipo = user.TipoUser
                nombre = user.Nombre
            End If
        Next

        If id = "No existe" Then
            Console.WriteLine("Usuario y/o contraseña incorrectos, vuelva a intentarlo.")
            Console.ReadLine()
        End If

        'If id <> "No existe" Then
        '    Console.WriteLine("Usuario Logeado... " & nombre & " - " & tipo)
        'End If


        Return id

    End Function


    Public Function ObtenerIdUsuario(id As String) As Usuario
        For Each user As Usuario In arregloUsuarios
            If user.Id = id Then
                Return user
            End If
        Next
        Return Nothing
    End Function


    Public Sub CargarCategorias()
        Dim accion As Categoria = New Categoria("Accion")
        Dim aventura As Categoria = New Categoria("Aventura")
        Dim terror As Categoria = New Categoria("Terror")
        Categorias.Add(accion)
        Categorias.Add(aventura)
        Categorias.Add(terror)
    End Sub


    Public Sub AñadirCategoria(categoria As Categoria)
        Categorias.Add(categoria)
    End Sub


    Public Function ValidarProducto(cantidad As Integer, nombProd As String)
        Dim stock As Integer = 0
        Dim name As String = nombProd
        Dim prod As Producto


        For Each cat As Categoria In arregloCategorias
            Dim aux As Integer = 0


            For Each producto As Producto In cat.Productos

                producto = cat.obtenerProducto(aux)
                If name = producto.Nombre And producto.CantidadStock > cantidad Then

                    prod = producto
                    producto.CantidadStock -= cantidad
                    'Console.WriteLine("Ahora tenemos:  " & producto.CantidadStock)

                ElseIf (producto.CantidadStock < cantidad And nombProd = producto.Nombre) Then
                    'Console.WriteLine("*Lo sentimos*")
                    'Console.WriteLine("Tenemos un stock de: " & producto.CantidadStock)

                ElseIf nombProd IsNot producto.Nombre Then
                    'Console.WriteLine(vectorProductos.ArrayProductos.Count)'obtengo la cantidad de  productos


                End If
                aux += 1
            Next

        Next





        'For Each producto As Producto In vectorProductos.ArrayProductos
        '    If name = producto.Nombre And producto.CantidadStock > cantidad Then

        '        prod = producto
        '        producto.CantidadStock -= cantidad
        '        'Console.WriteLine("Ahora tenemos:  " & producto.CantidadStock)

        '    ElseIf (producto.CantidadStock < cantidad And nombProd = producto.Nombre) Then
        '        'Console.WriteLine("*Lo sentimos*")
        '        'Console.WriteLine("Tenemos un stock de: " & producto.CantidadStock)

        '    ElseIf nombProd IsNot producto.Nombre Then
        '        'Console.WriteLine(vectorProductos.ArrayProductos.Count)'obtengo la cantidad de  productos


        '    End If
        'Next




        Return prod
    End Function

    Public Sub buscarFactura(secuencial As Long) ' esto  va en el menu administrador 
        For Each f As Factura In vectorFacturas.ArrayFacturas
            If secuencial = f.Secuencial Then
                f.mostrarFactura()
            End If
        Next
    End Sub

    Public Sub CargarProductos()
        Dim prod1 As Producto = New Producto(100, "a", 40.0, "Accion")
        Dim prod2 As Producto = New Producto(200, "b", 50.0, "Accion")
        Dim prod3 As Producto = New Producto(300, "c", 60.0, "Accion")

        For Each cat As Categoria In arregloCategorias
            If cat.Nombre = "Accion" Then
                cat.Productos.Add(prod1)
                cat.Productos.Add(prod2)
                cat.Productos.Add(prod3)
            End If
        Next

        Dim prod4 As Producto = New Producto(400, "d", 70.0, "Aventura")
        Dim prod5 As Producto = New Producto(500, "e", 80.0, "Aventura")
        Dim prod6 As Producto = New Producto(600, "f", 90.0, "Aventura")

        For Each cat As Categoria In arregloCategorias
            If cat.Nombre = "Aventura" Then
                cat.Productos.Add(prod4)
                cat.Productos.Add(prod5)
                cat.Productos.Add(prod6)
            End If
        Next

        Dim prod7 As Producto = New Producto(700, "g", 100.0, "Terror")
        Dim prod8 As Producto = New Producto(800, "h", 110.0, "Terror")
        Dim prod9 As Producto = New Producto(900, "i", 120.0, "Terror")

        For Each cat As Categoria In arregloCategorias
            If cat.Nombre = "Terror" Then
                cat.Productos.Add(prod7)
                cat.Productos.Add(prod8)
                cat.Productos.Add(prod9)
            End If
        Next

    End Sub



    Public Sub New(arreglo As ArrayList)
        Me.Usuarios = arreglo
        Me.Categorias = New ArrayList
        CargarCategorias()
        CargarProductos()

        Me.vectorFacturas = New VectorFacturas
    End Sub

End Class
