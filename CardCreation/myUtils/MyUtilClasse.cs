using CardCreation.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;


namespace CardCreation.myUtils
{
    public class MyUtilClasse
    {

        // Convert String To byte
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static int MAKELANGID(int primary, int sub)
        {
            return (((ushort)sub) << 10) | ((ushort)primary);
        }

        [DllImport("Kernel32.dll")]
        public static extern int FormatMessage(uint dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, [Out]StringBuilder lpBuffer, uint nSize, IntPtr arguments);

        public static void ShowResultMessage(uint dwError, String szFuncName)
        {
            String errorString = null;
            String infoString = null;

            if (dwError == 0)
            {
                MessageBox.Show("Ready.", szFuncName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                errorString = MyPrinter.ErrorMap[dwError];
            }
            catch
            {
                const int FORMAT_MESSAGE_FROM_SYSTEM = 0x1000;
                const int LANG_NEUTRAL = 0x00;
                const int SUBLANG_DEFAULT = 0x01;
                StringBuilder lpBuffer = new StringBuilder(512);
                int count = 0;

                count = FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, dwError, (uint)MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), lpBuffer, 512, IntPtr.Zero);
                errorString = lpBuffer.ToString();                    
            }

            infoString = String.Format("Error = {0}\n\n{1}", dwError, errorString);
            MessageBox.Show(infoString, szFuncName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*
        public void FindSupportedPrinters(ComboBox variable)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Printer");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    String printerName = queryObj["Caption"].ToString();
                    String drivername = queryObj["DriverName"].ToString();
                    Console.WriteLine("printerName = {0}, drivername = {1}", printerName, drivername);

                    if (drivername.Contains("Seaory S2") || drivername.CompareTo("Seaory E30") == 0)
                    {
                        variable.Items.Add(printerName);
                    }
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }
        }
        */



        /*
        * THERE ARE THE PRINT PAGE FUNCITON AN METHODS
        * TAKE THERE IF YOU NEED THEM
        */
        /*
        // PRINT FUNCTION 
        #region tabPagePrint Functions

        private void btnBrowseImageColor2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxImageColor2.Text = openFileDialog1.FileName;
            }
        }

        private void btnBrowseImageColor1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxImageColor1.Text = openFileDialog1.FileName;
            }
        }

        private void btnBrowseImageK1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxImageK1.Text = openFileDialog1.FileName;
            }

        }

        private void btnBrowseImageK2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxImageK2.Text = openFileDialog1.FileName;
            }
        }

        private void checkBoxUseDeviceDefaultCardInOut_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseDeviceDefaultCardInOut.Checked)
            {
                groupBoxFeedCard.Enabled = false;
                groupBoxEjectCard.Enabled = false;
            }
            else
            {
                groupBoxFeedCard.Enabled = true;
                groupBoxEjectCard.Enabled = true;

            }

        }

        private void FillDocPropertyFromUI(ref MyPrinter.SEAORY_DOC_PROP docProp)
        {
            docProp.byOrientation = (byte)(comboBoxOrientation.SelectedIndex + 1);
            docProp.byResolution = (byte)comboBoxResolution.SelectedIndex;

            if (checkBoxAutoDetectRibbon.Checked)
                docProp.byAutoDetectRibbon = 0x01;
            else
                docProp.byRibbonType = (byte)comboBoxRibbonType.SelectedIndex;

            if (checkBoxPrintFrontSide.Checked)
                docProp.byPrintSide = 0x01;

            if (checkBoxPrintBackSide.Checked)
                docProp.byPrintSide |= 0x10;

            docProp.byPrintPanelFront = (byte)comboBoxFrontPanel.SelectedIndex;
            docProp.byPrintPanelBack = (byte)comboBoxBackPanel.SelectedIndex;
            docProp.byResinKfront = (byte)comboBoxFrontKmethod.SelectedIndex;
            docProp.byResinKback = (byte)comboBoxBackKmethod.SelectedIndex;

            if (checkBoxFrontRotate180.Checked)
                docProp.byRotate180 = 0x01;
            if (checkBoxBackRotate180.Checked)
                docProp.byRotate180 |= 0x10;

            if (checkBoxFrontMirror.Checked)
                docProp.byMirror = 0x01;
            if (checkBoxBackMirror.Checked)
                docProp.byMirror |= 0x10;

            if (checkBoxEraseBeforePrinting.Checked)
                docProp.byEraseCard = 0x01;

            if (checkBoxMonoSpeedMode.Checked)
                docProp.byMonoSpeedMode = 0x01;

            if (checkBoxUseDeviceDefaultCardInOut.Checked)
            {
                docProp.byCardInOutByDev = 1;
            }
            else
            {
                docProp.byInputBin = (byte)comboBoxFeedCard.SelectedIndex;
                if (checkBoxHookMode.Checked)
                    docProp.byFeedCardMode = 0x01;
                if (checkBoxRetryByHookMode.Checked)
                    docProp.byFeedCardMode |= 0x02;

                docProp.byOutputBin = (byte)comboBoxEjectCard.SelectedIndex;
                if (checkBoxWaitForRemoval.Checked)
                    docProp.byEjectCardMode = 0x01;
            }
        }

        private void btnGeneralPrint_Click(object sender, EventArgs e)
        {

            m_nTotalPage = 0;
            m_nPagePrinted = 0;

            if (checkBoxPrintFrontSide.Checked)
                m_nTotalPage++;

            if (checkBoxPrintBackSide.Checked)
                m_nTotalPage++;

            //create print job
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = comboBoxPrinter.Text;
            pd.DefaultPageSettings.Margins.Left = 0;
            pd.DefaultPageSettings.Margins.Top = 0;
            pd.DefaultPageSettings.Margins.Right = 0;
            pd.DefaultPageSettings.Margins.Bottom = 0;
            pd.DocumentName = "SeaoryDemo C# Print Job";

            //-------------------------
            MyPrinter.SEAORY_DOC_PROP docProp = new MyPrinter.SEAORY_DOC_PROP();
            FillDocPropertyFromUI(ref docProp);

            uint dwRet = 0;
            String printerName = comboBoxPrinter.Text;

            IntPtr hDevMode = pd.PrinterSettings.GetHdevmode();
            IntPtr lpDevMode = GlobalLock(hDevMode);

            dwRet = MyPrinter.SOY_PR_ModifyDocumentPropertiesW(printerName, IntPtr.Zero, ref docProp, lpDevMode);

            pd.PrinterSettings.SetHdevmode(hDevMode);
            GlobalFree(hDevMode);
            //-------------------------

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage_GeneralPrint);

            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }

            pd.PrintPage -= pd_PrintPage_GeneralPrint;
        }


        private void pd_PrintPage_GeneralPrint(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Pixel;

            //when print 300x600, need to do scaling
            //-------------------------
            float scaleX = 1.0F, scaleY = 1.0F;
            if (e.Graphics.DpiX == 600)
                scaleX = 2.0F;
            else if (e.Graphics.DpiY == 600)
                scaleY = 2.0F;

            e.Graphics.ScaleTransform(scaleX, scaleY);
            //-------------------------

            Image anImg = null;
            Image anImgK = null;

            int imgX = 0, imgY = 0, imgW = 0, imgH = 0;
            String imgFile = null;

            int imgKX = 0, imgKY = 0, imgKW = 0, imgKH = 0;
            String imgKFile = null;

            int txtX = 0, txtY = 0;
            String fontName = null;
            int fontSize = 0;
            String textToDraw = null;

            //print front side
            if (m_nPagePrinted == 0 && checkBoxPrintFrontSide.Checked)
            {
                imgX = int.Parse(textBoxImgX1.Text);
                imgY = int.Parse(textBoxImgY1.Text);
                imgW = int.Parse(textBoxImgWidth1.Text);
                imgH = int.Parse(textBoxImgHeight1.Text);
                imgFile = textBoxImageColor1.Text;

                imgKX = int.Parse(textBoxImgKX1.Text);
                imgKY = int.Parse(textBoxImgKY1.Text);
                imgKW = int.Parse(textBoxImgKWidth1.Text);
                imgKH = int.Parse(textBoxImgKHeight1.Text);
                imgKFile = textBoxImageK1.Text;

                txtX = int.Parse(textBoxTextX1.Text);
                txtY = int.Parse(textBoxTextY1.Text);
                fontName = textBoxFontName1.Text;
                fontSize = int.Parse(textBoxFontSize1.Text);
                textToDraw = textBoxFrontText.Text;
            }
            //print back side
            else if (checkBoxPrintBackSide.Checked)
            {
                imgX = int.Parse(textBoxImgX2.Text);
                imgY = int.Parse(textBoxImgY2.Text);
                imgW = int.Parse(textBoxImgWidth2.Text);
                imgH = int.Parse(textBoxImgHeight2.Text);
                imgFile = textBoxImageColor2.Text;

                imgKX = int.Parse(textBoxImgKX2.Text);
                imgKY = int.Parse(textBoxImgKY2.Text);
                imgKW = int.Parse(textBoxImgKWidth2.Text);
                imgKH = int.Parse(textBoxImgKHeight2.Text);
                imgKFile = textBoxImageK2.Text;

                txtX = int.Parse(textBoxTextX2.Text);
                txtY = int.Parse(textBoxTextY2.Text);
                fontName = textBoxFontName2.Text;
                fontSize = int.Parse(textBoxFontSize2.Text);
                textToDraw = textBoxBackText.Text;
            }

            //---------------------------------------------
            //draw color image
            if (imgFile != null && imgFile != "")
            {
                anImg = Image.FromFile(imgFile);
                if (anImg != null)
                {
                    if (imgW == 0) imgW = anImg.Width;
                    if (imgH == 0) imgH = anImg.Height;
                    e.Graphics.DrawImage(anImg, imgX, imgY, imgW, imgH);
                }
            }

            //draw black image
            if (imgKFile != null && imgKFile != "")
            {
                anImgK = Image.FromFile(imgKFile);
                if (anImgK != null)
                {
                    if (imgKW == 0) imgKW = anImgK.Width;
                    if (imgKH == 0) imgKH = anImgK.Height;
                    e.Graphics.DrawImage(anImgK, imgKX, imgKY, imgKW, imgKH);
                }
            }

            //draw black text
            if (textToDraw != null && textToDraw != "")
                e.Graphics.DrawString(textToDraw, new Font(fontName, fontSize, GraphicsUnit.Point), new SolidBrush(Color.Black), new PointF(txtX, txtY));
            //---------------------------------------------

            m_nPagePrinted++;

            if (m_nTotalPage == m_nPagePrinted)
                e.HasMorePages = false;
            else
                e.HasMorePages = true;
        }

        private void btnSimplePrint_Click(object sender, EventArgs e)
        {
            MyPrinter.SEAORY_DOC_PROP docProp = new MyPrinter.SEAORY_DOC_PROP();
            FillDocPropertyFromUI(ref docProp);

            String printerName = comboBoxPrinter.Text;
            uint dwRet = 0;
            bool bCancelJob = false;
            uint dwError = 0;

            int imgX = 0, imgY = 0, imgW = 0, imgH = 0;
            String imgFile = null;

            int imgKX = 0, imgKY = 0, imgKW = 0, imgKH = 0;
            String imgKFile = null;

            int txtX = 0, txtY = 0;
            String fontName = null;
            int fontSize = 0;
            String textToDraw = null;

            IntPtr hPrinterDC = IntPtr.Zero;

            dwRet = MyPrinter.SOY_PR_StartPrinting2W(printerName, ref docProp, ref hPrinterDC);
            if (dwRet != 0)
            {
                MyUtilClasse.ShowResultMessage(dwRet, "SOY_PR_StartPrinting2W()");
                return;
            }

            //print front side
            if (checkBoxPrintFrontSide.Checked)
            {
                imgX = int.Parse(textBoxImgX1.Text);
                imgY = int.Parse(textBoxImgY1.Text);
                imgW = int.Parse(textBoxImgWidth1.Text);
                imgH = int.Parse(textBoxImgHeight1.Text);
                imgFile = textBoxImageColor1.Text;

                imgKX = int.Parse(textBoxImgKX1.Text);
                imgKY = int.Parse(textBoxImgKY1.Text);
                imgKW = int.Parse(textBoxImgKWidth1.Text);
                imgKH = int.Parse(textBoxImgKHeight1.Text);
                imgKFile = textBoxImageK1.Text;

                txtX = int.Parse(textBoxTextX1.Text);
                txtY = int.Parse(textBoxTextY1.Text);
                fontName = textBoxFontName1.Text;
                fontSize = int.Parse(textBoxFontSize1.Text);
                textToDraw = textBoxFrontText.Text;

                dwRet = MyPrinter.SOY_PR_StartPage2(hPrinterDC);

                if (dwRet == 0 && imgFile != null && imgFile != "")
                    dwRet = MyPrinter.SOY_PR_PrintImage2W(hPrinterDC, imgX, imgY, imgW, imgH, imgFile);

                if (dwRet == 0 && imgKFile != null && imgKFile != "")
                    dwRet = MyPrinter.SOY_PR_PrintImage2W(hPrinterDC, imgKX, imgKY, imgKW, imgKH, imgKFile);

                if (dwRet == 0 && textToDraw != null && textToDraw != "")
                    dwRet = MyPrinter.SOY_PR_PrintText2W(hPrinterDC, txtX, txtY, textToDraw, fontName, fontSize, 100, 0, 0, 0x00000000, true);

                if (dwRet == 0)
                    dwRet = MyPrinter.SOY_PR_EndPage2(hPrinterDC);
            }

            //print back side
            if (checkBoxPrintBackSide.Checked)
            {
                imgX = int.Parse(textBoxImgX2.Text);
                imgY = int.Parse(textBoxImgY2.Text);
                imgW = int.Parse(textBoxImgWidth2.Text);
                imgH = int.Parse(textBoxImgHeight2.Text);
                imgFile = textBoxImageColor2.Text;

                imgKX = int.Parse(textBoxImgKX2.Text);
                imgKY = int.Parse(textBoxImgKY2.Text);
                imgKW = int.Parse(textBoxImgKWidth2.Text);
                imgKH = int.Parse(textBoxImgKHeight2.Text);
                imgKFile = textBoxImageK2.Text;

                txtX = int.Parse(textBoxTextX2.Text);
                txtY = int.Parse(textBoxTextY2.Text);
                fontName = textBoxFontName2.Text;
                fontSize = int.Parse(textBoxFontSize2.Text);
                textToDraw = textBoxBackText.Text;

                if (dwRet == 0)
                    dwRet = MyPrinter.SOY_PR_StartPage2(hPrinterDC);

                if (dwRet == 0 && imgFile != null && imgFile != "")
                    dwRet = MyPrinter.SOY_PR_PrintImage2W(hPrinterDC, imgX, imgY, imgW, imgH, imgFile);

                if (dwRet == 0 && imgKFile != null && imgKFile != "")
                    dwRet = MyPrinter.SOY_PR_PrintImage2W(hPrinterDC, imgKX, imgKY, imgKW, imgKH, imgKFile);

                if (dwRet == 0 && textToDraw != null && textToDraw != "")
                    dwRet = MyPrinter.SOY_PR_PrintText2W(hPrinterDC, txtX, txtY, textToDraw, fontName, fontSize, 100, 0, 0, 0x00000000, true);

                if (dwRet == 0)
                    dwRet = MyPrinter.SOY_PR_EndPage2(hPrinterDC);
            }

            dwError = dwRet;
            if (dwRet != 0)
                bCancelJob = true;

            dwRet = MyPrinter.SOY_PR_EndPrinting2(hPrinterDC, bCancelJob);
            MyUtilClasse.ShowResultMessage(dwError, "btnSimplePrint_Click()");
        }

        private void checkBoxAutoDetectRibbon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoDetectRibbon.Checked)
            {
                comboBoxRibbonType.Enabled = false;
                comboBoxFrontPanel.Enabled = false;
                comboBoxBackPanel.Enabled = false;
                comboBoxFrontKmethod.Enabled = false;
                comboBoxBackKmethod.Enabled = false;
            }
            else
            {
                comboBoxRibbonType.Enabled = true;
                comboBoxFrontPanel.Enabled = true;
                comboBoxBackPanel.Enabled = true;
                comboBoxFrontKmethod.Enabled = true;
                comboBoxBackKmethod.Enabled = true;
            }
        }

        private void comboBoxRibbonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBoxRibbonType.SelectedIndex;

            if (i == 1 || i == 4 || i == 5 || i == 6 || i == 7 || i == 11)//K,KO,Gold,Silver,White,UV
            {
                comboBoxFrontPanel.Enabled = false;
                comboBoxFrontPanel.Visible = false;

                comboBoxFrontKmethod.Items.Clear();
                comboBoxFrontKmethod.Items.Add("Resin Dither");
                comboBoxFrontKmethod.Items.Add("Black/White");
                comboBoxFrontKmethod.SelectedIndex = 0;

                comboBoxBackPanel.Enabled = false;
                comboBoxBackPanel.Visible = false;

                comboBoxBackKmethod.Items.Clear();
                comboBoxBackKmethod.Items.Add("Resin Dither");
                comboBoxBackKmethod.Items.Add("Black/White");
                comboBoxBackKmethod.SelectedIndex = 0;
            }
            else
            {
                if (!checkBoxAutoDetectRibbon.Checked)
                {
                    comboBoxFrontPanel.Enabled = true;
                    comboBoxBackPanel.Enabled = true;
                }

                comboBoxFrontPanel.Visible = true;

                comboBoxFrontKmethod.Items.Clear();
                comboBoxFrontKmethod.Items.Add("Black text, images and graphics");
                comboBoxFrontKmethod.Items.Add("Black text");
                comboBoxFrontKmethod.Items.Add("All black pixels");
                comboBoxFrontKmethod.SelectedIndex = 0;

                comboBoxBackPanel.Visible = true;

                comboBoxBackKmethod.Items.Clear();
                comboBoxBackKmethod.Items.Add("Black text, images and graphics");
                comboBoxBackKmethod.Items.Add("Black text");
                comboBoxBackKmethod.Items.Add("All black pixels");
                comboBoxBackKmethod.SelectedIndex = 0;
            }

            comboBoxFrontPanel.Items.Clear();
            comboBoxBackPanel.Items.Clear();
            if (i == 10)//RYMCK
            {
                comboBoxFrontPanel.Items.Add("RYMCK");
                comboBoxFrontPanel.Items.Add("RYMC");
                comboBoxFrontPanel.Items.Add("K");
                comboBoxFrontPanel.Items.Add("RK");
                comboBoxFrontPanel.Items.Add("RYMCK+R");
                comboBoxFrontPanel.Items.Add("YMCK+R");

                comboBoxBackPanel.Items.Add("RYMCK");
                comboBoxBackPanel.Items.Add("RYMC");
                comboBoxBackPanel.Items.Add("K");
                comboBoxBackPanel.Items.Add("RK");
                comboBoxBackPanel.Items.Add("RYMCK+R");
                comboBoxBackPanel.Items.Add("YMCK+R");
            }
            else
            {
                comboBoxFrontPanel.Items.Add("YMCKO");
                comboBoxFrontPanel.Items.Add("YMCO");
                comboBoxFrontPanel.Items.Add("K");
                comboBoxFrontPanel.Items.Add("KO");
                comboBoxFrontPanel.Items.Add("YMCK");
                comboBoxFrontPanel.Items.Add("YMC");

                comboBoxBackPanel.Items.Add("YMCKO");
                comboBoxBackPanel.Items.Add("YMCO");
                comboBoxBackPanel.Items.Add("K");
                comboBoxBackPanel.Items.Add("KO");
                comboBoxBackPanel.Items.Add("YMCK");
                comboBoxBackPanel.Items.Add("YMC");
            }

            comboBoxFrontPanel.SelectedIndex = 0;
            comboBoxBackPanel.SelectedIndex = 0;

            if (i == 3)//YMCKOK
            {
                checkBoxPrintBackSide.Checked = true;
                comboBoxBackPanel.SelectedIndex = 2;

                comboBoxBackKmethod.Items.Clear();
                comboBoxBackKmethod.Items.Add("Resin Dither");
                comboBoxBackKmethod.Items.Add("Black/White");
                comboBoxBackKmethod.SelectedIndex = 0;
            }
            else if (i == 8)//1/2ymcKOKO
            {
                checkBoxPrintBackSide.Checked = true;
                comboBoxBackPanel.SelectedIndex = 3;

                comboBoxBackKmethod.Items.Clear();
                comboBoxBackKmethod.Items.Add("Resin Dither");
                comboBoxBackKmethod.Items.Add("Black/White");
                comboBoxBackKmethod.SelectedIndex = 0;
            }
            else
            {
                checkBoxPrintBackSide.Checked = false;
            }
        }


        private void comboBoxFrontPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int m = comboBoxRibbonType.SelectedIndex;
            int i = comboBoxFrontPanel.SelectedIndex;

            if (m == 10)//RYMCK
            {
                if (i == 1)//RYMC
                {
                    comboBoxFrontKmethod.Visible = false;
                }
                else if (i == 2 || i == 3)//K,RK
                {
                    if (!checkBoxAutoDetectRibbon.Checked)
                        comboBoxFrontKmethod.Visible = true;

                    comboBoxFrontKmethod.Items.Clear();
                    comboBoxFrontKmethod.Items.Add("Resin Dither");
                    comboBoxFrontKmethod.Items.Add("Black/White");
                    comboBoxFrontKmethod.SelectedIndex = 0;
                }
                else
                {
                    if (!checkBoxAutoDetectRibbon.Checked)
                        comboBoxFrontKmethod.Visible = true;

                    comboBoxFrontKmethod.Items.Clear();
                    comboBoxFrontKmethod.Items.Add("Black text, images and graphics");
                    comboBoxFrontKmethod.Items.Add("Black text");
                    comboBoxFrontKmethod.Items.Add("All black pixels");
                    comboBoxFrontKmethod.SelectedIndex = 0;
                }
            }
            else if (m == 1 || m == 4 || m == 5 || m == 6 || m == 7 || m == 11)//K,KO,Gold,Silver,White,UV
            {


            }
            else
            {
                if (i == 1 || i == 5)//YMCO,YMC
                {
                    comboBoxFrontKmethod.Visible = false;
                }
                else if (i == 2 || i == 3)//K,KO
                {
                    if (!checkBoxAutoDetectRibbon.Checked)
                        comboBoxFrontKmethod.Visible = true;

                    comboBoxFrontKmethod.Items.Clear();
                    comboBoxFrontKmethod.Items.Add("Resin Dither");
                    comboBoxFrontKmethod.Items.Add("Black/White");
                    comboBoxFrontKmethod.SelectedIndex = 0;
                }
                else
                {
                    if (!checkBoxAutoDetectRibbon.Checked)
                        comboBoxFrontKmethod.Visible = true;

                    comboBoxFrontKmethod.Items.Clear();
                    comboBoxFrontKmethod.Items.Add("Black text, images and graphics");
                    comboBoxFrontKmethod.Items.Add("Black text");
                    comboBoxFrontKmethod.Items.Add("All black pixels");
                    comboBoxFrontKmethod.SelectedIndex = 0;
                }
            }
        }

        private void comboBoxBackPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int m = comboBoxRibbonType.SelectedIndex;
            int i = comboBoxBackPanel.SelectedIndex;

            if (m == 10)//RYMCK
            {
                if (i == 1)//RYMC
                {
                    comboBoxBackKmethod.Enabled = false;
                }
                else if (i == 2 || i == 3)//K,RK
                {
                    if (!checkBoxAutoDetectRibbon.Checked)
                        comboBoxBackKmethod.Enabled = true;

                    comboBoxBackKmethod.Items.Clear();
                    comboBoxBackKmethod.Items.Add("Resin Dither");
                    comboBoxBackKmethod.Items.Add("Black/White");
                    comboBoxBackKmethod.SelectedIndex = 0;
                }
                else
                {
                    if (!checkBoxAutoDetectRibbon.Checked)
                        comboBoxBackKmethod.Enabled = true;

                    comboBoxBackKmethod.Items.Clear();
                    comboBoxBackKmethod.Items.Add("Black text, images and graphics");
                    comboBoxBackKmethod.Items.Add("Black text");
                    comboBoxBackKmethod.Items.Add("All black pixels");
                    comboBoxBackKmethod.SelectedIndex = 0;
                }
            }
            else if (m == 1 || m == 4 || m == 5 || m == 6 || m == 7 || m == 11)//K,KO,Gold,Silver,White,UV
            {


            }
            else
            {
                if (i == 1 || i == 5)//YMCO,YMC
                {
                    comboBoxBackKmethod.Enabled = false;
                }
                else if (i == 2 || i == 3)//K,KO
                {
                    if (!checkBoxAutoDetectRibbon.Checked)
                        comboBoxBackKmethod.Enabled = true;

                    comboBoxBackKmethod.Items.Clear();
                    comboBoxBackKmethod.Items.Add("Resin Dither");
                    comboBoxBackKmethod.Items.Add("Black/White");
                    comboBoxBackKmethod.SelectedIndex = 0;
                }
                else
                {
                    if (!checkBoxAutoDetectRibbon.Checked)
                        comboBoxBackKmethod.Enabled = true;

                    comboBoxBackKmethod.Items.Clear();
                    comboBoxBackKmethod.Items.Add("Black text, images and graphics");
                    comboBoxBackKmethod.Items.Add("Black text");
                    comboBoxBackKmethod.Items.Add("All black pixels");
                    comboBoxBackKmethod.SelectedIndex = 0;
                }
            }
        }

        private void comboBoxFeedCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bShow = true;

            if (comboBoxFeedCard.SelectedIndex != 0)
                bShow = false;

            checkBoxHookMode.Visible = bShow;
            checkBoxRetryByHookMode.Visible = bShow;
        }

        private void btnGetPrinterPreference_Click(object sender, EventArgs e)
        {
            uint dwRet = 0;
            String printerName = comboBoxPrinter.Text;

            MyPrinter.SEAORY_DOC_PROP docProp = new MyPrinter.SEAORY_DOC_PROP();

            dwRet = MyPrinter.SOY_PR_GetPrinterSettingW(printerName, ref docProp);
            if (dwRet != 0)
            {
                MyUtilClasse.ShowResultMessage(dwRet, "GetPrinterPreference()");
                return;
            }


            if (docProp.byAutoDetectRibbon == 0)
                checkBoxAutoDetectRibbon.Checked = false;
            else
                checkBoxAutoDetectRibbon.Checked = true;

            if (docProp.byOrientation == 1)
                comboBoxOrientation.SelectedIndex = 0;
            else
                comboBoxOrientation.SelectedIndex = 1;

            if (docProp.byResolution == 1)
                comboBoxResolution.SelectedIndex = 1;
            else
                comboBoxResolution.SelectedIndex = 0;

            comboBoxRibbonType.SelectedIndex = docProp.byRibbonType;

            if ((docProp.byPrintSide & 0x01) == 0x01)
                checkBoxPrintFrontSide.Checked = true;
            else
                checkBoxPrintFrontSide.Checked = false;

            if ((docProp.byPrintSide & 0x10) == 0x10)
                checkBoxPrintBackSide.Checked = true;
            else
                checkBoxPrintBackSide.Checked = false;

            comboBoxFrontPanel.SelectedIndex = docProp.byPrintPanelFront;
            comboBoxBackPanel.SelectedIndex = docProp.byPrintPanelBack;
            comboBoxFrontKmethod.SelectedIndex = docProp.byResinKfront;
            comboBoxBackKmethod.SelectedIndex = docProp.byResinKback;

            if ((docProp.byRotate180 & 0x01) == 0x01)
                checkBoxFrontRotate180.Checked = true;
            else
                checkBoxFrontRotate180.Checked = false;

            if ((docProp.byRotate180 & 0x10) == 0x10)
                checkBoxBackRotate180.Checked = true;
            else
                checkBoxBackRotate180.Checked = false;

            if ((docProp.byMirror & 0x01) == 0x01)
                checkBoxFrontMirror.Checked = true;
            else
                checkBoxFrontMirror.Checked = false;

            if ((docProp.byMirror & 0x10) == 0x10)
                checkBoxBackMirror.Checked = true;
            else
                checkBoxBackMirror.Checked = false;

            if ((docProp.byEraseCard & 0x01) == 0x01)
                checkBoxEraseBeforePrinting.Checked = true;
            else
                checkBoxEraseBeforePrinting.Checked = false;

            if (docProp.byMonoSpeedMode == 1)
                checkBoxMonoSpeedMode.Checked = true;
            else
                checkBoxMonoSpeedMode.Checked = false;

            if (docProp.byCardInOutByDev == 1)
                checkBoxUseDeviceDefaultCardInOut.Checked = true;
            else
                checkBoxUseDeviceDefaultCardInOut.Checked = false;

            comboBoxFeedCard.SelectedIndex = docProp.byInputBin;

            if ((docProp.byFeedCardMode & 0x01) == 0x01)
                checkBoxHookMode.Checked = true;
            else
                checkBoxHookMode.Checked = false;

            if ((docProp.byFeedCardMode & 0x02) == 0x02)
                checkBoxRetryByHookMode.Checked = true;
            else
                checkBoxRetryByHookMode.Checked = false;

            comboBoxEjectCard.SelectedIndex = docProp.byOutputBin;

            if (docProp.byEjectCardMode == 1)
                checkBoxWaitForRemoval.Checked = true;
            else
                checkBoxWaitForRemoval.Checked = false;
        }

        private void btnSetPrinterPreference_Click(object sender, EventArgs e)
        {
            uint dwRet = 0;
            String printerName = comboBoxPrinter.Text;

            MyPrinter.SEAORY_DOC_PROP docProp = new MyPrinter.SEAORY_DOC_PROP();
            FillDocPropertyFromUI(ref docProp);

            dwRet = MyPrinter.SOY_PR_SetPrinterSettingW(printerName, ref docProp);
            MyUtilClasse.ShowResultMessage(dwRet, "SetPrinterPreference()");

        }

       

        private void btnPrintBypassDriver_Click(object sender, EventArgs e)
        {
            String printerName = comboBoxPrinter.Text;
            uint dwRet = 0;

            int imgX = 0, imgY = 0, imgW = 0, imgH = 0;
            String imgFile = null;

            int imgKX = 0, imgKY = 0, imgKW = 0, imgKH = 0;
            String imgKFile = null;

            int txtX = 0, txtY = 0;
            String fontName = null;
            int fontSize = 0;
            String textToDraw = null;

            int cardWidth = 0, cardHeight = 0;

            Image anImg = null;
            Image anImgK = null;
            Graphics g = null;

            Bitmap bitmapColor1 = null, bitmapK1 = null;
            Bitmap bitmapColor2 = null, bitmapK2 = null;
            IntPtr ptrColor1 = IntPtr.Zero, ptrK1 = IntPtr.Zero, ptrO1 = IntPtr.Zero;
            IntPtr ptrColor2 = IntPtr.Zero, ptrK2 = IntPtr.Zero, ptrO2 = IntPtr.Zero;
            MyPrinter.PRINT_CARD_PARAM jobPara = new MyPrinter.PRINT_CARD_PARAM();

            if (comboBoxOrientation.SelectedIndex == 0)//portrait
            {
                cardWidth = 648;
                cardHeight = 1012;
            }
            else
            {
                cardWidth = 1012;
                cardHeight = 648;
            }

            if (checkBoxPrintFrontSide.Checked)
            {
                imgX = int.Parse(textBoxImgX1.Text);
                imgY = int.Parse(textBoxImgY1.Text);
                imgW = int.Parse(textBoxImgWidth1.Text);
                imgH = int.Parse(textBoxImgHeight1.Text);
                imgFile = textBoxImageColor1.Text;

                imgKX = int.Parse(textBoxImgKX1.Text);
                imgKY = int.Parse(textBoxImgKY1.Text);
                imgKW = int.Parse(textBoxImgKWidth1.Text);
                imgKH = int.Parse(textBoxImgKHeight1.Text);
                imgKFile = textBoxImageK1.Text;

                txtX = int.Parse(textBoxTextX1.Text);
                txtY = int.Parse(textBoxTextY1.Text);
                fontName = textBoxFontName1.Text;
                fontSize = int.Parse(textBoxFontSize1.Text);
                textToDraw = textBoxFrontText.Text;

                //draw color image
                if (imgFile != null && imgFile != "")
                {
                    anImg = Image.FromFile(imgFile);
                    if (anImg != null)
                    {
                        if (imgW == 0) imgW = anImg.Width;
                        if (imgH == 0) imgH = anImg.Height;

                        bitmapColor1 = new Bitmap(cardWidth, cardHeight, PixelFormat.Format24bppRgb);
                        bitmapColor1.SetResolution(300, 300);
                        g = Graphics.FromImage(bitmapColor1);
                        g.PageUnit = GraphicsUnit.Pixel;
                        g.FillRectangle(Brushes.White, 0, 0, cardWidth, cardHeight);
                        g.DrawImage(anImg, imgX, imgY, imgW, imgH);
                    }
                }

                //draw black image
                if (imgKFile != null && imgKFile != "")
                {
                    anImgK = Image.FromFile(imgKFile);
                    if (anImgK != null)
                    {
                        if (imgKW == 0) imgKW = anImgK.Width;
                        if (imgKH == 0) imgKH = anImgK.Height;

                        bitmapK1 = new Bitmap(cardWidth, cardHeight, PixelFormat.Format24bppRgb);
                        bitmapK1.SetResolution(300, 300);
                        g = Graphics.FromImage(bitmapK1);
                        g.PageUnit = GraphicsUnit.Pixel;
                        g.FillRectangle(Brushes.White, 0, 0, cardWidth, cardHeight);
                        g.DrawImage(anImgK, imgKX, imgKY, imgKW, imgKH);
                    }
                }

                //draw black text
                if (textToDraw != null && textToDraw != "")
                {
                    if (bitmapK1 == null)
                    {
                        bitmapK1 = new Bitmap(cardWidth, cardHeight, PixelFormat.Format24bppRgb);
                        bitmapK1.SetResolution(300, 300);
                        g = Graphics.FromImage(bitmapK1);
                        g.PageUnit = GraphicsUnit.Pixel;
                        g.FillRectangle(Brushes.White, 0, 0, cardWidth, cardHeight);
                    }

                    g.DrawString(textToDraw, new Font(fontName, fontSize, GraphicsUnit.Point), new SolidBrush(Color.Black), new PointF(txtX, txtY));
                }

                if (bitmapColor1 != null)
                    ptrColor1 = ConvertBitmapToBITMAPptr(bitmapColor1);
                if (bitmapK1 != null)
                    ptrK1 = ConvertBitmapToBITMAPptr(bitmapK1);
            }

            if (checkBoxPrintBackSide.Checked)
            {
                imgX = int.Parse(textBoxImgX2.Text);
                imgY = int.Parse(textBoxImgY2.Text);
                imgW = int.Parse(textBoxImgWidth2.Text);
                imgH = int.Parse(textBoxImgHeight2.Text);
                imgFile = textBoxImageColor2.Text;

                imgKX = int.Parse(textBoxImgKX2.Text);
                imgKY = int.Parse(textBoxImgKY2.Text);
                imgKW = int.Parse(textBoxImgKWidth2.Text);
                imgKH = int.Parse(textBoxImgKHeight2.Text);
                imgKFile = textBoxImageK2.Text;

                txtX = int.Parse(textBoxTextX2.Text);
                txtY = int.Parse(textBoxTextY2.Text);
                fontName = textBoxFontName2.Text;
                fontSize = int.Parse(textBoxFontSize2.Text);
                textToDraw = textBoxBackText.Text;

                //draw color image
                if (imgFile != null && imgFile != "")
                {
                    anImg = Image.FromFile(imgFile);
                    if (anImg != null)
                    {
                        if (imgW == 0) imgW = anImg.Width;
                        if (imgH == 0) imgH = anImg.Height;

                        bitmapColor2 = new Bitmap(cardWidth, cardHeight, PixelFormat.Format24bppRgb);
                        bitmapColor2.SetResolution(300, 300);
                        g = Graphics.FromImage(bitmapColor2);
                        g.PageUnit = GraphicsUnit.Pixel;
                        g.FillRectangle(Brushes.White, 0, 0, cardWidth, cardHeight);
                        g.DrawImage(anImg, imgX, imgY, imgW, imgH);
                    }
                }

                //draw black image
                if (imgFile != null && imgFile != "")
                {
                    anImgK = Image.FromFile(imgFile);
                    if (anImgK != null)
                    {
                        if (imgKW == 0) imgKW = anImgK.Width;
                        if (imgKH == 0) imgKH = anImgK.Height;

                        bitmapK2 = new Bitmap(cardWidth, cardHeight, PixelFormat.Format24bppRgb);
                        bitmapK2.SetResolution(300, 300);
                        g = Graphics.FromImage(bitmapK2);
                        g.PageUnit = GraphicsUnit.Pixel;
                        g.FillRectangle(Brushes.White, 0, 0, cardWidth, cardHeight);
                        g.DrawImage(anImgK, 0, 0, imgKW, imgKH);
                    }
                }

                //draw black text
                if (textToDraw != null && textToDraw != "")
                {
                    if (bitmapK2 == null)
                    {
                        bitmapK2 = new Bitmap(cardWidth, cardHeight, PixelFormat.Format24bppRgb);
                        bitmapK2.SetResolution(300, 300);
                        g = Graphics.FromImage(bitmapK2);
                        g.PageUnit = GraphicsUnit.Pixel;
                        g.FillRectangle(Brushes.White, 0, 0, cardWidth, cardHeight);
                    }

                    g.DrawString(textToDraw, new Font(fontName, fontSize, GraphicsUnit.Point), new SolidBrush(Color.Black), new PointF(txtX, txtY));
                }

                if (bitmapColor2 != null)
                    ptrColor2 = ConvertBitmapToBITMAPptr(bitmapColor2);
                if (bitmapK2 != null)
                    ptrK2 = ConvertBitmapToBITMAPptr(bitmapK2);
            }

            jobPara.dwSize = (uint)Marshal.SizeOf(typeof(MyPrinter.PRINT_CARD_PARAM));
            jobPara.lpFrontBGR = ptrColor1;
            jobPara.lpFrontK = ptrK1;
            jobPara.lpFrontO = ptrO1;
            jobPara.lpBackBGR = ptrColor2;
            jobPara.lpBackK = ptrK2;
            jobPara.lpBackO = ptrO2;

            dwRet = MyPrinter.SOY_PR_PrintOneCardW(printerName, ref jobPara);
            MyUtilClasse.ShowResultMessage(dwRet, "SOY_PR_PrintOneCardW()");
        }

        #endregion tabPagePrint Functions

*/




    }
}
