namespace FlappyBirdCDV
{
    public partial class Form1 : Form
    {
        public float gravity;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
            
            Init();
            Invalidate();
        }
        
            Player bird;
            TheWall wall;
            TheWall wall2;

        public void Init()
            {
                bird = new Player(200, 200);
                wall = new TheWall(500, -150, true);
                wall2 = new TheWall(500, 300);
                this.Text = "Flappy bird score: 0";

            timer1.Start();
        }
        
        private void update(object? sender, EventArgs e)
        {
            if(Collide(bird, wall) || Collide(bird, wall2))
            {
                bird.isAlive = false;
                timer1.Stop();
                Init();
            }
            if (bird.gravityValue != 0.1f)
                bird.gravityValue += 0.005f;
            gravity += bird.gravityValue;
            bird.y += gravity; ;

            if (bird.isAlive)
            {
                moveWalls();
            }

            Invalidate();
        }

        private bool Collide(Player bird, TheWall wall1)
        {
            PointF delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (wall1.x + wall1.sizeX / 2);
            delta.Y = (bird.y + bird.size / 2) - (wall1.y + wall1.sizeY / 2);
            if (Math.Abs(delta.X) <= (bird.size / 2 + wall1.sizeX / 2) - 55)
            {
                if (Math.Abs(delta.Y) <= (bird.size / 2 + wall1.sizeY / 2) - 55)
                {
                    return true;
                }else if(bird.y < wall1.y)
                {
                    return true;
                }
            }
            return false;
        }

        private void createNewWall()
        {
            Random random = new Random();
            int height1 = random.Next(-200, 000);
           
            if (wall.x < bird.x - 80)
            {
                wall = new TheWall(500, height1, true);
                wall2 = new TheWall(500, height1 + 400);
                bird.score++;
                this.Text = "Flappy bird score: " + bird.score;
            }
           
           
        }
        private void moveWalls ()
        {
            if (bird.hardLevel)
            {
                wall.x -= 2.0f;
                wall2.x -= 2.0f;
            }
            else
            {
                wall.x -= 1.5f;
                wall2.x -= 1.5f;
            }
            createNewWall();
        }
        
        private void Form1_Load(object sender, EventArgs e){}

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphic = e.Graphics;
            graphic.DrawImage(bird.birdImg, bird.x, bird.y, bird.size, bird.size);
  
            graphic.DrawImage(wall.wallImg, wall.x, wall.y, wall.sizeX, wall.sizeY);
 
            graphic.DrawImage(wall2.wallImg, wall2.x, wall2.y, wall2.sizeX, wall2.sizeY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bird.isAlive)
            {
                gravity = 0;
                bird.gravityValue = -0.125f;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bird.hardLevel = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bird.hardLevel = true;
        }
    }
}