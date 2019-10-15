using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.App
{
    public class Conversation : IConversation
    {
        private TcpClient clientSocket = new TcpClient();
        private NetworkStream serverStream = default;
        private string readData = null;
        private IUser user;
        private string teacherName;
        private Action<string> PrintMessage;

        public Conversation(IUser user, Action<string> PrintMessage, string teacherName) 
        {
            this.user = user;
            this.teacherName = teacherName;
            this.PrintMessage = PrintMessage;
        }


        public void ConnectToServer()
        {
            clientSocket.Connect("localhost", 8888);
            serverStream = clientSocket.GetStream();

            byte[] outStream = Encoding.ASCII.GetBytes(user.GetDecryptedUserName()+":"+teacherName + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            Thread clientThread = new Thread(ReceiveMessage);
            clientThread.Start();
        }

        public void ReceiveMessage()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                byte[] inStream = new byte[4096];
                int bytesRead = serverStream.Read(inStream, 0, inStream.Length);
                string returnData = Encoding.ASCII.GetString(inStream, 0, bytesRead);
                readData = returnData;
                PrintMessage(returnData);
            }
        }

        public void SendMessage(string message)
        {
            byte[] outStream = Encoding.ASCII.GetBytes(message + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        public void DisconnectFromServer()
        {
            throw new NotImplementedException();
        }
    }
}
