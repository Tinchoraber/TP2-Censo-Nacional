using System.Collections.Generic;
Dictionary<int, Persona> DicPersonas = new Dictionary<int, Persona>();
int numero, dniOtro;
do
{
    Console.WriteLine("1.Cargar Alumno");
    Console.WriteLine("2.Obtener Estadísticas del Censo");
    Console.WriteLine("3.Buscar Persona");
    Console.WriteLine("4.Modificar Mail de una Persona.");
    Console.WriteLine("5. Salir");
    numero = ingresarNumero("Ingrese un numero:");
    switch (numero)
    {
        case 1:
            cargarNuevaPersona();
            break;
        case 2:
            obtenerEstadisticasCenso();
            break;
        case 3:
            buscarPersona();
            break;
        case 4:
            modificarMailPersona();
            break;
    }
} while (numero != 5);

int ingresarNumero(string msj)
{
    int devolver;
    Console.WriteLine(msj);
    devolver = int.Parse(Console.ReadLine());
    while (devolver < 1 && devolver > 5)
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
    while (dni < 0 && DicPersonas.ContainsKey(dni))
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
    while (!DateTime.TryParse(fechaString, out fecha))
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
        acum = acum + item.obtenerEdad();
        if (item.puedeVotar() == true)
        {
            cont++;

        }
    }
    if (DicPersonas.Count == 0)
    {
        Console.WriteLine("No hay personas cargadas en la lista");
    }
    Console.WriteLine("Cantidad de personas: " + DicPersonas.Count);
    Console.WriteLine("Cantidad de personas habilitadas para votar: " + cont);
    Console.WriteLine("Promedio de edad: " + acum / DicPersonas.Count);

}
void buscarPersona()
{
    dniOtro = ingresarOtroDni();
    foreach (int item in DicPersonas.Keys)
    {
        if (item == dniOtro)
        {
            Console.WriteLine("El nombre de la persona es: " + DicPersonas[item].Nombre);
            Console.WriteLine("El apellido de la persona es: " + DicPersonas[item].Apellido);
            Console.WriteLine("La fecha de nacimiento de la persona es: " + DicPersonas[item].FechaNacimiento);
            Console.WriteLine("El email de la persona es: " + DicPersonas[item].Email);
            Console.WriteLine("La edad de la persona es: " + DicPersonas[item].obtenerEdad());
            if (DicPersonas[item].puedeVotar() == true)
            {
                Console.WriteLine("Puede votar");
            }
            else
            {
                Console.WriteLine("No puede votar");
            }
        }
    }
}
int ingresarOtroDni()
{
    int devolver;
    Console.WriteLine("Ingrese otro DNI para buscarlo en la lista");
    devolver = int.Parse(Console.ReadLine());
    while (devolver < 0)
    {
        Console.WriteLine("Ese DNI no es valido");
        Console.WriteLine("Ingrese otro DNI para buscarlo en la lista");
        devolver = int.Parse(Console.ReadLine());
    }
    if (!DicPersonas.ContainsKey(devolver))
    {
        Console.WriteLine("No se encuentra el DNI");
    }
    return devolver;
}
void modificarMailPersona()
{
    int dni3 = ingresarOtroDni();
    string email2 = ingresarTexto("Ingrese otro mail para actualizarlo");
    if (DicPersonas.ContainsKey(dni3))
    {
        DicPersonas[dni3].Email = email2;
        Console.WriteLine("El nuevo email de la persona es: " + DicPersonas[dni3].Email);
    }
}

