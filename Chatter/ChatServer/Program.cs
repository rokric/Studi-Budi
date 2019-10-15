using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Net;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ChatServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }

    }

    public class Server
    {
        public Hashtable clientsList = new Hashtable();
        private List<PairTalk> pairs = new List<PairTalk>();

        private PairTalk CheckIfPairExist()
        {
            List<string> names = new List<string>();
            PairTalk pair = null;

            foreach (DictionaryEntry item in clientsList)
            {
                names.Add(item.Key.ToString());
            }

            foreach (PairTalk pairTalk in pairs)
            {
                if (names.Contains(pairTalk.ClientName1) && names.Contains(pairTalk.ClientName2))
                {
                    pair = pairTalk;
                    pairs.Remove(pairTalk);
                    break;
                }
            }

            return pair;
        }

        public void UpdatePairTalk(string client1, string client2)
        {
            pairs.Add(new PairTalk(client1, client2));
        }

        private void NotifyAboutNewUser(string userName)
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

        public static void Broadcast(string message, string userName, TcpClient client1, TcpClient client2)
        {

            List<TcpClient> pair = new List<TcpClient>();
            pair.Add(client1);
            pair.Add(client2);

            foreach (TcpClient tcpClient in pair)
            {
                NetworkStream broadcastStream = tcpClient.GetStream();
                byte[] broadcastBytes = null;
                broadcastBytes = Encoding.ASCII.GetBytes(userName + " : " + message);
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }

        public void Start()
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

                string[] data = dataFromClient.Split(':');

                clientsList.Add(data[0], clientSocket);

                if (!data[1].Equals(""))
                {
                    UpdatePairTalk(data[0], data[1]);
                }

                PairTalk pair = CheckIfPairExist();

                Console.WriteLine(pairs.Count);

                if (pair != null)
                {

                    PairHandler pairHandler = new PairHandler(
                        (TcpClient)clientsList[pair.ClientName1], pair.ClientName1,
                        (TcpClient)clientsList[pair.ClientName2], pair.ClientName2);

                    Console.WriteLine("conversattion started");
                }

                //NotifyAboutNewUser(dataFromClient);

                //Console.WriteLine(dataFromClient + " Joined chat room ");
                // ClientHandler client = new ClientHandler();
                //client.StartClient(clientSocket, dataFromClient);
            }
        }
    }

    public class PairHandler
    {
        private ClientHandler handler1 = new ClientHandler();
        private ClientHandler handler2 = new ClientHandler();

        public PairHandler(TcpClient clientSocket1, string clientName1, TcpClient clientSocket2, string clientName2)
        {
            handler1.StartClient(clientSocket1, clientSocket2, clientName1);
            handler2.StartClient(clientSocket2, clientSocket1, clientName2);
        }
    }

    public class ClientHandler
    {
        private TcpClient clientSocket;
        private TcpClient clientSocketFriend;
        private string clientName;

        public void StartClient(TcpClient clientSocket, TcpClient clientSocketFriend, string clientName)
        {
            this.clientSocket = clientSocket;
            this.clientSocketFriend = clientSocketFriend;
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
                    Server.Broadcast(dataFromClient, clientName, clientSocket, clientSocketFriend);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }

    /*public class ClientHandler
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
    } */
}
