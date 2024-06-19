using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace workout
{
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
    class Retriever
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
    class MessageProcessing
    {
        public void Process()
        {
            Retriever retriever = new Retriever();
            var messages = retriever.GetMessages();
            foreach (var message in messages)
            {
                decimal discount = 0;
                if (message.MessageType == "Order")
                {
                    if (message.Client.StateAbbreviation == "CA")
                    {
                        discount = 5;
                    }
                    else if (message.Client.StateAbbreviation == "MI")
                    {
                        discount = 6;
                    }
                    else
                    {
                        discount = 0;
                    }

                    PlaceOrder(message.MessageType, message.Client, discount);
                }
                if (message.MessageType == "Cancellation")
                {
                    CancelOrder(message.OrderId, message.MessageType);
                }
            }
        }

        private void CancelOrder(int orderId, string messageType)
        {
            string query = $"UPDATE Order SET Status = {messageType} WHERE OrderId = {orderID}";
            RunSql(query);
        }

        private void PlaceOrder(string messageType, Client client, decimal discount)
        {
            string query = $"INSERT INTO Order(ClientId, ClientName, Discount, Status) VALUES({client.Id}, {client.Name}, {discount}, {messageType})";
            RunSql(query);
        }



        private void RunSql(string query)
        {
            //method to run sql commands
        }
    }
}