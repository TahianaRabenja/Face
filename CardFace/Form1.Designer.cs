namespace CardFace
{
    partial class Card_Face
    {/// <summary>
     /// Variable nécessaire au concepteur.
     /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Card_Face));
            this.label1 = new System.Windows.Forms.Label();
            this.reader_comboBox = new System.Windows.Forms.ComboBox();
            this.Identity = new System.Windows.Forms.GroupBox();
            this.write_button = new System.Windows.Forms.Button();
            this.compte_num_textBox = new System.Windows.Forms.TextBox();
            this.carte_num_textBox = new System.Windows.Forms.TextBox();
            this.last_Name_textBox = new System.Windows.Forms.TextBox();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.value_dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.generate_Pin_button = new System.Windows.Forms.Button();
            this.valide_button = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pin_textBox = new System.Windows.Forms.TextBox();
            this.groupeBox3 = new System.Windows.Forms.GroupBox();
            this.data_listBox = new System.Windows.Forms.ListBox();
            this.import_file_textBox = new System.Windows.Forms.TextBox();
            this.import_button = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stat_toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.reponse_texBox = new System.Windows.Forms.TextBox();
            this.refresh_button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.Identity.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupeBox3.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reader:";
            // 
            // reader_comboBox
            // 
            this.reader_comboBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.reader_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reader_comboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.reader_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reader_comboBox.FormattingEnabled = true;
            this.reader_comboBox.Location = new System.Drawing.Point(97, 7);
            this.reader_comboBox.Name = "reader_comboBox";
            this.reader_comboBox.Size = new System.Drawing.Size(504, 28);
            this.reader_comboBox.TabIndex = 1;
            // 
            // Identity
            // 
            this.Identity.Controls.Add(this.write_button);
            this.Identity.Controls.Add(this.compte_num_textBox);
            this.Identity.Controls.Add(this.carte_num_textBox);
            this.Identity.Controls.Add(this.last_Name_textBox);
            this.Identity.Controls.Add(this.name_textBox);
            this.Identity.Controls.Add(this.label4);
            this.Identity.Controls.Add(this.label5);
            this.Identity.Controls.Add(this.label3);
            this.Identity.Controls.Add(this.label2);
            this.Identity.Location = new System.Drawing.Point(12, 93);
            this.Identity.Name = "Identity";
            this.Identity.Size = new System.Drawing.Size(519, 281);
            this.Identity.TabIndex = 2;
            this.Identity.TabStop = false;
            this.Identity.Text = "Idtentity";
            // 
            // write_button
            // 
            this.write_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.write_button.Location = new System.Drawing.Point(364, 220);
            this.write_button.Name = "write_button";
            this.write_button.Size = new System.Drawing.Size(117, 33);
            this.write_button.TabIndex = 3;
            this.write_button.Text = "Valider";
            this.write_button.UseVisualStyleBackColor = true;
            this.write_button.Click += new System.EventHandler(this.write_button_Click);
            // 
            // compte_num_textBox
            // 
            this.compte_num_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compte_num_textBox.Location = new System.Drawing.Point(120, 125);
            this.compte_num_textBox.Multiline = true;
            this.compte_num_textBox.Name = "compte_num_textBox";
            this.compte_num_textBox.Size = new System.Drawing.Size(360, 30);
            this.compte_num_textBox.TabIndex = 2;
            // 
            // carte_num_textBox
            // 
            this.carte_num_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carte_num_textBox.Location = new System.Drawing.Point(120, 173);
            this.carte_num_textBox.Multiline = true;
            this.carte_num_textBox.Name = "carte_num_textBox";
            this.carte_num_textBox.Size = new System.Drawing.Size(360, 30);
            this.carte_num_textBox.TabIndex = 2;
            // 
            // last_Name_textBox
            // 
            this.last_Name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.last_Name_textBox.Location = new System.Drawing.Point(120, 77);
            this.last_Name_textBox.Multiline = true;
            this.last_Name_textBox.Name = "last_Name_textBox";
            this.last_Name_textBox.Size = new System.Drawing.Size(360, 30);
            this.last_Name_textBox.TabIndex = 2;
            // 
            // name_textBox
            // 
            this.name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_textBox.Location = new System.Drawing.Point(120, 29);
            this.name_textBox.Multiline = true;
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(360, 30);
            this.name_textBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "N° Carte:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "N° Compte:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Prénom:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.value_dateTimePicker);
            this.groupBox1.Controls.Add(this.generate_Pin_button);
            this.groupBox1.Controls.Add(this.valide_button);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pin_textBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 378);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 190);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Security";
            // 
            // value_dateTimePicker
            // 
            this.value_dateTimePicker.CustomFormat = "";
            this.value_dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.value_dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.value_dateTimePicker.Location = new System.Drawing.Point(257, 36);
            this.value_dateTimePicker.MinDate = new System.DateTime(2020, 11, 20, 0, 0, 0, 0);
            this.value_dateTimePicker.Name = "value_dateTimePicker";
            this.value_dateTimePicker.Size = new System.Drawing.Size(179, 30);
            this.value_dateTimePicker.TabIndex = 6;
            this.value_dateTimePicker.Value = new System.DateTime(2020, 11, 20, 0, 0, 0, 0);
            // 
            // generate_Pin_button
            // 
            this.generate_Pin_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generate_Pin_button.Location = new System.Drawing.Point(332, 83);
            this.generate_Pin_button.Name = "generate_Pin_button";
            this.generate_Pin_button.Size = new System.Drawing.Size(105, 33);
            this.generate_Pin_button.TabIndex = 3;
            this.generate_Pin_button.Text = "Générer";
            this.generate_Pin_button.UseVisualStyleBackColor = true;
            this.generate_Pin_button.Click += new System.EventHandler(this.generate_Pin_button_Click);
            // 
            // valide_button
            // 
            this.valide_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valide_button.Location = new System.Drawing.Point(321, 129);
            this.valide_button.Name = "valide_button";
            this.valide_button.Size = new System.Drawing.Size(117, 33);
            this.valide_button.TabIndex = 3;
            this.valide_button.Text = "Valider";
            this.valide_button.UseVisualStyleBackColor = true;
            this.valide_button.Click += new System.EventHandler(this.valide_button_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(90, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Code PIN:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(90, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Date d\'expiration:";
            // 
            // pin_textBox
            // 
            this.pin_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pin_textBox.Location = new System.Drawing.Point(257, 84);
            this.pin_textBox.Multiline = true;
            this.pin_textBox.Name = "pin_textBox";
            this.pin_textBox.Size = new System.Drawing.Size(69, 30);
            this.pin_textBox.TabIndex = 2;
            // 
            // groupeBox3
            // 
            this.groupeBox3.Controls.Add(this.data_listBox);
            this.groupeBox3.Location = new System.Drawing.Point(551, 188);
            this.groupeBox3.Name = "groupeBox3";
            this.groupeBox3.Size = new System.Drawing.Size(463, 554);
            this.groupeBox3.TabIndex = 5;
            this.groupeBox3.TabStop = false;
            this.groupeBox3.Text = "Data";
            // 
            // data_listBox
            // 
            this.data_listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_listBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.data_listBox.FormattingEnabled = true;
            this.data_listBox.HorizontalScrollbar = true;
            this.data_listBox.ItemHeight = 22;
            this.data_listBox.Location = new System.Drawing.Point(6, 19);
            this.data_listBox.Name = "data_listBox";
            this.data_listBox.ScrollAlwaysVisible = true;
            this.data_listBox.Size = new System.Drawing.Size(451, 510);
            this.data_listBox.TabIndex = 0;
            this.data_listBox.SelectedIndexChanged += new System.EventHandler(this.data_listBox_SelectedIndexChanged);
            // 
            // import_file_textBox
            // 
            this.import_file_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.import_file_textBox.Location = new System.Drawing.Point(549, 101);
            this.import_file_textBox.Multiline = true;
            this.import_file_textBox.Name = "import_file_textBox";
            this.import_file_textBox.Size = new System.Drawing.Size(354, 30);
            this.import_file_textBox.TabIndex = 6;
            // 
            // import_button
            // 
            this.import_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.import_button.Location = new System.Drawing.Point(909, 100);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(105, 33);
            this.import_button.TabIndex = 7;
            this.import_button.Text = "Import";
            this.import_button.UseVisualStyleBackColor = true;
            this.import_button.Click += new System.EventHandler(this.import_button_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Menu;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stat_toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 744);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1048, 31);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "ETO MAHITA IZY";
            // 
            // stat_toolStripStatusLabel
            // 
            this.stat_toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stat_toolStripStatusLabel.Name = "stat_toolStripStatusLabel";
            this.stat_toolStripStatusLabel.Size = new System.Drawing.Size(163, 25);
            this.stat_toolStripStatusLabel.Text = "Waiting for a card";
            // 
            // reponse_texBox
            // 
            this.reponse_texBox.Location = new System.Drawing.Point(12, 575);
            this.reponse_texBox.Multiline = true;
            this.reponse_texBox.Name = "reponse_texBox";
            this.reponse_texBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reponse_texBox.Size = new System.Drawing.Size(508, 167);
            this.reponse_texBox.TabIndex = 9;
            // 
            // refresh_button
            // 
            this.refresh_button.Image = ((System.Drawing.Image)(resources.GetObject("refresh_button.Image")));
            this.refresh_button.Location = new System.Drawing.Point(607, 0);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(50, 44);
            this.refresh_button.TabIndex = 10;
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(552, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Recherche:";
            // 
            // search_textBox
            // 
            this.search_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_textBox.Location = new System.Drawing.Point(670, 150);
            this.search_textBox.Multiline = true;
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(338, 30);
            this.search_textBox.TabIndex = 11;
            // 
            // Card_Face
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 775);
            this.Controls.Add(this.search_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.reponse_texBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.import_button);
            this.Controls.Add(this.import_file_textBox);
            this.Controls.Add(this.groupeBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Identity);
            this.Controls.Add(this.reader_comboBox);
            this.Controls.Add(this.label1);
            this.Name = "Card_Face";
            this.Text = "CardFace";
            this.Load += new System.EventHandler(this.Card_Face_Load);
            this.Identity.ResumeLayout(false);
            this.Identity.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupeBox3.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox reader_comboBox;
        private System.Windows.Forms.GroupBox Identity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox compte_num_textBox;
        private System.Windows.Forms.TextBox carte_num_textBox;
        private System.Windows.Forms.TextBox last_Name_textBox;
        private System.Windows.Forms.Button write_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button valide_button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pin_textBox;
        private System.Windows.Forms.GroupBox groupeBox3;
        private System.Windows.Forms.Button generate_Pin_button;
        private System.Windows.Forms.TextBox import_file_textBox;
        private System.Windows.Forms.Button import_button;
        private System.Windows.Forms.DateTimePicker value_dateTimePicker;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel stat_toolStripStatusLabel;
        private System.Windows.Forms.ListBox data_listBox;
        private System.Windows.Forms.TextBox reponse_texBox;
        private System.Windows.Forms.Button refresh_button;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox search_textBox;
    }
}