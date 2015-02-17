using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperDepo_SL
{    
    public class ExceptionDB : Exception
    {
        public ExceptionDB(String message, Exception ex) : base(message, ex) { }
    }
}
