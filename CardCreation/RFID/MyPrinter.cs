using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CardCreation.RFID
{
    public static class MyPrinter
    {
        #region Constants
        #region Possible value of dwInfoType for SOY_PR_GetPrinterInfo()
        public const UInt32 INFO_MODEL_NAME = 1;                        //!<Printer model name
        public const UInt32 INFO_FW_VERSION = 2;                        //!<Printer firmware version
        public const UInt32 INFO_SERIAL_NUMBER = 3;                     //!<Printer serial number
        public const UInt32 INFO_CARD_POSITION = 4;                     //!<Current card position in printer
        public const UInt32 INFO_RIBBON_TYPE = 5;                       //!<Current installed ribbon type
        public const UInt32 INFO_RIBBON_COUNT = 6;                      //!<Current installed ribbon remain count
        public const UInt32 INFO_PRINT_COUNT = 7;                       //!<Printed count by frames
        public const UInt32 INFO_REGION_CODE = 8;                       //!<Region code
        public const UInt32 INFO_UNCLEAN_COUNT = 9;                     //!<Unclean count
        public const UInt32 INFO_INSTALLED_MODULE = 10;                 //!<Current installed modules
        #endregion

        #region Possible value of dwCommand for SOY_PR_ExecCommand()
        public const UInt32 CMD_MOVE_CARD_TO_HOPPER = 1;                //!<Move Card to Output Hopper
        public const UInt32 CMD_MOVE_CARD_TO_CONTACT = 2;               //!<Move Card to Contact Encoder Station
        public const UInt32 CMD_MOVE_CARD_TO_CONTACTLESS = 3;           //!<Move Card to Contactless Encoder Station
        public const UInt32 CMD_MOVE_CARD_TO_STANDBY_BACK = 4;          //!<Move Card to Standby (back)
        public const UInt32 CMD_MOVE_CARD_TO_FLIPPER = 5;               //!<Move Card to Flipper
        public const UInt32 CMD_MOVE_CARD_TO_REJECT_BOX_FRONT = 6;      //!<Move Card to Reject Box (front)
        public const UInt32 CMD_MOVE_CARD_TO_REJECT_BOX_DOWN = 7;       //!<Move Card to Reject Box (down)
        public const UInt32 CMD_MOVE_CARD_TO_STANDBY_FRONT = 8;         //!<Move Card to Standby (front)
        public const UInt32 CMD_MOVE_CARD_TO_FRONT = 9;                 //!<Move Card to Front position
        public const UInt32 CMD_MOVE_CARD_TO_PREPARE = 10;              //!<Move Card to Prepare position
        public const UInt32 CMD_RESET_PRINTER_HARD = 21;                //!<Hard reset printer, printer status and temporary setting will be lost.
        public const UInt32 CMD_RESET_PRINTER_JAM = 22;                 //!<Card jam reset, the card will move to prepare position and will finish initialize flow.
        public const UInt32 CMD_CLEAN_CARD_PATH = 23;                   //!<Clean card path
        public const UInt32 CMD_FLIP_CARD = 24;                         //!<Flip card then move card to prepare position
        public const UInt32 CMD_CLEAN_CARD_PATH_NO_EJECT = 25;          //!<Clean card path, after finished, do not eject card.
        public const UInt32 CMD_ERASE_FULL_CARD = 31;                   //!<Erase rewritable card whole card
        #endregion

        #region possible return values for INFO_CARD_POSITION
        public const UInt32 CARD_POS_OUT_OF_PRINTER = 0;
        public const UInt32 CARD_POS_FRONT_STANDBY = 3;
        public const UInt32 CARD_POS_FLIPPER = 4;
        public const UInt32 CARD_POS_MAG_IN = 5;
        public const UInt32 CARD_POS_MAG_OUT = 6;
        public const UInt32 CARD_POS_START_PRINTING = 7;
        public const UInt32 CARD_POS_PRINT_END = 8;
        public const UInt32 CARD_POS_CONTACT = 9;
        public const UInt32 CARD_POS_CONTACTLESS = 10;
        public const UInt32 CARD_POS_BACK_STANDBY = 11;
        public const UInt32 CARD_POS_CARD_JAM_POS = 12;
        public const UInt32 CARD_POS_PREPARE_POS = 13;
        public const UInt32 CARD_POS_UNKNOW_POS = 15;
        #endregion

        #region Flags of installed module for return value of INFO_INSTALLED_MODULE
        public const UInt32 MODULE_FLIPPER = 0x00000001;
        public const UInt32 MODULE_MAG_STRIPE = 0x00000002;
        public const UInt32 MODULE_CONTACT_IC = 0x00000004;
        public const UInt32 MODULE_RFID = 0x00000008;
        public const UInt32 MODULE_ETHERNET = 0x00000010;
        public const UInt32 MODULE_600DPI = 0x00010000;
        #endregion

        #region Configuration type used for SOY_PR_SetPrinterConfig()
        public const UInt32 CONFIG_MANUAL_FEED_FRONT = 1;			    //!<Front end manual feed slot
        public const UInt32 CONFIG_MANUAL_FEED_BACK = 2;			    //!<Back end manual feed slot
        public const UInt32 CONFIG_INPUT_BIN = 3;			            //!<Set input bin to be used
        public const UInt32 CONFIG_ADF_HOOK_MODE = 4;			        //!<Set ADF to use hook mode or not
        public const UInt32 CONFIG_OUTPUT_BIN_MODE = 5;			        //!<Set output bin to be used and its mode
        public const UInt32 CONFIG_INPUT_OUTPUT_BINDING = 6;            //!<Set target output bin when use the selected input bin
        public const UInt32 CONFIG_CARD_IN_SIGNAL = 7;					//!<Set card-in signal level
        #endregion

        #endregion

        #region Seaory SDK export functions

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_ExecCommandW(string szPrinter, UInt32 dwCommand);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_GetPrinterInfoW(string szPrinter, UInt32 dwInfoType, [Out] char[] szInfoOut);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_GetPrinterStatusW(string szPrinter, ref UInt32 lpdwStatus);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_GetPrinterWarningW(string szPrinter, ref UInt32 lpdwWarning);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_ModifyDocumentPropertiesW(string szPrinter, IntPtr hDC, ref SEAORY_DOC_PROP lpDocPropIn, IntPtr lpInDevMode);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_SdkVersionW([Out] char[] szVersionOut);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern void SOY_PR_SetLogLevel(uint dwLogLevel);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_SetStandbyParametersW(string szPrinter, byte byOutputBin, byte byStandbyPos, UInt32 dwStandbyTime);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_SetPrinterConfigW(string szPrinter, UInt32 dwConfigType, Int32 nConfigValue);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_EncodeTrackW(string szPrinter, UInt32 dwMode, char[] szTrack1, char[] szTrack2, char[] szTrack3, UInt32 dwRetry);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_ReadTrackW(string szPrinter, UInt32 dwMode, [Out] char[] szTrack1Out, [Out] char[] szTrack2Out, [Out] char[] szTrack3Out);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_StartPrinting2W(string szPrinter, ref SEAORY_DOC_PROP lpDocPropIn, [In, Out] ref IntPtr hPrinterDC);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_StartPage2(IntPtr hPrinterDC);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_EndPage2(IntPtr hPrinterDC);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_EndPrinting2(IntPtr hPrinterDC, bool bCancelJob);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_PrintImage2W(IntPtr hPrinterDC, int nX, int nY, int nWidth, int nHeight, string szImageUrlW);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_PrintText2W(IntPtr hPrinterDC, int nX, int nY, string szTextW, string szFontNameW, int nFontSize, int nFontWeight, byte byFontAttribute, byte byCharSet, UInt32 dwTextColor, bool bTransparentBack);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_GetPrinterSettingW(string szPrinter, [In, Out] ref SEAORY_DOC_PROP lpDocPropOut);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_SetPrinterSettingW(string szPrinter, ref SEAORY_DOC_PROP lpDocPropIn);

        [DllImport("SeaorySDK.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 SOY_PR_PrintOneCardW(string szPrinter, ref PRINT_CARD_PARAM lpJobPara);
        #endregion Seaory SDK export functions

        public static Dictionary<UInt32, string> ErrorMap = new Dictionary<UInt32, string>();
        public static Dictionary<UInt32, string> WarningMap = new Dictionary<UInt32, string>();

        static MyPrinter()
        {
            ErrorMap.Add(0x00010001, "Firmware error");
            ErrorMap.Add(0x00010002, "TPH thermistor error");
            ErrorMap.Add(0x00010003, "Encoder error(take)");
            ErrorMap.Add(0x00010004, "Encoder error(supply)");
            ErrorMap.Add(0x00010005, "ADC error");

            ErrorMap.Add(0x00010010, "Card jam (10)");
            ErrorMap.Add(0x00010011, "Card jam (11)");
            ErrorMap.Add(0x00010012, "Card jam (12)");
            ErrorMap.Add(0x00010013, "Card jam (13)");
            ErrorMap.Add(0x00010014, "Card jam (14)");
            ErrorMap.Add(0x00010015, "Card jam (15)");
            ErrorMap.Add(0x00010016, "Card jam (16)");
            ErrorMap.Add(0x00010017, "Card jam (17)");
            ErrorMap.Add(0x00010018, "Card jam (18)");
            ErrorMap.Add(0x00010019, "Card jam (19)");
            ErrorMap.Add(0x0001001A, "Card jam (1A)");
            ErrorMap.Add(0x0001001B, "Card jam (1B)");

            ErrorMap.Add(0x00010021, "Cover open");
            ErrorMap.Add(0x00010022, "Rejectbox open");
            ErrorMap.Add(0x00010023, "Rejectbox full");

            ErrorMap.Add(0x00010031, "TPH cam error");
            ErrorMap.Add(0x00010032, "ADF cam error");
            ErrorMap.Add(0x00010033, "Flipper error");

            ErrorMap.Add(0x00010041, "Ribbon out (41)");
            ErrorMap.Add(0x00010042, "Ribbon error (42)");
            ErrorMap.Add(0x00010043, "Ribbon missing (43)");
            ErrorMap.Add(0x00010044, "Ribbon unsupport (44)");
            ErrorMap.Add(0x00010045, "Ribbon missing (45)");
            ErrorMap.Add(0x00010046, "Ribbon out (46)");
            ErrorMap.Add(0x00010047, "Ribbon mismatch (47)");
            ErrorMap.Add(0x00010048, "Ribbon error (48)");
            ErrorMap.Add(0x00010049, "Ribbon error (49)");

            ErrorMap.Add(0x00010051, "Card feed error (51)");
            ErrorMap.Add(0x00010052, "Card feed error (52)");
            ErrorMap.Add(0x00010053, "Card feed error (53)");
            ErrorMap.Add(0x0001005F, "Card out");

            ErrorMap.Add(0x00010061, "Auth. error (61)");
            ErrorMap.Add(0x00010062, "Auth. error (62)");

            ErrorMap.Add(0x000100A1, "The firmware command is not supported.");
            ErrorMap.Add(0x000100A2, "The firmware command parameter is wrong.");
            ErrorMap.Add(0x000100A3, "The firmware task is not created.");
            ErrorMap.Add(0x000100A4, "The firmware command is rejected.");
            ErrorMap.Add(0x000100A5, "The printer memory is full.");

            ErrorMap.Add(0x00011001, "Track data is empty.");
            ErrorMap.Add(0x00011002, "There is wrong character in track 1.");
            ErrorMap.Add(0x00011003, "There is wrong character in track 2.");
            ErrorMap.Add(0x00011004, "There is wrong character in track 3.");
            ErrorMap.Add(0x00011005, "Magnetic encoding module is not attached.");
            ErrorMap.Add(0x00011006, "Encoding magnetic stripe fail!");
            ErrorMap.Add(0x00011007, "The flipper module is not attached.");
            ErrorMap.Add(0x00011008, "The 600DPI feature is not enabled.");
            ErrorMap.Add(0x00011009, "Track 1 is empty.");
            ErrorMap.Add(0x0001100A, "Track 2 is empty.");
            ErrorMap.Add(0x0001100B, "Track 3 is empty.");
            ErrorMap.Add(0x0001100C, "Track 1,2 are empty.");
            ErrorMap.Add(0x0001100D, "Track 1,3 are empty.");
            ErrorMap.Add(0x0001100E, "Track 2,3 are empty.");
            ErrorMap.Add(0x0001100F, "Track 1,2,3 are empty.");

            ErrorMap.Add(0x00011011, "Ribbon is not matched setting.");
            ErrorMap.Add(0x00011012, "The feature of printing non-standard length card is not enabled.");
            ErrorMap.Add(0x00011013, "The drawing text or image is outside the scope of the card.");
            ErrorMap.Add(0x00011014, "There is no card in printer.");
            ErrorMap.Add(0x00011015, "Please take out ribbon.");

            ErrorMap.Add(0xFFFFFFFF, "");

            WarningMap.Add(0x00020001, "Ribbon low");
            WarningMap.Add(0x00020002, "Card low 3");
            WarningMap.Add(0x00020003, "Waiting for card insertion");
            WarningMap.Add(0x00020004, "Waiting for card removal");
            WarningMap.Add(0x00020005, "Card low 2");
            WarningMap.Add(0x00020006, "Card low 1");

            WarningMap.Add(0x00020009, "Cleaning procedure recommended");
            WarningMap.Add(0x0002000A, "Data undentified");

            WarningMap.Add(0x00020011, "Magstripe is blank");
            WarningMap.Add(0x00020014, "Magstripe data error");

            WarningMap.Add(0xFFFFFFFF, "");
        }



        #region Seaory SDK structure declarations
        [StructLayout(LayoutKind.Sequential)]
        public struct SEAORY_DOC_PROP
        {
            public byte byOrientation;      //!<1=portrait, 2=landscape.
            public byte byRibbonType;       //!<0=YMCKO, 1=K, 2=1/2ymcKO, 3=YMCKOK, 4=KO, 5=Gold, 6=Silver, 7=White, 8=1/2ymcKOKO, 9=1/2ymcKO-n, 10=RYMCK.
            public byte byPrintSide;        //!<0x00=no printing, 0x01=front side, 0x10=back side, 0x11=both sides.
            public byte byPrintPanelFront;  //!<0=YMCKO, 1=YMCO, 2=K, 3=KO, 4=YMCK, 5=YMC. Print panels for front side when ribbon has YMCKO.
            public byte byPrintPanelBack;   //!<0=YMCKO, 1=YMCO, 2=K, 3=KO, 4=YMCK, 5=YMC. Print panels for back side when ribbon has YMCKO.
            public byte byResinKfront;      //!<When byPrintPanelFront is K or KO => 0=Dither, 1=Black/White.
                                            //!<Otherwise => 0=Black text, images and graphics, 1=Black text, 2=All black pixels
            public byte byResinKback;       //!<When byPrintPanelBack is K or KO => 0=Dither, 1=Black/White.
                                            //!<Otherwise => 0=Black text, images and graphics, 1=Black text, 2=All black pixels
            public byte byRotate180;        //!<0x00=no rotation, 0x01=rotate front side, 0x10=rotate back side, 0x11=rotate both sides.

            public byte byInputBin;         //!<0=card feeder, 1=front end manual slot, 2=back end manual slot.
            public byte byFeedCardMode;     //!<0x00=no hook mode, 0x01=hook mode, 0x02=retry by hook mode, 0x03=hook mode+retry by hook mode.
            public byte byOutputBin;        //!<0=output hopper, 1=front end manual slot, 2=back end manual slot, 3=reject box, 4=Do not eject card.
            public byte byEjectCardMode;    //!<0=Output directly, 1=Wait for removal.
            public byte byCardInOutByDev;   //!<0=Use card input and output settings by above 4 fields. 1=Use card input and output settings saved in device. The above 4 fields will be ignored.

            public byte byResolution;       //!<0=300x300dpi, 1=300x600dpi.
            public byte byEraseCard;        //!<For S20R only. 0x00=no erase action, 0x01=erase before print, 0x80=erase only.

            public byte byAutoDetectRibbon; //!<0=Use ribbon as byRibbonType setting, 1=auto detect ribbon.
            public byte byMirror;           //!<0x00=no mirror, 0x01=mirror front side, 0x10=mirror back side, 0x11=mirror both sides.
            public byte byMonoSpeedMode;    //!<0=Normal speed,1=Print mono ribbon by speed mode.

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 238)]
            public byte[] byReserved;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct PRINT_CARD_PARAM
        {
            public UInt32 dwSize;               //!<size of PRINT_CARD_PARAM
            public UInt32 dwReserve2;
            public UInt32 dwReserve3;
            public UInt32 dwReserve4;

            public byte byReserve1;
            public byte byReserve2;
            public byte byReserve3;
            public byte byReserve4;
            public byte byReserve5;
            public byte byReserve6;
            public byte byReserve7;
            public byte byReserve8;

            //!<648x1012
            public IntPtr lpFrontBGR;           //!<Specifies the color data to be printed on front side.
            public IntPtr lpFrontK;         //!<Specifies the K data to be printed on front side.
                                            //!<Each pixel with value 0x00 will be transfer to card by K panel.
            public IntPtr lpFrontO;         //!<Specifies the O data to be printed on front side.
                                            //!<Each pixel with value 0xFF will be transfer to card by O panel.
                                            //!<If lpFrontO is null, then O will be printed on full card by default.

            public IntPtr lpBackBGR;            //!<Specifies the color data to be printed on back side.
            public IntPtr lpBackK;          //!<Specifies the K data to be printed on back side.
                                            //!<Each pixel with value 0x00 will be transfer to card by K panel.
            public IntPtr lpBackO;          //!<Specifies the O data to be printed on back side.
                                            //!<Each pixel with value 0xFF will be transfer to card by O panel.
                                            //!<If lpBackO is null, then O will be printed on full card by default.

            public IntPtr lpReserve1;
            public IntPtr lpReserve2;

            public short shBrightness;      //!<Brightness		-100 ~ 100
            public short shContrast;            //!<Contrast		-100 ~ 100
            public short shSharpness;       //!<Sharpness		0 ~ 100
            public short shYellowBalance;   //!<Yellow Balance	-100 ~ 100
            public short shMagentaBalance;  //!<Magenta Balance	-100 ~ 100
            public short shCyanBalance;     //!<Cyan Balance	-100 ~ 100
            public short shSaturation;      //!<Saturation		-100 ~ 100
            public short shGamma;           //!<Gamma	(x0.01)	10 ~ 999

            //!<Heating Energy, value range of following fields are -127 ~ 127
            //!<Front side
            public sbyte chFrontHeatYMC;
            public sbyte chFrontHeatK;
            public sbyte chFrontHeatO;
            public sbyte chFrontHeatResinK;

            //!<Back side
            public sbyte chBackHeatYMC;
            public sbyte chBackHeatK;
            public sbyte chBackHeatO;
            public sbyte chBackHeatResinK;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] chReserved;
        };

        #endregion Seaory SDK structure declarations

        #region BITMAP structure declarations
        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAP
        {
            public Int32 bmType;
            public Int32 bmWidth;
            public Int32 bmHeight;
            public Int32 bmWidthBytes;
            public UInt16 bmPlanes;
            public UInt16 bmBitsPixel;
            public IntPtr bmBits;
        }
        #endregion BITMAP structure declarations
    }

}
