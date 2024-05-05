
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETickets.DAL.Enums
{
    [Flags]
    public enum MovieCategory : byte
    {
        Action =1,
        Comedy=2,
        Drama=4,
        Documentary=8, 
        Horror=16,
        Cartoon=32
    }
}
