class Persona
{
 public int DNI{get;set;}
 public string Apellido{get;set;}
 public string Nombre{get;set;}
 public DateTime FechaNacimiento{get;set;}
 public string Email{get;set;}
 public Persona(int dni, string apellido, string nombre, DateTime fechaNacimiento, string email)
 {
    DNI = dni;
    Apellido = apellido;
    Nombre = nombre;
    FechaNacimiento = fechaNacimiento;
    Email = email;
 }
 int edad;
 public int obtenerEdad()
 {
    DateTime fechaNacimientoHoy = new DateTime(DateTime.Today.Year, FechaNacimiento.Month, FechaNacimiento.Day);
    if(fechaNacimientoHoy < DateTime.Today)
    {
        edad = DateTime.Today.Year - FechaNacimiento.Year;
    }
    else
    {
        edad = DateTime.Today.Year - FechaNacimiento.Year -1;
    }
    return edad;
 }
 bool puede;
 public bool puedeVotar()
 {
    if(edad >= 16)
    {
        puede = true;
    }
    else
    {
        puede = false;
    }
    return puede;
 }
}
