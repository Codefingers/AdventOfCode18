namespace AdventOfCode18.Day10
{
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int xVelocity { get; }
        public int yVelocity { get; }

        public Point(int x, int y, int xVelocity, int yVelocity)
        {
            this.x = x;
            this.y = y;
            this.xVelocity = xVelocity;
            this.yVelocity = yVelocity;
        }
    }
}