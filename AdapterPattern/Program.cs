using System;

namespace AdapterPattern // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // If you want to change the Apapter, you can create a new instance from JsonBankApiAdapter Class because this takes the
            // implementation from same interface
            IBankApi xmlBankApiApapter = new JsonBankApiAdapter();
            var result = xmlBankApiApapter.ExecuteTransaction(new TransferTransaction() {
                FromIban = "TR760009901234567800100001",
                ToIban = "TR760009901234567800100002",
                Amount = 232154375
            });
            Console.WriteLine(result);
        }
    }

    public interface IBankApi
    {
        bool ExecuteTransaction(TransferTransaction transferTransaction);
    }

    public class XMLBankApiAdapter : IBankApi
    {
        private readonly XMLBankApi _xmlBankApi;
        public XMLBankApiAdapter()
        {
            _xmlBankApi = new();
        }
        public bool ExecuteTransaction(TransferTransaction transferTransaction)
        {
            return _xmlBankApi.ExecuteTransaction(transferTransaction);
        }
    }

    public class JsonBankApiAdapter : IBankApi
    {
        private readonly JsonBankApi _jsonBankApi;
        public JsonBankApiAdapter()
        {
            _jsonBankApi = new();
        }

        public bool ExecuteTransaction(TransferTransaction transferTransaction)
        {
            return _jsonBankApi.ExecuteTransaction(transferTransaction);
        }
    }

    class JsonBankApi : IBankApi
    {
        public bool ExecuteTransaction(TransferTransaction transferTransaction)
        {
            var json = $$"""
                        {
                        "FromIban":"{{transferTransaction.FromIban}}",
                        "ToIban":"{{transferTransaction.ToIban}}",
                        "Amount":"{{transferTransaction.Amount:C2}}"
                        }
                        """;
            Console.WriteLine(json);
            Console.WriteLine($"{GetType().Name} worked.");
            return true;
        }
    }

    public class XMLBankApi : IBankApi
    {
        public bool ExecuteTransaction(TransferTransaction transferTransaction)
        {
            var xml = $"""
                        <TransferTransaction>
                            <FromIban>{transferTransaction.FromIban}</FromIban>
                            <Toban>{transferTransaction.ToIban}</ToIban>
                            <Amount>{transferTransaction.Amount:C2}</Amount>
                        </TransferTransaction>
                        """;
            Console.WriteLine(xml);
            Console.WriteLine($"{GetType().Name} worked.");
            return true;
        }
    }

    //Model
    public class TransferTransaction
    {
        public string FromIban { get; set; }
        public string ToIban { get; set; }
        public decimal Amount { get; set; }
    }
}