using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace ChatClient
{
    public partial class ChatForm : Form
    {
        private TcpClient clientSocket = new TcpClient();
        private NetworkStream serverStream = default(NetworkStream);
        private string readData = null;
        private string userName;

        public ChatForm(string userName)
        {
            this.userName = userName;
            InitializeComponent();
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
            readData = "Conected to Chat Server ...";
            PrintMessage();
            clientSocket.Connect("127.0.0.1", 8888);
            serverStream = clientSocket.GetStream();

            byte[] outStream = Encoding.ASCII.GetBytes(userName + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            Thread ctThread = new Thread(GetMessage);
            ctThread.Start();
        }

        private void GetMessage()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                byte[] inStream = new byte[4096];
                int bytesRead = serverStream.Read(inStream, 0, inStream.Length);
                string returndata = Encoding.ASCII.GetString(inStream, 0, bytesRead);
                readData = "" + returndata;
                PrintMessage();
            }
        }

        private void PrintMessage()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(PrintMessage));
            else
                chatTextBox.Text = chatTextBox.Text + Environment.NewLine + " >> " + readData;
        }

    }
}
