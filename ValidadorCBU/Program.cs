﻿namespace ValidadorCBU;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("VALIDAR CBU");
        const string CBU = "2850015740095451234988";

        var validadorCbu = new ValidadorCbu(CBU);

        Console.WriteLine(validadorCbu);
        Console.WriteLine(validadorCbu.bancoActual);
    }
}