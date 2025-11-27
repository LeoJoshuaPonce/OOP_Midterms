using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Midterms
{
    public class ErrorHandler
    {
        public bool HasDuplicate(List<Club> id)
        {
            for (int i = 0; i < id.Count; i++)
            {
                for (int j = 0; j < id.Count; i++)
                {
                    if (id[i] == id[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
