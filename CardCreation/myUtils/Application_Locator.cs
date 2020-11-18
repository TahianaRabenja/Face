﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrinter
{
    public class Application_Locator
    {

        private byte[] data = new byte[4];

        public Application_Locator(byte[] data)
        {
            Buffer.BlockCopy(data, 0, this.data, 0, 4);
        }

        public byte SFI
        {
            get
            {
                return (byte)(data[0] >> 3);
            }

        }
        public byte FirstRecord
        {
            get
            {
                return data[1];
            }
        }

        public byte LastRecord
        {
            get
            {
                return data[2];
            }
        }

        public byte OfflineRecords
        {
            get
            {
                return data[3];
            }
        }

    }
}
