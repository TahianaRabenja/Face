using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardCreation.myUtils;
using CardCreation.myAPDU;
using globalplatform;
using System.Threading;
using System.IO;
//using PCSC;

namespace CardFace
{
    public partial class Card_Face : Form
    {
        private string read;
        private Reader myReader;
        private CommandAPDU apdu = null;
        private ResponseAPDU resApdu = null;
        private byte[] AID = new byte []{0xA0, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x00, 0x00};

        private byte[] name;
        private byte[] las_name;
        private byte[] card_number;
        private byte[] account_number;

        List<Test> db;
        List<Test> filteredList;

        // operation thread
        private delegate void UpdateStatusLabelDelegate(string status);


        public Card_Face()
        {
            InitializeComponent();
            db = new List<Test>();
            filteredList = new List<Test>();
        }

        // Update the satus thread
        private void UpdateStatusLabel(string status)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UpdateStatusLabelDelegate(UpdateStatusLabel), status);
            }
            else
            {
                //statusStrip.Text = status;
                stat_toolStripStatusLabel.Text = status;
            }
        }

        // treat event when card removed
        void card_Removed(string reader)
        {
            UpdateStatusLabel("Card removed from peripheral: " + reader);
        }

        // treat event when card inserted
        void card_Inserted(string reader, byte[] atr)
        {
            myReader = new Reader();
            //myReader.Connect(read);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in atr)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            
            UpdateStatusLabel("Card inserted in the reader: " + reader);
        }

        private void selectApplet()
        {
         
            myReader = new Reader();
            myReader.Connect(read);

            apdu = new CommandAPDU(0x00, 0xA4, 0x04, 0x00, AID, (byte)AID.Length);
            resApdu = myReader.Transmit(apdu);
            reponse_texBox.AppendText(resApdu.SW1.ToString("X2") + resApdu.SW2.ToString("X2"));

        }

        // when the app is loaded
        private void Card_Face_Load(object sender, EventArgs e)
        {
            myReader = new Reader();

            myReader.CardInserted += new Reader.CardInsertedEventHandler(card_Inserted);
            myReader.CardRemoved += new Reader.CardRemovedEventHandler(card_Removed);
            
            foreach (string reader in myReader.Readers)
            {
                reader_comboBox.Items.Add(reader);
            }
            try
            {
                reader_comboBox.SelectedIndex = 0;
                read = reader_comboBox.SelectedItem.ToString();

                //selectApplet();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No reader detected !");
            }
        }


        private bool testChamp(string champ)
        {
            if (champ == string.Empty)
                return false;
            return true;
        }
        private void write_button_Click(object sender, EventArgs e)
        {
            selectApplet();

            if (testChamp(last_Name_textBox.Text) || testChamp(name_textBox.Text) || 
                testChamp(compte_num_textBox.Text) || testChamp(carte_num_textBox.Text))
            {
                MessageBox.Show("Champ vide !");
            }
            {
                // conversion hexadeci
                name = Encoding.ASCII.GetBytes(name_textBox.Text);
                las_name = Encoding.ASCII.GetBytes(last_Name_textBox.Text);
                card_number = Encoding.ASCII.GetBytes(carte_num_textBox.Text);
                account_number = Encoding.ASCII.GetBytes(compte_num_textBox.Text);

                // appel apdu
                apdu = new CommandAPDU(0x10, 0xDA, 0x00, 0x5B, (byte)name.Length, name);
                resApdu = myReader.Transmit(apdu);
                reponse_texBox.AppendText(resApdu.SW1.ToString("X2") + resApdu.SW2.ToString("X2"));

                apdu = new CommandAPDU(0x10, 0xDA, 0x00, 0x87, (byte)las_name.Length, las_name);
                resApdu = myReader.Transmit(apdu);
                reponse_texBox.AppendText(resApdu.SW1.ToString("X2") + resApdu.SW2.ToString("X2"));

                apdu = new CommandAPDU(0x10, 0xDA, 0x00, 0x8F, (byte)card_number.Length, card_number);
                resApdu = myReader.Transmit(apdu);
                reponse_texBox.AppendText(resApdu.SW1.ToString("X2") + resApdu.SW2.ToString("X2"));

                apdu = new CommandAPDU(0x10, 0xDA, 0x00, 0x81, (byte)account_number.Length, account_number);
                resApdu = myReader.Transmit(apdu);
                reponse_texBox.AppendText(resApdu.SW1.ToString("X2") + resApdu.SW2.ToString("X2"));

                // annonce si succes
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[4];
            //data = ASCIIEncoding.ASCII.GetBytes(value_dateTimePicker.Text);

            data = Encoding.Default.GetBytes(value_dateTimePicker.Text);

            string sDate = BitConverter.ToString(data);

            MessageBox.Show("Original:" + value_dateTimePicker.Text + " - in byte -"+ sDate );


            /*
            myReader = new Reader();
            
            myReader.CardInserted += new Reader.CardInsertedEventHandler(card_Inserted);
            myReader.CardRemoved += new Reader.CardRemovedEventHandler(card_Removed);

            reader_comboBox.ResetText();

            foreach (string reader in myReader.Readers)
            {
                reader_comboBox.Items.Add(reader);
            }
            try
            {
                reader_comboBox.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No reader detected !");
            } 
           */ 
                     
        }


        //private void import_button_Click(object sender, EventArgs e)
        //{
            /*
            var filePath = string.Empty;
            var fileContent = string.Empty;

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.InitialDirectory = "C:\\";
                openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|xml files (*.xml)|*.xml|json files (*.json)|*.json|csv files (*.csv)|*.csv|excel files (*.xlsx)|*.xlsx";
                openFile.FilterIndex = 2;
                openFile.RestoreDirectory = true;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // get the path
                    filePath = openFile.FileName;

                    // read content
                    var theFile = openFile.OpenFile();

                    using (StreamReader read = new StreamReader(theFile))                   
                    {
                        fileContent = read.ReadToEnd();
                    }

                }
            }

            import_file_textBox.Text = filePath;
            //data_listBox.Items.Add(fileContent);
            data_listBox.Items.Add(fileContent);

           // MessageBox.Show(fileContent, "File content at path: " + filePath, MessageBoxButtons.OK);
*/
            /*
                        List<string> var = new List<string>();
                        var.Add("Raharivelo"); var.Add("Jaolava"); var.Add("VoayLahyMihazaka"); var.Add("AndrongoLayMitsakaRano");

                        foreach(string test in var)
                        {
                            //reponse_texBox.AppendText(test + "\n");
                            data_listBox.Items.Add(test);
                        }
                        // Adding ListBox control to the form 
                        // Creating and setting the  
                        // properties of ListBox 

                        data_listBox.Items.Add("Geeks");
                        data_listBox.Items.Add("GFG");
                        data_listBox.Items.Add("GeeksForGeeks");
                        data_listBox.Items.Add("gfg");
                        */



      //}



        private void loadCsv()
        {
            var filePath = string.Empty;
            var fileContent = string.Empty;

           using(OpenFileDialog open = new OpenFileDialog())
           {            
              
                open.InitialDirectory = "C:\\";
                open.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|csv files (*.csv)|*.csv";
                open.FilterIndex = 2;
                open.RestoreDirectory = true;
                if(open.ShowDialog() == DialogResult.OK)
                {
                    filePath = open.FileName;
                    var theFile = open.OpenFile();

                    using(StreamReader read = new StreamReader(theFile))
                    {                     
                        if (File.Exists(filePath))
                        {
                            var reader = new StreamReader(File.OpenRead(filePath));
                            List<string> searchList = new List<string>();
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                searchList.Add(line);                           
                            }
                            
                            foreach(string test in searchList)
                            {
                                data_listBox.Items.Add(test);
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("File not found");
                        }
                        
                    }
                    import_file_textBox.Text = filePath;
                    data_listBox.Invalidate();
                }
            }

           
        }



        private void search(string query)
        {
            filteredList.Clear();
            //any city matching or has the query will be added 
            //to the filtered list
            foreach (Test c in db)
            {
                if (c.ToString().Contains(query))
                {
                    filteredList.Add(c);
                }
            }
        }
        private void filter(string phrase)
        {
            //we first need to search for valid entries
            search(phrase);
            //update listBox1 items
            data_listBox.Items.Clear();

            foreach (Test c in filteredList)
            {
                data_listBox.Items.Add(c);
            }
            data_listBox.Invalidate();
        }

        // import file
        private void import_button_Click(object sender, EventArgs e)
        {
            //event handler for LOAD
            loadCsv();
        }

        // search an person
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //make sure that even lowercase letters are valid when searching
            if (search_textBox.Text != "")
            {
                string query = search_textBox.Text;
                char[] a = query.ToCharArray();
                a[0] = char.ToUpper(a[0]);
                //after text has been entered, we filter results
                filter(new string(a));
            }
        }

        private string sName;
        private string slast_Name;
      
        private void data_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {           
            string temp = (string)data_listBox.Items[data_listBox.SelectedIndex];
            foreach(char s in temp)
            {
                sName = temp.Substring(';');
                slast_Name = temp.Substring(';');
            }


            MessageBox.Show(sName + slast_Name);
        }

        private void generate_Pin_button_Click(object sender, EventArgs e)
        {
            var pinValue = new Random().Next(0, 9999);
            var showPin = pinValue.ToString().PadLeft(4, '0');
            pin_textBox.Text = showPin;

            PINbytes = new byte[4];

            for (int i = 3; i >= 0; i--)
            {
                PINbytes[i] = (byte)(pinValue % 10);
                pinValue = pinValue / 10;
            }
        }

        private void valide_button_Click(object sender, EventArgs e)
        {
            apdu = new CommandAPDU(0x10, 0x24, 0x00, 0x83, 0x04, PINbytes);
            resAPDU = Reader.Transmit(apdu);
            testBox.Text = resAPDU.SW1SW2;
        }
    }
}
