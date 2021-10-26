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

        public Form1()
        {
            MyInitializeComponent();
        }

        private void MyInitializeComponent()
        {
            this.Text = "0%";
            split.BorderStyle = BorderStyle.Fixed3D;
            split.IsSplitterFixed = true;

            trackBarIm.Orientation = Orientation.Vertical;
            trackBarIm.Maximum = 100;
            trackBarIm.Minimum = 0;
            trackBarIm.TickStyle = TickStyle.TopLeft;

            split.Panel2.Controls.Add(trackBarIm);
            Controls.Add(split);

            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
                
            ChageSize();
            CheckTrackBarImValue();
        }

        private void ChageSize()
        {

            SizeChanged += (sender, args) =>
            {
                split.Size = new Size(ClientSize.Width, ClientSize.Height);
                split.SplitterDistance = ClientSize.Width - 40;

                trackBarIm.Size = new Size(split.Width, split.Height);
            };
        }

        private void CheckTrackBarImValue()
        {
            trackBarIm.ValueChanged += (sender, args) => this.Text = trackBarIm.Value.ToString() + '%';
        }
    }
}
