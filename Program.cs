using System;
using System.Collections.Generic;

namespace FinancialApp
{
 
    public interface IOperation
    {
        string GetDetails();
        decimal GetTotalValue();
    }

   
    public abstract partial class Operation : IOperation
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public string AssetCode { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public Operation(string assetCode, int quantity, decimal price)
        {
            if (quantity <= 0) throw new ArgumentException("A quantidade deve ser maior que zero.");
            if (price <= 0) throw new ArgumentException("O preço deve ser maior que zero.");

            Id = _nextId++;
            Date = DateTime.Now;
            AssetCode = assetCode.ToUpper();
            Quantity = quantity;
            Price = price;
        }

        public decimal GetTotalValue() => Quantity * Price;

        public abstract string GetDetails();
    }

  
    public abstract partial class Operation
    {
        public string GetFormattedDate() => Date.ToString("dd/MM/yyyy HH:mm");
    }

    
    public class BuyOperation : Operation
    {
        public BuyOperation(string assetCode, int quantity, decimal price)
            : base(assetCode, quantity, price) { }

        public override string GetDetails()
        {
            return $"COMPRA: [{Id:D3}] {GetFormattedDate()} - {AssetCode} x{Quantity} @ R$ {Price:F2} = R$ {GetTotalValue():F2}";
        }
    }

   
    public class SellOperation : Operation
    {
        public SellOperation(string assetCode, int quantity, decimal price)
            : base(assetCode, quantity, price) { }

        public override string GetDetails()
        {
            return $"VENDA:  [{Id:D3}] {GetFormattedDate()} - {AssetCode} x{Quantity} @ R$ {Price:F2} = R$ {GetTotalValue():F2}";
        }
    }

    class Program
    {
        static List<Operation> operations = new List<Operation>();

        static void Main(string[] args)
        {
            int option = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("--- Sistema de Ativos Financeiros ---");
                Console.WriteLine("1 - Registrar operação");
                Console.WriteLine("2 - Listar operações");
                Console.WriteLine("3 - Mostrar valor total");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                try
                {
                    option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            RegisterOperation();
                            break;
                        case 2:
                            ListOperations();
                            break;
                        case 3:
                            ShowTotalValue();
                            break;
                        case 0:
                            Console.WriteLine("Saindo do sistema...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Digite apenas números inteiros válidos para o menu.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }

                if (option != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (option != 0);
        }

        static void RegisterOperation()
        {
            Console.Clear();
            Console.WriteLine("--- Registrar Operação ---");

            try
            {
                Console.Write("Tipo (1=Compra, 2=Venda): ");
                if (!int.TryParse(Console.ReadLine(), out int type) || (type != 1 && type != 2))
                {
                    throw new InvalidOperationException("Tipo de operação inválido. Use 1 (Compra) ou 2 (Venda).");
                }

                Console.Write("Cód Ativo (ex: PETR4, VALE3): ");
                string assetCode = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(assetCode))
                {
                    throw new ArgumentException("O código do ativo não pode estar em branco.");
                }

                Console.Write("Quantidade: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    throw new FormatException("A quantidade deve ser um número inteiro numérico.");
                }

                Console.Write("Preço: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    throw new FormatException("O preço deve ser um número decimal válido (use vírgula para decimais).");
                }

                Operation newOperation;

                if (type == 1)
                {
                    newOperation = new BuyOperation(assetCode, quantity, price);
                }
                else
                {
                    newOperation = new SellOperation(assetCode, quantity, price);
                }

                operations.Add(newOperation);
                Console.WriteLine("\nOperação registrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERRO AO REGISTRAR]: {ex.Message}");
            }
        }

        static void ListOperations()
        {
            Console.Clear();
            Console.WriteLine("--- Histórico de Operações ---\n");

            if (operations.Count == 0)
            {
                Console.WriteLine("Nenhuma operação registrada ainda.");
                return;
            }

           
            foreach (var op in operations)
            {
                Console.WriteLine(op.GetDetails());
            }
        }

        static void ShowTotalValue()
        {
            Console.Clear();
            Console.WriteLine("--- Resumo de Valores ---\n");

            decimal totalBuy = 0;
            decimal totalSell = 0;

            foreach (var op in operations)
            {
                
                if (op is BuyOperation)
                {
                    totalBuy += op.GetTotalValue();
                }
                else if (op is SellOperation)
                {
                    totalSell += op.GetTotalValue();
                }
            }

            Console.WriteLine($"Valor total de compras:  R$ {totalBuy:F2}");
            Console.WriteLine($"Valor total de vendas:   R$ {totalSell:F2}");
        }
    }
}