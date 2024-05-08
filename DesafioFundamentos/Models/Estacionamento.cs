using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>(); // Alteração: Lista de objetos Veiculo

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo(string placa)
        {
            Veiculo novoVeiculo = new Veiculo(placa, DateTime.Now); // Cria um novo objeto Veiculo
            veiculos.Add(novoVeiculo); // Adiciona o veículo à lista
            Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso.");
        }

        public void RemoverVeiculo(string placa)
        {
            Veiculo veiculo = veiculos.FirstOrDefault(v => v.Placa.ToUpper() == placa.ToUpper()); // Encontra o veículo na lista
            if (veiculo != null)
            {
                int horasEstacionado = (int)Math.Ceiling((DateTime.Now - veiculo.HorarioEntrada).TotalHours);
                decimal valorTotal = precoInicial + (precoPorHora * horasEstacionado);
                veiculos.Remove(veiculo);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo.Placa}, Horário de Entrada: {veiculo.HorarioEntrada}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }

    public class Veiculo
    {
        public string Placa { get; set; }
        public DateTime HorarioEntrada { get; set; }

        public Veiculo(string placa, DateTime horarioEntrada)
        {
            Placa = placa;
            HorarioEntrada = horarioEntrada;
        }
    }
}
