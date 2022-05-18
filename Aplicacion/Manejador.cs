class Manejador
{
   public static string input(string msg){
       Console.Write(msg);
       return Console.ReadLine()??"";
   }

   public static string confirmar(string campo, string valor){
       string final = valor;

       var tmp_nuevo = input($@"El nombre actual de {campo} es: {valor}
       Escriba el nuevo valor del personaje o presione enter para dejarlo tal y como esta:
       ");

       if(tmp_nuevo != ""){
           final = tmp_nuevo;
       }

       return final;
   }



    public static void agregarPersonaje(){
        personajes p = new personajes();

        p.Nombre = input("Nombre: ");
        p.Apellido = input("Apellido: ");
        p.Serie = input("Serie: ");
        p.Telefono =input("Telefono: ");
        p.Correo =input("Correo: ");
        using (personajesContext context = new personajesContext()){
            context.Personajes.Add(p);
            context.SaveChanges();
        }
    }

    public static void mostrarPersonajes(){
        using(personajesContext context = new personajesContext()){

            var Personajes = context.Personajes;
            foreach (personajes p in Personajes){
                Console.WriteLine($"{p.id} |{p.Nombre} | {p.Apellido} | {p.Serie} | {p.Telefono} | {p.Correo}");
            }
        }
    }

    public static void modificarPersonaje(){
        Console.Clear();
        personajes person = new personajes();
        personajesContext context = new personajesContext();

        Console.WriteLine(@"Modificar un personaje...");

        while(person.id < 1){
            Console.WriteLine("Seleccione el personaje o presion 0 para salir de aqui...");
            mostrarPersonajes();

            var tmp = input("id: ");
            var tmp_it = 0;
            if(tmp == "0"){
                return;
            }

            int.TryParse(tmp, out tmp_it);
            var rs = context.Personajes.Where(k=>k.id == tmp_it).ToList();
            if(rs.Count > 0){
                person = rs[0];
            }else {
                Console.WriteLine("No se encontro el personaje");
            }
        }

        person.Nombre = confirmar("Nombre ", person.Nombre);
        person.Apellido = confirmar("Apellido ", person.Apellido);
        person.Serie = confirmar("Serie ", person.Serie);
        person.Telefono = confirmar("Telefono ", person.Telefono);
        person.Correo = confirmar("Correo ", person.Correo);  
        context.Update(person);
        context.SaveChanges();              
    }
    public static void eliminarPersonajes(){
        Console.Clear();
        
        personajes per = new personajes();
        personajesContext contexto = new personajesContext();

        Console.WriteLine("Eliminar personajes....");

        while(per.id < 1){
            Console.WriteLine("Seleccione el personaje o presion 0 para salir de aqui...");
            mostrarPersonajes();

            var tmp = input("id: ");
            var tmp_it = 0;
            if(tmp == "0"){
                return;
            }
            int.TryParse(tmp, out tmp_it);
            var rs = contexto.Personajes.Where(k=>k.id == tmp_it).ToList();
            if(rs.Count > 0){
                per = rs[0];
            }else {
                Console.WriteLine("No se encontro el personaje");
            }
        }

    contexto.Remove(per);
    contexto.SaveChanges();

    }

    
}