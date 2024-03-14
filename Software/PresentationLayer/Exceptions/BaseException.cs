using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Exceptions
{
    public class BaseException : ApplicationException
    {
        public string Poruka { get; set; }

        public BaseException(string poruka)
        {
            Poruka = poruka;
        }
    }
}
