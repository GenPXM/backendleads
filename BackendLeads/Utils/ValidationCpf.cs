namespace BackendLeads.Utils
{
    public class ValidationCpf
    {
        public ValidationCpf()
        {

        }

        public bool ValidaCpf(string Cpf)
        {
            int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            if (Cpf.Length != 11)
                return false;
            Cpf = Cpf.Trim();
            Cpf = Cpf.Replace(".", "").Replace("-", "");
            if (Cpf.Distinct().Count() == 1)
                return false;

            tempCpf = Cpf.Substring(0, 9);

            soma = 0;
            for (int cont = 0; cont < 9; cont++)
                soma += int.Parse(tempCpf[cont].ToString()) * mult1[cont];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;

            soma = 0;
            for (int cont = 0; cont < 10; cont++)
                soma += int.Parse(tempCpf[cont].ToString()) * mult2[cont];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return Cpf.EndsWith(digito);


        }
    }
}
