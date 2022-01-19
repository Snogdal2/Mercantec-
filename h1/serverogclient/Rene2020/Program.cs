using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace Rene2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("server eller client");
            string vælg = Console.ReadLine();

            if (vælg == "server")
            {
                server p = new server();
                p.servere();
            }
            else if (vælg == "client")
            {
                client.cliente();
            }
        }
    }
    public class server
    {
        public List<TcpClient> clients = new List<TcpClient>();
        public void servere()
        {
            Console.WriteLine("hvad er porten?");

            string portservere = Console.ReadLine();

            int portserveren = int.Parse(portservere);

            IPAddress IP = IPAddress.Any;

            IPEndPoint localEndpoint = new IPEndPoint(IP, portserveren);

            TcpListener listener = new TcpListener(localEndpoint);

            listener.Start();

            AcceptClients(listener);

            Console.WriteLine("Awaiting Clients");

            TcpClient client = listener.AcceptTcpClient();

            NetworkStream stream = client.GetStream();
            
            while (0 < 1)
            {   
                ReceiveMessage(stream);

                Console.WriteLine("Skrev din besked her.");
                string text = Console.ReadLine();

                byte[] buffer = Encoding.UTF8.GetBytes(text);

                stream.Write(buffer, 0, buffer.Length);
            }

        }
        
        public static async void ReceiveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];

            int numberofbytesRead = await stream.ReadAsync(buffer, 0, 256);

            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberofbytesRead);

            Console.WriteLine("\n" + receivedMessage);
        }


        public async void AcceptClients(TcpListener listener)
        {
            bool isRunning = true;
            while (isRunning)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                clients.Add(client);
                NetworkStream stream = client.GetStream();
                ReceiveMessage(stream);
                Console.WriteLine("Skrev din besked her.");
                string text = Console.ReadLine();

                byte[] buffer = Encoding.UTF8.GetBytes(text);

                stream.Write(buffer, 0, buffer.Length);

            }
        }
    }

    class client
    {
        public static void cliente()
        {
            TcpClient client = new TcpClient();

            Console.WriteLine("porten?");
            string porte = Console.ReadLine();
            int port = int.Parse(porte);

            IPAddress IP = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(IP, port);

            client.Connect(endPoint);
            NetworkStream stream = client.GetStream();

            while (0 < 1)
            {
                
                ReceiveMessage(stream);

                Console.WriteLine("Skrev din beskred her.");
                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);

                stream.Write(buffer, 0, buffer.Length);
            }

            
        }

        public static async void ReceiveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];

            int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.WriteLine("\n" + receivedMessage);
        }

    }  

}
