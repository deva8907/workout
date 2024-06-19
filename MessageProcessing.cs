using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace workout
{
    class ProgramStart
    {
        static void Main()
        {
            var orderProcessorFactory = new OrderProcessorFactory();
            orderProcessorFactory.AddProcessor("Order", new ProcessOrder(new DiscountService(), new OrderRepository()));
            orderProcessorFactory.AddProcessor("Cancellation", new CancelOrder(new OrderRepository()));
            new MessageProcessingService(new Retriever(), orderProcessorFactory).Process();
        }
    }
    class MessagePayload
    {
        public int OrderId { get; set; }
        public string MessageType { get; set; }
        public Client Client { get; set; }
    }
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StateAbbreviation { get; set; }
    }
    interface IMessageRetriver
    {
        List<MessagePayload> GetMessages();
    }
    interface IDiscountService
    {
        decimal GetDiscount(MessagePayload messagePayload);
    }
    interface IOrderRepository
    {
        void AddOrder(MessagePayload messagePayload, decimal discount);
        void CancelOrder(MessagePayload messagePayload, int orderId);
    }
    interface IOrderProcessor
    {
        void Process(MessagePayload messagePayload);
    }
    class ProcessOrder(IDiscountService discountService, IOrderRepository orderRepository) : IOrderProcessor
    {
        private readonly IDiscountService _discountService = discountService;
        private readonly IOrderRepository _orderRepository = orderRepository;

        public void Process(MessagePayload messagePayload)
        {
            decimal discount = _discountService.GetDiscount(messagePayload);
            _orderRepository.AddOrder(messagePayload, discount);
        }
    }
    class CancelOrder(IOrderRepository orderRepository) : IOrderProcessor
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public void Process(MessagePayload messagePayload)
        {
            _orderRepository.CancelOrder(messagePayload, messagePayload.OrderId);
        }
    }
    class OrderProcessorFactory
    {
        private Dictionary<string, IOrderProcessor> _processors = new Dictionary<string, IOrderProcessor>();
        public void AddProcessor(string messageType, IOrderProcessor orderProcessor)
        {
            _processors.Add(messageType, orderProcessor);
        }

        public IOrderProcessor GetProcessor(string messageType)
        {
            return _processors.ContainsKey(messageType) ? _processors[messageType] : throw new KeyNotFoundException("processor not found");
        }
    }
    class OrderRepository : IOrderRepository
    {
        public void AddOrder(MessagePayload messagePayload, decimal discount)
        {
            //suggest to use EF core or some ORM for better isolated unit testing and separation of concerns
            //suggest that the previous implementation has sql injection vulnerability
        }

        public void CancelOrder(MessagePayload messagePayload, int orderId)
        {
            //suggest to use EF core or some ORM for better isolated unit testing and separation of concerns
            //suggest that the previous implementation has sql injection vulnerability
        }
    }
    class DiscountService : IDiscountService
    {
        private readonly Dictionary<string, decimal> _discounts;
        public DiscountService()
        {
            _discounts.Add("CA", 5);
            _discounts.Add("MI", 6);
        }
        public decimal GetDiscount(MessagePayload messagePayload)
        {
            if (_discounts.ContainsKey(messagePayload.Client.StateAbbreviation))
                return _discounts[messagePayload.Client.StateAbbreviation];
            return 0;
        }
    }
    class Retriever : IMessageRetriver
    {
        public List<MessagePayload> GetMessages()
        {
            List<string> filePaths = new List<string>()
            {
                "file1.json",
                "file2.json",
                "file3.json"
            };
            var result = new List<MessagePayload>();
            foreach (var path in filePaths)
            {
                string content = File.ReadAllText(path);
                result.Add(JsonSerializer.Deserialize<MessagePayload>(content));
            }
            return result;
        }
    }
    class MessageProcessingService(IMessageRetriver retriver, OrderProcessorFactory orderProcessorFactory)
    {
        private readonly IMessageRetriver _retriever = retriver;
        private readonly OrderProcessorFactory _orderProcessorFactory = orderProcessorFactory;

        public void Process()
        {
            var messages = _retriever.GetMessages();
            foreach (var message in messages)
            {
                var processor = _orderProcessorFactory.GetProcessor(message.MessageType);
                processor.Process(message);
            }
        }
    }
}