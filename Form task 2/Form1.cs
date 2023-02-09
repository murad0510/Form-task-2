using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_task_2
{
    public partial class Form1 : Form
    {
        public class FileHelper
        {
            public static void WriteJsonHuman(Human human)
            {
                var serializer = new JsonSerializer();
                using (var sw = new StreamWriter($"{human.Name}.json"))
                {
                    using (var jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                        serializer.Serialize(jw, human);
                    }
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                  Color.FromArgb(209, 210, 249),
                                                                  Color.FromArgb(169, 188, 208),
                                                                  90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PhoneNumber.Text.Length; i++)
            {

            }
            if (Name.Text != null && Surname.Text != null && Age.Text != null && Email.Text.EndsWith("@gmail.com") && PhoneNumber.Text.Length == 18 && Birthday.Text != null)
            {
                Human humans = new Human()
                {
                    Name = Name.Text,
                    Surname = Surname.Text,
                    Age = int.Parse(Age.Text),
                    Email = Email.Text,
                    Phone = PhoneNumber.Text,
                    BirthDate = Birthday.Text.ToString(),
                };

                FileHelper.WriteJsonHuman(humans);
                MessageBox.Show("The operation was successfully performed.");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("There may be information that you did not mention.");
            }
        }
    }
}
public class Human
{
    public int Age { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string BirthDate { get; set; }
}