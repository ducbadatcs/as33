using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX, _endY;
        public MyLine(SplashKitSDK.Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            this._endX = endX;
            this._endY = endY;
            //this._endX = endX;
        }

        public MyLine() : this(SplashKitSDK.Color.Red, 300, 400, SplashKit.MouseX(), SplashKit.MouseY()) { }
        public float EndX
        {
            get { return this._endX; }
            set { this._endX = value; }
        }

        public float EndY
        {
            get { return this._endY; }
            set { this._endY = value; }
        }

        public override void Draw()
        {
            float startX = 300, startY = 400;
            if (this.Selected)
            {
                this.DrawOutline();
            }
            SplashKit.DrawLine(SplashKitSDK.Color.Red, startX, startY, this._endX, this._endY);
        }

        public override void DrawOutline()
        {
            float startX = 300, startY = 400;
            MyCircle start_circle = new MyCircle(SplashKitSDK.Color.Red, this._endX, this._endY, 2);
            start_circle.Draw();
            MyCircle end_circle = new MyCircle(SplashKitSDK.Color.Red, startX, startY, 2);
            end_circle.Draw();
        }

        public override bool IsAt(SplashKitSDK.Point2D pt)
        {
            Point2D p; p.X = 300f; p.Y = 400.0f;
            Point2D t; t.X = this._endX; t.Y = this._endY;
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(t, p));
        }
    }
}
