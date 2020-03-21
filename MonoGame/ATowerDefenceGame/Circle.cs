using System;
using Microsoft.Xna.Framework;

namespace ATowerDefenceGame
{
    public struct Circle
    {
        public readonly Vector2 Position;
        public readonly float Radius;

        public Circle(Vector2 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        public Circle Offset(Vector2 dp)
        {
            return new Circle(Position + dp, Radius);
        }

        public Vector2 Sample()
        {
            var r = Radius * (float) Math.Sqrt(RngGenerator.GetFloat());
            var phi = MathHelper.TwoPi * RngGenerator.GetFloat();
            return Position + new Vector2(r * (float) Math.Cos(phi), r * (float) Math.Sin(phi));
        }

        public bool Overlaps(Circle other)
        {
            return Vector2.Distance(this.Position, other.Position) < this.Radius + other.Radius;
        }
    }
}