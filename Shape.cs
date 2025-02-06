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

        // default assignment for no warnings
        private int _width = 0, _height = 0;
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
        

        public virtual void Draw() { }
        
        public virtual void DrawOutline() { }

        public virtual bool IsAt(Point2D pt) { return false; }
    }
}
