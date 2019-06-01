namespace AdventOfCode18.Day10
{
    public class Point
    {
        public int x { get; }
        public int y { get; }
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