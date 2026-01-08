namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }


        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new InvalidOperationException(
                    "A capacidade da suíte é menor que o número de hóspedes"
                );
            }
        }


        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }


        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }


        // Concede um desconto de 10%, caso os dias reservados forem maior ou igual a 10
        private decimal CalcularDesconto(decimal valor)
        {
            if (DiasReservados >= 10)
            {
                valor -= valor * 0.1m;
            }

            return valor;
        }


        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            valor = CalcularDesconto(valor);
            return valor;
        }
    }
}