using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;

        //public Shape() { }

        

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
        public Shape()
        {
            this.Color = Color.Azure;
        }

        public Shape(Color color)
        {
            this.Color = color;
        }

        public virtual void Draw() 
        {
            if (this.Selected) 
            {
                this.DrawOutline();
            }
            SplashKit.FillRectangle(this._color, this._x, this._y, this._width, this._height);
        }
        public virtual void DrawOutline() { }
        public abstract bool IsAt(Point2D pt);
    }
}
