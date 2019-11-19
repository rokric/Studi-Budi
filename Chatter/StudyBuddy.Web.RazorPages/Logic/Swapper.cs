using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class Swapper
    {
        public void Swap<T>(ref T item1, ref T item2)
        {
            T temp;
            temp = item1;
            item1 = item2;
            item2 = temp;
        }
    }
}
