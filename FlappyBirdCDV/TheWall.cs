using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlappyBirdCDV
{
    internal class TheWall
    {
        public float x;
        public float y;

        public int sizeX;
        public int sizeY;

        public Image wallImg;

        public TheWall(int x, int y, bool isRotatedImage = false)
        {
            wallImg = new Bitmap(@"D:\dev\Desktop\charp\FlappyBirdCDV\FlappyBirdCDV\thewall.png");
            this.x = x;
            this.y = y;
            sizeX = 150;
            sizeY = 350;

            if (isRotatedImage)
            {
                wallImg.RotateFlip(RotateFlipType.Rotate180FlipX);
            }

        }
    }
}
