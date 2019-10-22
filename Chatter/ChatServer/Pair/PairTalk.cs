using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public class PairTalk : IEquatable<PairTalk>
    {
        public string ClientName1 { get; set; }
        public string ClientName2 { get; set; }


        public PairTalk(string clientName1, string clientName2)
        {
            ClientName1 = clientName1;
            ClientName2 = clientName2;
        }

        public bool Equals(PairTalk other)
        {
            if (ClientName1.Equals(other.ClientName1) && ClientName2.Equals(other.ClientName2))
            {
                return true;
            }

            return false;
        }
    }
}
