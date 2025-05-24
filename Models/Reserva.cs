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
            // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            int hospedesRecebidos = hospedes?.Count ?? 0;
            int hospedesPresentes = this.Hospedes?.Count ?? 0;
            bool podeAcomodar = (Suite?.Capacidade ?? 0) >= (hospedesRecebidos + hospedesPresentes);

            if (podeAcomodar)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception("Capacidade da suíte é menor que o número de hóspedes recebido.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            // Retorna o valor da diária
            decimal valor = this.DiasReservados * (Suite?.ValorDiaria ?? 0);

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (this.DiasReservados >= 10)
            {
                valor *= 0.9m;
            }

            return valor;
        }
    }
}