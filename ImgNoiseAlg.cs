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
        private List<Bitmap> resultNoiseImgs { get; set; }
        private List<Pixel> pixelsStartAmg { get; set; }

        public ImgNoiseAlg(Bitmap startImg)
        {
            resultNoiseImgs = GetNoiseImgs(startImg);
            pixelsStartAmg = GetListPixelsStartImg(startImg);
        }

        protected static List<Bitmap> GetNoiseImgs(Bitmap startImg)
        {
            var noisePercent = 1;
            var resultImgs = new List<Bitmap>(100);
            resultImgs.Add(startImg);

            for(; noisePercent < 100; noisePercent++)
                resultImgs.Add(GetImgNoisePercent(startImg, noisePercent));

            resultImgs.Add(new Bitmap(startImg.Width, startImg.Height));
            return resultImgs;
        }

        protected static List<Pixel> GetListPixelsStartImg(Bitmap startImg)
        {
            var pixelsStartAmg = new List<Pixel>(startImg.Width * startImg.Height);
            for (var y = 0; y < startImg.Height; y++)
                for (var x = 0; x < startImg.Width; x++)
                    pixelsStartAmg.Add(new Pixel(startImg.GetPixel(x, y), new Point(x, y)));
            return pixelsStartAmg;
        }

        protected static Bitmap GetImgNoisePercent(Bitmap startImg, int noisePercent)
        {
            var pixelsStartAmg = GetListPixelsStartImg(startImg);
            var newCountPixelsInImg = Convert.ToInt32(pixelsStartAmg.Count * (noisePercent * 0.01));
            var resPixelsInImg = new List<Pixel>(newCountPixelsInImg);
            var resBitmapPercent = new Bitmap(startImg.Width, startImg.Height);
            var rng = new Random();
            for (var i = 0; i < newCountPixelsInImg; i++)
            {
                var rngIndex = rng.Next(pixelsStartAmg.Count);
                resPixelsInImg.Add(pixelsStartAmg[rngIndex]);
                pixelsStartAmg.RemoveAt(rngIndex);
            }
            foreach (var pixel in resPixelsInImg)
                resBitmapPercent.SetPixel(pixel.Location.X, pixel.Location.Y, pixel.Color);
            return resBitmapPercent;
        }

        public List<Pixel> GetPixelsImg() => pixelsStartAmg;
        public List<Bitmap> GetNoiseImgs() => resultNoiseImgs;
    }
}
