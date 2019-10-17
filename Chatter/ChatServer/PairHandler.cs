using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public class PairHandler
    {
        private ClientHandler handler1 = new ClientHandler();
        private ClientHandler handler2 = new ClientHandler();
        public string ClientName1 { get; }
        public string ClientName2 { get;}

        public TcpClient Client1 { get;}
        public TcpClient Client2 { get;}
        
        public PairHandler(TcpClient clientSocket1, string clientName1, TcpClient clientSocket2, string clientName2)
        {
            ClientName1 = clientName1;
            ClientName2 = clientName2;
            Client1 = clientSocket1;
            Client2 = clientSocket2;
            handler1.StartClient(clientSocket1, clientSocket2, clientName1);
            handler2.StartClient(clientSocket2, clientSocket1, clientName2);
        }
    }
}
