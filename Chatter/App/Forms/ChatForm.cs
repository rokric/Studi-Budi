using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using App.App;

namespace App
{
    public partial class ChatForm : Form
    {
        private IConversation conversation;
        private string userName;

        public ChatForm(IUser user)
        {
            InitializeComponent();
            conversation = new Conversation(user, PrintMessage);
            conversation.ConnectToServer();
            Text = userName;
            messageTextBox.Focus();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            conversation.SendMessage(messageTextBox.Text.Trim());
            messageTextBox.Text = "";
        }

        private void MessageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                conversation.SendMessage(messageTextBox.Text.Trim());
                messageTextBox.Text = "";
            }
        }

        public void PrintMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    PrintMessage(message);
                });
            }
            else
            {
                chatTextBox.Text = chatTextBox.Text + message + Environment.NewLine;
            }

        }
    }
}
