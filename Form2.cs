using System;
using System.Drawing;
using System.Windows.Forms;

namespace EBS4luacici
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        private bool resizing = false; // Kullanıcı yeniden boyutlandırıyor mu
        private Point lastMousePosition; // Son mouse konumu

        private Point lastPoint;

        private void DragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void DragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            // Sağ alt köşeye tıklandıysa yeniden boyutlandırmayı başlat
            if (e.Button == MouseButtons.Left && e.X >= this.Width - 10 && e.Y >= this.Height - 10)
            {
                resizing = true;
                lastMousePosition = e.Location;
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (resizing)
            {
                // Fare hareketine göre formun genişlik ve yüksekliğini ayarla
                this.Width += e.X - lastMousePosition.X;
                this.Height += e.Y - lastMousePosition.Y;
                lastMousePosition = e.Location;
            }
            else
            {
                // Sağ alt köşeye gelindiğinde cursor değiştir
                if (e.X >= this.Width - 10 && e.Y >= this.Height - 10)
                {
                    this.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            // Yeniden boyutlandırmayı durdur
            if (e.Button == MouseButtons.Left)
            {
                resizing = false;
            }
        }
    }
}
