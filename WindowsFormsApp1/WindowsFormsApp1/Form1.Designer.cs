using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(368, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += Form1_Load;            
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(5, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(793, 392);
            this.webBrowser1.TabIndex = 1;
            // NAVIGATING TO LOGIN PAGE
            this.webBrowser1.Navigate("https://mfiles-test.coex.no/Login.aspx?url=Default.aspx");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser webBrowser1;        

        private void Form1_Load(System.Object obj, System.EventArgs e)
        {
            // Waiting to ensure loginpage is loaded can use async and await instead            
            System.Threading.Thread.Sleep(2000);
            // Delay 12 seconds to render login page
            // Part 2: Automatically input username and password
            HtmlElementCollection theElementCollection;
            theElementCollection = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement curElement in theElementCollection)
            {
                string controlName = curElement.GetAttribute("id").ToString();
                if ((controlName == "txtUsername"))
                {
                    curElement.SetAttribute("Value", "your username here");
                }
                else if ((controlName == "txtPassword"))
                {
                    curElement.SetAttribute("Value", "your password here");
                    // In addition,you can get element value like this:
                    // MessageBox.Show(curElement.GetAttribute("Value"))
                }
            }
            // Part 3: Automatically click that Login button
            theElementCollection = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement curElement in theElementCollection)
            {
                if (curElement.GetAttribute("id").Equals("btnlogin"))
                {
                    curElement.InvokeMember("click");
                    // javascript has a click method for you need to invoke on button and hyperlink elements.
                }
            }
            System.Threading.Thread.Sleep(2000);
            webBrowser1.Navigate("https://mfiles-test.coex.no/Default.aspx#081790FC-2A0D-4035-A539-0C1FAA173AA1/views/");
        }
    }
}

