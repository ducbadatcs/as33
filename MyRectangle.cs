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

        public MyRectangle() : base()
        {
            //this.Color = SplashKitSDK.Color.Azure;
            // still maintain the old param
            int param = 152;
            this._width = param;
            this._height = param;
        }
        public MyRectangle(
            SplashKitSDK.Color color, 
            float x, float y, int width, int height) : base(color)
        {
            //this.Color = color;
            this.X = x;
            this.Y = y;
            this._width = width;
            this._height = height;
        }

        public MyRectangle() : this(SplashKitSDK.Color.Green, 0.0f, 0.0f, 100 + 52, 100 + 52) { } 

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

        

        
        public override void Draw()
        {
            if (this.Selected)
            {
                this.DrawOutline();
            }
            SplashKit.FillRectangle(this.Color, this.X, this.Y, this.Width, this.Height);
        }

        public override void DrawOutline()
        {
            float x = 5 + 2;
            SplashKit.DrawRectangle(
                SplashKitSDK.Color.Black,
                this.X - (x / 2), this.Y - (x / 2),
                this.Width + x, this.Height + x
                //outlineWidth
            );
        }


        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt.X, pt.Y, this.X, this.Y, this.Width, this.Height);
        }
    }
}
