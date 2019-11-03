using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyBuddyLogic
{
    public class Conversation : IConversation
    {
        private TcpClient clientSocket = new TcpClient();
        private NetworkStream serverStream = default;
        private string readData = null;
        private IUser user;
        private string teacherName;
        private Action<string> PrintMessage;
        private Thread clientThread;
        private volatile bool connected;

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

            clientThread = new Thread(ReceiveMessage);
            clientThread.Start();
            connected = true;
        }

        public void ReceiveMessage()
        {
            while (connected)
            {
                try
                {
                    serverStream = clientSocket.GetStream();
                    byte[] inStream = new byte[4096];
                    int bytesRead = serverStream.Read(inStream, 0, inStream.Length);
                    string returnData = Encoding.ASCII.GetString(inStream, 0, bytesRead);
                    readData = returnData;
                    PrintMessage(returnData);
                }
                catch (System.IO.IOException)
                {
                    connected = false;
                    Console.WriteLine("Client [" + user.GetDecryptedUserName() + "] disconnected: unable to read data.");
                }
               
            }
        }

        public void SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                byte[] outStream = Encoding.ASCII.GetBytes(message + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
        }

        public void DisconnectFromServer()
        {
            SendMessage("code:log out");
            connected = false;
        }
    }
}
