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
            
            // Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido.
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                //Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                throw new Exception(" A quantidade de hóspedes excede a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            //Retorna a quantidade de hóspedes (propriedade Hospedes)
            int quantidade = Hospedes.Count;
            return quantidade;
        }

        public decimal CalcularValorDiaria()
        {
            //Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria

            decimal valor = 0;
            decimal desconto = 0;
            decimal vlrTotal = 0;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            valor = DiasReservados*Suite.ValorDiaria;
            if (DiasReservados >= 10)
            {
                desconto = valor * 10/100;
               // Console.WriteLine($"Foi atribuido ao hospede o desconto no valor de {desconto.ToString("C")}");
                vlrTotal = valor - desconto;
            }
            else
            {
                vlrTotal = valor;

            }
            return  vlrTotal;

        }
    }
}