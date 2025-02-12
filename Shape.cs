using MyGame;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;

        // default assignment for no warnings
        //private int _width = 0, _height = 0;
        private bool _selected;

        public Shape(Color color)
        {
            this._x = 0.0f;
            this._y = 0.0f;
            this._color = color;
        }

        public Shape() : this(Color.Yellow) { }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {

            get { return this._x; }
            set { this._x = value; }
        }

        public float Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        public bool Selected
        {
            get { return this._selected; }
            set { this._selected = value; }
        }


        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract bool IsAt(Point2D pt);

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(this.Color);
            writer.WriteLine(this.X);
            writer.WriteLine(this.Y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            this.Color = reader.ReadColor();
            this.X = reader.ReadSingle();
            this.Y = reader.ReadSingle();
            //reader.Close();
        }
    }
}
