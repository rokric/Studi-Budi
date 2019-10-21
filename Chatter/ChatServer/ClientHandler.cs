using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    public class ClientHandler
    {
        private PairHandler pairHandler;
        private TcpClient clientSocket;
        private TcpClient clientSocketFriend;
        private string clientName;
        private Thread clientThread;

        public ClientHandler(PairHandler handler)
        {
            pairHandler = handler;
            clientSocket = handler.Client1;
            clientSocketFriend = handler.Client2;
            clientName = handler.ClientName1;
        }

        public void StartClient(TcpClient clientSocket, TcpClient clientSocketFriend, string clientName)
        {
            this.clientSocket = clientSocket;
            this.clientSocketFriend = clientSocketFriend;
            this.clientName = clientName;

            clientThread = new Thread(DoChat);
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
                    if(!pairHandler.Connected)
                    {
                        Console.WriteLine(pairHandler.ClientName1 + " and " + pairHandler.ClientName2 + " have ended conversation.");
                        Console.WriteLine(">>saving conversation history");
                        pairHandler.SaveChatHistory();
                        break;
                    }

                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                    if(dataFromClient.Equals("code:log out"))
                    {
                        Console.WriteLine(clientName + ": logged out");
                        Server.Broadcast("<<Disconnected. Conversation has ended.>>", clientName, clientSocket, clientSocketFriend);
                        pairHandler.Connected = false;           
                    }
                    else
                    {
                        Console.WriteLine("From client - " + clientName + " : " + dataFromClient);
                        if(pairHandler.Connected == true)
                        {
                            Server.Broadcast(dataFromClient, clientName, clientSocket, clientSocketFriend);
                            pairHandler.AddNewRecord(clientName + " : " + dataFromClient);
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
