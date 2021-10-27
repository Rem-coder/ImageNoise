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
        public List<Bitmap> ResultNoiseImgs { get; set; }
        public List<Pixel> PixelsStartAmg { get; set; }

        public ImgNoiseAlg(Bitmap startImg)
        {
            ResultNoiseImgs = GetNoiseImgs(startImg);
            PixelsStartAmg = GetListPixelsStartImg(startImg);
        }

        protected static List<Bitmap> GetNoiseImgs(Bitmap startImg)
        {
            var pixelsStartImg = GetListPixelsStartImg(startImg);
            var pixelResImg = new List<Pixel>(pixelsStartImg.Count);
            var rng = new Random();
            var resultImgs = new List<Bitmap>(100);
            resultImgs.Add(new Bitmap(startImg.Width, startImg.Height));
            for(var i = 1; i < 100; i++)
            {
                for (var j = 0; j < pixelsStartImg.Count / 100; j++)
                {
                    var rngNum = rng.Next(pixelsStartImg.Count);
                    pixelResImg.Add(pixelsStartImg[rngNum]);
                    pixelsStartImg.RemoveAt(rngNum);
                }
                var currentBitmap = new Bitmap(startImg.Width, startImg.Height);
                foreach (var pixel in pixelResImg)
                    currentBitmap.SetPixel(pixel.Location.X, pixel.Location.Y, pixel.Color);
                resultImgs.Add(currentBitmap);
            }
            resultImgs.Add(startImg);
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

        public List<Pixel> GetPixelsImg() => PixelsStartAmg;
        public List<Bitmap> GetNoiseImgs() => ResultNoiseImgs;
    }
}
