using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Lib
{
    class Snake7
    {
        Direction Direction;
        Boolean canChangeDirection = true;

        int NumX;
        int NumY;

        Random rand;
        public List<Point> Points;
        public Point Food;

        public Snake7(int numX, int numY)
        {
            NumX = numX;
            NumY = numY;

            rand = new Random();
            Points = new List<Point>();
            Food = new Point(0, 0);
            CreateNewFood();

            Points.Add(new Point(NumX / 2 + 1, numY / 2));
            Points.Add(new Point(NumX / 2 + 0, numY / 2));
            Points.Add(new Point(NumX / 2 - 1, numY / 2));
            Points.Add(new Point(NumX / 2 - 2, numY / 2));

            Direction = Direction.Right;
        }

        public void Move()
        {
            var count = Points.Count;

            for (int i = count - 1; i > 0; --i)
                Points[i].Set(Points[i - 1]);

            switch (Direction)
            {
                case Direction.Left:
                    Points[0].X = (Points[0].X + NumX - 1) % NumX;
                    break;
                case Direction.Right:
                    Points[0].X = (Points[0].X + 1) % NumX;
                    break;
                case Direction.Up:
                    Points[0].Y = (Points[0].Y + NumY - 1) % NumY;
                    break;
                case Direction.Down:
                    Points[0].Y = (Points[0].Y + 1) % NumY;
                    break;
            }

            if (CanEat())
                FinishEating();

            canChangeDirection = true;
        }

        private Boolean CanEat()
        {
            if (Points[0].Equals(Food))
                return true;

            return false;
        }

        private void FinishEating()
        {
            var count = Points.Count;
            var last = Points[count - 1];

            Points.Add(new Point(last.X, last.Y));
            CreateNewFood();
        }

        private void CreateNewFood()
        {
            var newFood = true;

            while (newFood)
            {
                Food.X = rand.Next() % NumX;
                Food.Y = rand.Next() % NumY;
                newFood = false;

                var count = Points.Count;
                for (int i = 0; i < count; ++i)
                    if (Points[i].Equals(Food))
                        newFood = true;
            }
        }

        public void SetDirection(Direction direction)
        {
            if (canChangeDirection)
            {
                if (Direction == Direction.Left && direction == Direction.Right)
                    return;
                if (Direction == Direction.Right && direction == Direction.Left)
                    return;
                if (Direction == Direction.Up && direction == Direction.Down)
                    return;
                if (Direction == Direction.Down && direction == Direction.Up)
                    return;

                Direction = direction;
                canChangeDirection = false;
            }
        }

        public Boolean IsCrossed()
        {
            var count = Points.Count;

            for (int i = 1; i < count; ++i)
                if (Points[0].Equals(Points[i]))
                    return true;

            return false;
        }
    }
}
