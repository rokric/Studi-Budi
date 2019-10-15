using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.App
{
    public interface ILogin
    {
        bool IsCorrect(string userName, string password, string profession);
    }
}
