using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageNoise
{
    public partial class Form1 : Form
    {
        private SplitContainer split = new SplitContainer();
        private TrackBar trackBarIm = new TrackBar();
        private MenuStrip menuStrip = new MenuStrip();
        private ToolStripMenuItem openImgButt = new ToolStripMenuItem("Открыть");
        private OpenFileDialog openFile = new OpenFileDialog();
        private PictureBox imgBox = new PictureBox();


        public Form1()
        {
            MyInitializeComponent();
            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
            openImgButt.Click += (sender, args) => ClickOnOpenImg(); 

            ChageSize();
            CheckTrackBarImValue();
        }

        private void MyInitializeComponent()
        {
            this.Text = "0%";
            this.MinimumSize = new Size(300, 300);

            split.BorderStyle = BorderStyle.Fixed3D;
            split.IsSplitterFixed = true;

            trackBarIm.Orientation = Orientation.Vertical;
            trackBarIm.Maximum = 100;
            trackBarIm.Minimum = 0;
            trackBarIm.TickStyle = TickStyle.TopLeft;

            openImgButt.BackColor = Color.FromArgb(217, 211, 211);

            openFile.Filter = "Images (*.jpg)|*.jpg|Images(*.png)|*.png|Images(*.bmp)|*.bmp|Images(*.jpeg)|*.jpeg";

            imgBox.Location = new Point(0, menuStrip.Bottom);
            imgBox.SizeMode = PictureBoxSizeMode.Zoom;


            split.Panel1.Controls.Add(imgBox);
            menuStrip.Items.Add(openImgButt);
            split.Panel1.Controls.Add(menuStrip);           
            split.Panel2.Controls.Add(trackBarIm);
            Controls.Add(split);
        }

        private void ChageSize()
        {
            SizeChanged += (sender, args) =>
            {
                split.Size = new Size(ClientSize.Width, ClientSize.Height);
                split.SplitterDistance = ClientSize.Width - 40;

                imgBox.Size = new Size(split.Panel1.Width, split.Panel1.Height - menuStrip.Height);

                trackBarIm.Size = new Size(split.Width, split.Height);
            };
        }

        private void CheckTrackBarImValue()
        {
            trackBarIm.ValueChanged += (sender, args) => this.Text = trackBarIm.Value.ToString() + '%';
        }

        private void ClickOnOpenImg()
        {
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                imgBox.Image = new Bitmap(openFile.FileName);
            }
        }
    }
}
