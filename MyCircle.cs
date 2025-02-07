using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;
 
        //public MyCircle() : this(color: Color.Blue, radius:50 + 52) 
        //{
        //    this._radius = 50;
        //}

        public MyCircle(Color color, float x, float y, int radius)
        {
            this.Color = color;
            this.X = x;
            this.Y = y;
            this._radius = radius;
        }

        public MyCircle(Color color, int radius) : base(color)
        {
            this.X = 0.0f;
            this.Y = 0.0f;
            this._radius = radius;
        }

        public MyCircle() : this(Color.Blue, 50 + 52) { }

        public int Radius
        {
            get { return this._radius; }
            set { this._radius = value; }
        }

        public override void Draw()
        {
            if (this.Selected)
            {
                this.DrawOutline();
            }
            SplashKit.FillCircle(this.Color, this.X, this.Y, this.Radius);
        }

        // idk
        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, this.Radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt.X, pt.Y, this.X, this.Y, this.Radius);
        }
    }
}
