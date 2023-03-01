using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ValidadorCBU;

public class ValidadorCbu
{
    int CantidadNumerosCBU { get; } = 22;
    int[] patronBancoSucursal = new int[] { 7, 1, 3, 9, 7, 1, 3 };
    int[] patronCuenta = new int[] { 3, 9, 7, 1, 3, 9, 7, 1, 3, 9, 7, 1, 3 };
    string bancosBBDD { get; set; } = "";
    public string? bancoActual { get; set; } = "";
	string Cbu { get; init; }

    // Bloque 1
    string CodigoBanco { get; set; } = "";
    string CodigoSucursal { get; set; } = "";
    string DigitoControl1 { get; set; } = "";

    // Bloque 2
    string CodigoCuenta { get; set; } = "";
    string DigitoControl2 { get; set; } = "";
	public ValidadorCbu(string cbu)
	{
        /*
        * CBU 285 0015 7 4009545123498 8
        * i   012 3456 7 8901234567890 1
        *     BBB SSSS D CCCCCCCCCCCCC D
        *     3   4    1 13            1
        */   
        
        if (ValidarDigitos(cbu) &&
            cbu.Length == CantidadNumerosCBU)
        {
            Cbu = cbu;
            CodigoBanco = cbu.Substring(0, 3);
            CodigoSucursal = cbu.Substring(3, 4);
            CodigoCuenta = cbu.Substring(8, 13);
            DigitoControl1 = cbu[7].ToString();
            DigitoControl2 = cbu[21].ToString();
        }
        else
        {
            throw new ArgumentException("El CBU deben ser 22 digitos");
        }

        if (!ValidarCodigoBanco())
            throw new ArgumentException("El banco no es correcto");

        if (!ValidarBancoYSucursal())
            throw new ArgumentException("El codigo del banco y sucursal no es correcto");

        if (!ValidarCuenta())
            throw new ArgumentException("El codigo de la cuenta no es correcto");
    }

    private bool ValidarDigitos(string cbu)
    {
        foreach (char c in cbu)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }
    
    private bool ValidarCodigoBanco()
    {
        // cargar los bancos del txt
        bancosBBDD = CargarBancos();
        // validar banco
        if (string.IsNullOrEmpty(bancosBBDD))
            return false;
        else
            // cargar variable de bancoActual
            bancoActual = CargarBancoActual(bancosBBDD);
        return true;
    }

    private string CargarBancos()
    {
        string bancos = "";
        string path = @"C:\Users\Mati\OneDrive\Documentos\bancos.txt";
        using (StreamReader sr = new StreamReader(path))
        {
            string? linea;
            while ((linea = sr.ReadLine()) != null)
            {
                bancos += linea;
                bancos += "\n";
            }
        }

        return bancos;
    }

    private string? CargarBancoActual(string bancosBBDD)
    {
        // creara diccionario
        // cargar diccionario
        // validar y obtener banco
        var bancosPorID = new Dictionary<string, string>();
        string[] bancos = bancosBBDD.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        foreach (var banco in bancos)
        {
            string[] codigoYBanco = banco.Split("\t");
            bancosPorID.Add(codigoYBanco[0], codigoYBanco[1]);
        }
                
        if (bancosPorID.TryGetValue(CodigoBanco, out var _bancoActual))
        {
            return _bancoActual;
        }

        return null;
    }

    private bool ValidarBancoYSucursal()
    {
        int suma = 0;
        string codigoBancoYSucursal = CodigoBanco + CodigoSucursal;

        for (int i = 0; i < codigoBancoYSucursal.Length; i++)
        {
            suma += 
                int.Parse(codigoBancoYSucursal[i].ToString()) * 
                int.Parse(patronBancoSucursal[i].ToString());
        }

        int modulo = suma % 10;

        if (10 - modulo == int.Parse(DigitoControl1.ToString()))
        {
            return true;
        }

        return false;
    }

    private bool ValidarCuenta()
    {
        int suma = 0;

        for (int i = 0; i < CodigoCuenta.Length; i++)
        {
            suma +=
                int.Parse(CodigoCuenta[i].ToString()) *
                int.Parse(patronCuenta[i].ToString());
        }

        int modulo = suma % 10;

        if (10 - modulo == int.Parse(DigitoControl2.ToString()))
        {
            return true;
        }

        return false;
    }
}
