bool continuar = true;

while(continuar){
    Console.Clear();
    Console.WriteLine(@"
    Programa para tus personajes favoritos

    1. Agregar Personajes.

    2. Mostrar Personajes.

    3. Modificar Personajes.

    4. Eliminar Personajes.

    x. Salir

    ");

    string opcion = Manejador.input("Opcion: ");
    switch (opcion.ToLower()){
        case "1":
        Console.Clear();
        Manejador.agregarPersonaje();
        break;

        case "2":
        Console.Clear();
        Manejador.mostrarPersonajes();
        Console.ReadKey();
        break;

        case "3":
        Console.Clear();
        Manejador.modificarPersonaje();
        break;

        case "4":
        Manejador.eliminarPersonajes();
        break;

        case "x":
        continuar = false;
        break;
        default:
        Console.WriteLine("Opcion no valida");
        break;
    }

}