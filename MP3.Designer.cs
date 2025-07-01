namespace MW3_Projekt_Infinity_by_RATModz
{
    partial class MP3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MP3));
            this.metroLabel120 = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager();
            this.metroButton235 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroCheckBox20 = new MetroFramework.Controls.MetroCheckBox();
            this.openFileDialog_0 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // metroLabel120
            // 
            this.metroLabel120.AutoSize = true;
            this.metroLabel120.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroLabel120.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroLabel120.CustomBackground = false;
            this.metroLabel120.CustomForeColor = false;
            this.metroLabel120.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel120.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel120.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel120.Location = new System.Drawing.Point(10, 21);
            this.metroLabel120.Name = "metroLabel120";
            this.metroLabel120.Size = new System.Drawing.Size(111, 25);
            this.metroLabel120.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel120.TabIndex = 282;
            this.metroLabel120.Text = "WAV Player";
            this.metroLabel120.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel120.UseStyleColors = true;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton235
            // 
            this.metroButton235.Highlight = true;
            this.metroButton235.Location = new System.Drawing.Point(10, 56);
            this.metroButton235.Name = "metroButton235";
            this.metroButton235.Size = new System.Drawing.Size(209, 20);
            this.metroButton235.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton235.TabIndex = 283;
            this.metroButton235.Text = "Play Sound | Song";
            this.metroButton235.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton235.Click += new System.EventHandler(this.metroButton235_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Highlight = true;
            this.metroButton2.Location = new System.Drawing.Point(10, 81);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(209, 20);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton2.TabIndex = 285;
            this.metroButton2.Text = "Stop Playing";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroCheckBox20
            // 
            this.metroCheckBox20.AutoSize = true;
            this.metroCheckBox20.BackColor = System.Drawing.Color.Black;
            this.metroCheckBox20.CustomBackground = true;
            this.metroCheckBox20.CustomForeColor = false;
            this.metroCheckBox20.FontSize = MetroFramework.MetroLinkSize.Small;
            this.metroCheckBox20.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.metroCheckBox20.Location = new System.Drawing.Point(73, 109);
            this.metroCheckBox20.Name = "metroCheckBox20";
            this.metroCheckBox20.Size = new System.Drawing.Size(58, 15);
            this.metroCheckBox20.Style = MetroFramework.MetroColorStyle.Green;
            this.metroCheckBox20.TabIndex = 296;
            this.metroCheckBox20.Text = "Replay";
            this.metroCheckBox20.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox20.UseStyleColors = false;
            this.metroCheckBox20.UseVisualStyleBackColor = false;
            // 
            // openFileDialog_0
            // 
            this.openFileDialog_0.FileName = "openFileDialog1";
            // 
            // MP3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 132);
            this.Controls.Add(this.metroCheckBox20);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton235);
            this.Controls.Add(this.metroLabel120);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "MP3";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "MP3";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.MP3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel120;
        private MetroFramework.Controls.MetroButton metroButton235;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox20;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.OpenFileDialog openFileDialog_0;
    }
}