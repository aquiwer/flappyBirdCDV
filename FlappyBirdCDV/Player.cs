using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBirdCDV
{
    public class Player
    {
        public float x;
        public float y;

        public int size;
        public int score;
        public bool hardLevel;
        public bool isAlive;

        public float gravityValue;
        
        public Image birdImg;

        public Player(int x, int y)
        {
            birdImg = new Bitmap(@"D:\dev\Desktop\charp\FlappyBirdCDV\FlappyBirdCDV\bird.png");
            this.x = x;
            this.y = y;
            size = 50;
            isAlive = true;
            score = 0;
            gravityValue = 0.2f;

            hardLevel = false;
        }
    }
}
