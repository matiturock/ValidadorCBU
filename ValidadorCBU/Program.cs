namespace ValidadorCBU;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("VALIDAR CBU");
        const string CBU = "2850015740095451234988";

        Console.WriteLine(CBU);

        try
        {
            var validador = new ValidadorCbu(CBU);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ha ocurrido una excepcion: {ex.Message}");
        }
        finally 
        { 
            Console.WriteLine("Fin del programa");
        }
    }
}