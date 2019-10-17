using System;
using System.Collections.Generic;

namespace SnakeLib
{
    public class Snake
    {
        private int fieldWidth;
        private int fieldHeight;

        private Point direction;

        private Random R = new Random();

        public bool Alive { get; private set; }

        public Point Food { get; private set; }

        public List<Point> Body { get; private set; }

        public int Length => Body.Count; 

        public Direction Direction
        { 
            set { direction = GetDirection(value); }
        }

        public Snake(int fieldWidth, int fieldHeight, int startX = 0, int startY = 0, Direction defaultDirection = Direction.right)
        {
            this.fieldHeight = fieldHeight;
            this.fieldWidth = fieldWidth;

            direction = GetDirection(defaultDirection);

            var head = new Point(startX, startY);

            if (IsOutside(head))
                throw new ArgumentOutOfRangeException("Invalid start coordinates");

            Body = new List<Point>(){ head };

            NewFood();

            Alive = true;
        }

        public void Move()
        {
            for (int i = Body.Count - 1; i > 0; i--)
                Body[i] = new Point(Body[i - 1]);

            Body[0] += direction;

            Alive = !(IsOnTail(Body[0]) || IsOutside(Body[0]));

            if (IsOnFood(Body[0]))
            {
                Body.Add(new Point(Body[^1]));

                NewFood();
            }
        }

        bool IsOnFood(Point Point) => (Point == Food);

        bool IsOutside(Point Point) => (Point.X < 0 || Point.X >= fieldWidth || Point.Y < 0 || Point.Y >= fieldHeight);

        bool IsOnTail(Point Point)
        {
            foreach (var segment in Body.ToArray()[1..])
                if (Point == segment)
                    return true;

            return false;
        }

        void NewFood()
        {
            do
            {
                Food = new Point(R.Next(0, fieldWidth), R.Next(0, fieldHeight));
            } while (IsOnTail(Food));
        }

        Point GetDirection(Direction direction) =>
            direction switch
            {
                Direction.up => new Point(0, -1),
                Direction.down => new Point(0, 1),
                Direction.left => new Point(-1, 0),
                Direction.right => new Point(1, 0),
                _ => new Point(0, 0),
            };
    }
}