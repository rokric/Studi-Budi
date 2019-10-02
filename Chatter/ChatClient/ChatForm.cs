using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace ChatClient
{
    public partial class ChatForm : Form
    {
        private TcpClient clientSocket = new TcpClient();
        private NetworkStream serverStream = default;
        private string readData = null;
        private string userName;

        public ChatForm(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            this.Text = userName;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            byte[] outStream = Encoding.ASCII.GetBytes(messageTextBox.Text + "$");
            messageTextBox.Text = "";
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        public void ConnectToServer()
        {
            clientSocket.Connect("localhost", 8888);
            serverStream = clientSocket.GetStream();

            byte[] outStream = Encoding.ASCII.GetBytes(userName + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            Thread clientThread = new Thread(GetMessage);
            clientThread.Start();
        }

        private void GetMessage()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                byte[] inStream = new byte[4096];
                int bytesRead = serverStream.Read(inStream, 0, inStream.Length);
                string returnData = Encoding.ASCII.GetString(inStream, 0, bytesRead);
                readData = returnData;
                PrintMessage();
            }
        }

        private void PrintMessage()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(PrintMessage));
            }
            else
            {
                chatTextBox.Text = chatTextBox.Text + readData + Environment.NewLine;
            }
               
        }

    }
}
