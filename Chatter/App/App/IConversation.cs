using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.App
{
    public interface IConversation
    {
        void ConnectToServer();
        void ReceiveMessage();
        void SendMessage(string message);
        void DisconnectFromServer();
    }
}
