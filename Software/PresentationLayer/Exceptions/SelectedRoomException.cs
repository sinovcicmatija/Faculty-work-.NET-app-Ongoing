using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Exceptions
{
    public class SelectedRoomException : BaseException
    {
        public SelectedRoomException(string poruka)
            :base(poruka)
             { }
    }
}
