namespace Clientes.Mvc.Helpers
{
    public static class TelefoneHelper
    {
        public static string FormatTelefone(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                return string.Empty;

            numero = new string(numero.Where(char.IsDigit).ToArray());

            if (numero.Length == 10)
                return Convert.ToUInt64(numero).ToString(@"(00) 0000-0000");

            if (numero.Length == 11)
                return Convert.ToUInt64(numero).ToString(@"(00) 00000-0000");

            return numero;
        }
    }
}
