using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using SplashKitSDK;

namespace ShapeDrawer
{
    internal class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            this._shapes = new List<Shape>();
            this._background = background;
        }

        public Drawing() : this (Color.White)
        {
        }

        public Color Background 
        {
            get { return this._background; } 
            set { this._background = value; }
        }

        public int ShapeCount
        {
            get { return this._shapes.Count; }
        }

        public void AddShape(Shape s)
        {
            this._shapes.Add(s);
        }

        public void RemoveShape(Shape s)
        {
            this._shapes.Remove(s);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(this._background);
            foreach (Shape shape in this._shapes)
            {
                //Console.WriteLine(shape.Selected);
                shape.Draw();
            }
        }

        public void SelectShapesAt(Point2D pt)
        {
            //for (int i = 0; i < this._shapes.Count; i++)
            //{
            //    if (this._shapes[i].IsAt(pt))
            //    {
            //        this._shapes[i].Selected = true;
            //    }
            //}

            //foreach (Shape shape in this._shapes)
            //{
            //    shape.Selected = shape.IsAt(pt);
            //}
        }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result = new List<Shape>();
                foreach (Shape shape in this._shapes)
                {
                    if (shape.Selected)
                    {
                        result.Add(shape);
                    }
                }
                return result;
            }
        }
    }
}
