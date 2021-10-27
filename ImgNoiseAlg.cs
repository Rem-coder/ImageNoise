using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNoise
{
    class ImgNoiseAlg
    {
        private List<Bitmap> resultImgs { get; set; }

        public ImgNoiseAlg(Bitmap startImg)
        {
            resultImgs = GetNoiseImgs(startImg);         
        }

        protected List<Bitmap> GetNoiseImgs(Bitmap startImg)
        {
            var resultImgs = new List<Bitmap>(100);
            resultImgs.Add(startImg);
            var rng = new Random();

            for (var y = 0; y < startImg.Height; y++)
            {
                for(var x = 0; x < startImg.Width; x++)
                {

                }
            }

            return null;
        }
    }
}
