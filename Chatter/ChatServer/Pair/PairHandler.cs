using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    public class PairHandler
    {
        private ClientHandler handler1;
        private ClientHandler handler2;
        public string ClientName1 { get; }
        public string ClientName2 { get;}

        public TcpClient Client1 { get;}
        public TcpClient Client2 { get;}

        public  bool Connected
        { 
            get { return connected; }
            set { connected = value; } 
        }

        private volatile bool connected;

        private string encryptedClientName1;
        private string encryptedClientName2;

        private List<string> oldChatHistory = new List<string>();
        private volatile List<string> newChatHistroy = new List<string>();

        public List<string> NewChatHistory
        {
            get { return newChatHistroy; }
        }
        public List<string> OldChatHistory
        {
            get { return oldChatHistory; }
        }

        public PairHandler(TcpClient clientSocket1, string clientName1, TcpClient clientSocket2, string clientName2)
        {
            ClientName1 = clientName1;
            ClientName2 = clientName2;
            Client1 = clientSocket1;
            Client2 = clientSocket2;
            encryptedClientName1 = Encryptor.Encrypt(ClientName1);
            encryptedClientName2 = Encryptor.Encrypt(ClientName2);
            connected = true;
            handler1 = new ClientHandler(this);
            handler2 = new ClientHandler(this);
            handler1.StartClient(clientSocket1, clientSocket2, clientName1);
            handler2.StartClient(clientSocket2, clientSocket1, clientName2);
            LoadChatHistory();
        }

        private void LoadChatHistory()
        {
            DataWriter dataWriter = new DataWriter();
            int id1 = int.Parse(dataWriter.GetUserIdByNick(encryptedClientName1));
            int id2 = int.Parse(dataWriter.GetUserIdByNick(encryptedClientName2));

            foreach (string line in dataWriter.GetSavedChatHistory(id1, id2))
            {
                oldChatHistory.Add(line);
            }
        }

        public void AddNewRecord(string message)
        {
            newChatHistroy.Add(message);
        }

        public void SaveChatHistory()
        {
            DataWriter dataWriter = new DataWriter();
            int id1 = int.Parse(dataWriter.GetUserIdByNick(encryptedClientName1));
            int id2 = int.Parse(dataWriter.GetUserIdByNick(encryptedClientName2));

            //if(newChatHistroy.Count < 10)
           // {
                dataWriter.UpdateChatHistory(id1, id2, NewChatHistory);
            //}
        
        }
    }
}
