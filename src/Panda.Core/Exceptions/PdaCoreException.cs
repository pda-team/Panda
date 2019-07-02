using System;

namespace Panda.Core.Exceptions
{
    public class PdaCoreException:Exception
    {
        public PdaCoreException(string msg):base(msg)
        {
            
        }

        public PdaCoreException(string msg,Exception inner) : base(msg,inner)
        {

        }
    }
}