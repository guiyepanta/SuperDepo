using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDepo_SL
{
    public class ExceptionCMM : Exception
    {
        public ExceptionCMM (String message, Exception ex) : base(message, ex)  { }

    }
}
