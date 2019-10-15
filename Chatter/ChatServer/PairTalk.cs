using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public class PairTalk
    {
        public string ClientName1 { get; set; }
        public string ClientName2 { get; set; }

        public PairTalk(string clientName1, string clientName2)
        {
            ClientName1 = clientName1;
            ClientName2 = clientName2;
            LoadChatHistory();
        }

        private void LoadChatHistory()
        {
            
        }
    }
}
