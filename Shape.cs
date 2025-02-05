using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer3._3
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;
        public Shape(int param)
        {
            _color = Color.Azure;
            _x = 0.0f;
            _y = 0.0f;
            _width = param;
            _height = param;
        }
        

        public bool IsAt(Point2D pt)
        {
            // well that was convenient
            return SplashKit.PointInRectangle(pt.X, pt.Y, _x, _y, _width, _height);
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public bool Selected
        { 
            get { return _selected; } 
            set { _selected = value; }
        }

        public void DrawOutline()
        {
            int x = 5 + 2;
            SplashKit.FillRectangle(
                Color.Black,
                this._x - 3.5, this._y - 3.5,
                this._width + x, this._height + x
            );
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            if (this._selected)
            {
                this.DrawOutline();
            }
        }
    }
}
