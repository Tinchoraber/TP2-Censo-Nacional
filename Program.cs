using System.Collections.Generic;
Dictionary<int, Persona> DicPersonas = new Dictionary<int, Persona>();
 int numero;
do
{
    Console.WriteLine("1.Cargar Alumno");
    Console.WriteLine("2.Obtener Estadísticas del Censo");
    Console.WriteLine("3.Buscar Persona");
    Console.WriteLine("4.Modificar Mail de una Persona.");
    Console.WriteLine("5. Salir");
    numero = ingresarNumero("Ingrese un numero:");
    switch(numero)
    {
        case 1:
        cargarNuevaPersona();
        break;
        case 2:
        obtenerEstadisticasCenso();
        break;
    }
} while (numero!=5);

int ingresarNumero(string msj)
{
 int devolver;
 Console.WriteLine(msj);
 devolver = int.Parse(Console.ReadLine());
 while(devolver < 1 && devolver > 5)
 {
    Console.WriteLine("Ingresaste mal los numeros, volve a hacerlo");
    Console.WriteLine(msj);
    devolver = int.Parse(Console.ReadLine());
 }
 return devolver;
}
void cargarNuevaPersona()
{
 int dni = ingresarDni();
 string apellido = ingresarTexto("Ingrese su apellido");
 string nombre = ingresarTexto("Ingrese su nombre");
 string email = ingresarTexto("Ingrese su email");
 DateTime fechaNacimiento = ingresarFecha();
 Persona unaPersona = new Persona(dni, apellido, nombre, fechaNacimiento, email);
 DicPersonas.Add(dni, unaPersona);
 Console.WriteLine("Se ha cargado la persona " + nombre + " " + apellido + " al diccionario de Personas");
}
int ingresarDni()
{ 
 int dni;
 Console.WriteLine("Ingrese su DNI");
 dni = int.Parse(Console.ReadLine());
 while(dni < 0 && DicPersonas.ContainsKey(dni))
 {
    Console.WriteLine("Ingresaste mal los datos, volve a hacerlo");
    Console.WriteLine("Ingrese su DNI");
    dni = int.Parse(Console.ReadLine());
 }
 return dni;
}
string ingresarTexto(string msj)
{
    string texto;
    Console.WriteLine(msj);
    texto = Console.ReadLine();
    return texto;
}
DateTime ingresarFecha()
{
    string fechaString;
    Console.WriteLine("Ingrese su fecha de nacimiento(aaaa/mm/dd)");
    fechaString = Console.ReadLine();
    DateTime fecha;
    while(!DateTime.TryParse(fechaString, out fecha))
    {
        Console.WriteLine("Ingresaste mal los datos, volve a hacerlo");
        Console.WriteLine("Ingrese su fecha de nacimiento");
        fechaString = Console.ReadLine();
    }
    return fecha;
}
void obtenerEstadisticasCenso()
{
int cont = 0, acum = 0;
 foreach (Persona item in DicPersonas.Values)
 {
    if(DicPersonas.Count == 0)
    {
        Console.WriteLine("No hay personas cargadas en la lista");
    }
    else
    {
        Console.WriteLine("Cantidad de personas: " + DicPersonas.Count);
    }
    acum = acum + item.obtenerEdad();
    int promedio = acum / DicPersonas.Count;
    if(item.obtenerEdad() > 16)
    {
        cont++;
    }
    Console.WriteLine("Cantidad de personas habilitadas para votar: " + cont);
    Console.WriteLine("Promedio de edad: " + promedio);
 }
}


