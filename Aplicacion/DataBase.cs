using Microsoft.EntityFrameworkCore;

public class personajes{


    public int id {get; set;}
    public string Nombre {get; set;}

    public string Apellido {get; set;}

    public string Serie {get; set;}

    public string Telefono {get; set;}

    public string Correo {get; set;}
}

//Base de Datos
public class personajesContext : DbContext
{
    public DbSet<personajes> Personajes {get; set;}
    public personajesContext(){

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=personajes.db");
    }
}