using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chattter
{
    public partial class ChatForm : Form
    {   
        public delegate void AddMessage(string message);
        private string userName;
        private string userType;
        private const int port = 54545;
        private const string broadcastAddress = "255.255.255.255";
        private UdpClient receivingClient;
        private UdpClient sendingClient;
        private Thread receivingThread;

        public ChatForm()
        {
            InitializeComponent();

            this.Load += new EventHandler(ChatForm_Load);
            sendButton.Click += new EventHandler(SendButton_Click);
        }

        void ChatForm_Load(object sender, EventArgs e)
        {
            this.Hide();

            using (LoginForm loginForm = new LoginForm())
            {
                loginForm.ShowDialog();

                if (loginForm.UserName == "")
                    Close();
                else
                {
                    userName = loginForm.UserName;
                    userType = loginForm.UserType;
                    Show();
                }
            }

            sendButton.Focus();

            InitializeSender();
            InitializeReceiver();
        }

        private void InitializeSender()
        {
            sendingClient = new UdpClient(broadcastAddress, port);
            sendingClient.EnableBroadcast = true;
        }

        private void InitializeReceiver()
        {
            receivingClient = new UdpClient(port);

            ThreadStart start = new ThreadStart(Receiver);
            receivingThread = new Thread(start);
            receivingThread.IsBackground = true;
            receivingThread.Start();
        }

        void SendButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            sendTextBox.Text = sendTextBox.Text.TrimEnd();

            if (!string.IsNullOrEmpty(sendTextBox.Text))
            {
                string toSend = userName + ": " + sendTextBox.Text;
                byte[] data = Encoding.ASCII.GetBytes(toSend);
                sendingClient.Send(data, data.Length);
                sendTextBox.Text = "";
            }

            sendTextBox.Focus();
        }

        private void Receiver()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
            AddMessage messageDelegate = MessageReceived;

            while (true)
            {
                byte[] data = receivingClient.Receive(ref endPoint);
                string message = Encoding.ASCII.GetString(data);
                Invoke(messageDelegate, message);
            }
        }

        private void MessageReceived(string message)
        {
            ChatRichTextBox.Text += message + "\n";
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(userType == "student")
            {
                RateForm rateForm = new RateForm();
                rateForm.ShowDialog();
            }
        }

        private void SendTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                SendMessage();
            }
        }
    }
}
