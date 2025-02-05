using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width, _height;
        public int Width
        {
            get { return this._width; }
            set { this._width = value; }
        }
        public int Height
        {
            get { return this._height; }
            set { this._height = value; }
        }

        public MyRectangle() : base()
        {
            //this.Color = SplashKitSDK.Color.Azure;
            // still maintain the old param
            int param = 152;
            this.Width = param;
            this.Height = param;
        }
        public MyRectangle(SplashKitSDK.Color color, float x, float y, int width, int height) : base(color)
        {
            this.Color = color;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        
        public override void Draw()
        {
            SplashKit.FillRectangle(this.Color, this.X, this.Y, this.Width, this.Height);
        }

        public override void DrawOutline()
        {
            int x = 5 + 2;
            SplashKit.FillRectangle(
                SplashKitSDK.Color.Black,
                this.X - (float)x / 2, this.Y - (float)x / 2, 
                this.Width + x, this.Height + x
            );
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt.X, pt.Y, this.X, this.Y, this.Width, this.Height);
        }
    }
}
