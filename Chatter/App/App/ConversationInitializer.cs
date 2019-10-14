using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.App
{
    public class ConversationInitializer
    {
        public ConversationInitializer(IUser user)
        {
            ChatForm chatForm = new ChatForm(user.GetDecryptedUserName());
            chatForm.ConnectToServer();
            chatForm.ShowDialog();
        }
    }
}
