using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Net;

namespace ChatServer
{
    public class Program
    {
        public static Hashtable clientsList = new Hashtable();

        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
            serverSocket.Start();

            Console.WriteLine("Chat Server Started ....");

            TcpClient clientSocket;

            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                clientSocket.ReceiveBufferSize = 4096;

                byte[] bytesFrom = new byte[4096];

                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);

                string dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                clientsList.Add(dataFromClient, clientSocket);

                NotifyAboutNewUser(dataFromClient);

                Console.WriteLine(dataFromClient + " Joined chat room ");
                ClientHandler client = new ClientHandler();
                client.StartClient(clientSocket, dataFromClient);
            }
        }

        private static void NotifyAboutNewUser(string userName)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                byte[] broadcastBytes = null;
                broadcastBytes = Encoding.ASCII.GetBytes("<< " + userName + " joined to chat >>");
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }

        public static void Broadcast(string message, string userName)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                byte[] broadcastBytes = null;
                broadcastBytes = Encoding.ASCII.GetBytes(userName + " : " + message);
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }
    }


    public class ClientHandler
    {
        private TcpClient clientSocket;
        private string clientName;

        public void StartClient(TcpClient clientSocket, string clientName)
        {
            this.clientSocket = clientSocket;
            this.clientName = clientName;
            Thread clientThread = new Thread(DoChat);
            clientThread.Start();
        }

        private void DoChat()
        {
            byte[] bytesFrom = new byte[4096];
            string dataFromClient;

            while (true)
            {
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine("From client - " + clientName + " : " + dataFromClient);
                    Program.Broadcast(dataFromClient, clientName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    } 
}
