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
}
