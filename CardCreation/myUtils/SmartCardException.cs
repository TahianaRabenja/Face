using CardCreation.myUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardCreation.myUtils
{
    public class SmartCardException : Exception
    {
        private short except;

        // Methods
        public SmartCardException(short sw1sw2) //: base(except.except(-1_362_647_648) + string.Format(.(-1_362_647_720), sw1sw2))
        {
            this.except = sw1sw2;
        }

        public short getSW1SW2()
        {
            return this.except;
        }

        public SmartCardException()
            : base("PC/SC exception")
        {
        }

        public SmartCardException(int result)
            : base(WinSCard.SCardErrorMessage(result))
        {
            Result = result;
        }

        public int Result { get; private set; }
    }  
   
}
