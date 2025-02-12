using MyGame;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        //private float _startX, _startY;
        private float _endX, _endY;
        public MyLine(SplashKitSDK.Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            //this._startX = startX;
            //this._startY = startY;
            this._endX = endX;
            this._endY = endY;
            //this._endX = endX;
        }

        public MyLine() : this(SplashKitSDK.Color.Red, 300, 400, SplashKit.MouseX(), SplashKit.MouseY())
        {

        }

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

            if (this.Selected)
            {
                this.DrawOutline();
            }
            SplashKit.DrawLine(SplashKitSDK.Color.Red, this.X, this.Y, this.EndX, this.EndY);
        }

        public override void DrawOutline()
        {
            //float startX = 300, startY = 400;
            MyCircle start_circle = new MyCircle(SplashKitSDK.Color.Red, this.EndX, this.EndY, 2);
            start_circle.Draw();
            MyCircle end_circle = new MyCircle(SplashKitSDK.Color.Red, this.X, this.Y, 2);
            end_circle.Draw();
        }
        public override bool IsAt(SplashKitSDK.Point2D pt)
        {
            Point2D p; p.X = this.X; p.Y = this.Y;
            Point2D t; t.X = this.EndX; t.Y = this.EndY;
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(t, p));
        }
        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(this.EndX);
            writer.WriteLine(this.EndY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            this.EndX = reader.ReadInteger();
            this.EndY = reader.ReadInteger();
        }
    }
}
