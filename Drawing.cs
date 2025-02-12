using MyGame;
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

        public Drawing() : this(Color.White)
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

            foreach (Shape shape in this._shapes)
            {
                shape.Selected = shape.IsAt(pt);
            }
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

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteColor(this._background);
            writer.WriteLine(this.ShapeCount);
            foreach (Shape s in this._shapes)
            {
                s.SaveTo(writer);
            }
            writer.Close();
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                //StreamReader reader = new StreamReader(filename);
                this._background = reader.ReadColor();
                int count = reader.ReadInteger();
                this._shapes.Clear();
                Shape s = new MyRectangle(); // to not error
                for (int i = 0; i < count; i++)
                {
                    string kind = reader.ReadLine();
                    if (kind == "Rectangle")
                    {
                        s = new MyRectangle();
                        //s.LoadFrom(reader);
                    }
                    else if (kind == "Circle")
                    {
                        s = new MyCircle();
                        //s.LoadFrom(reader);
                    }
                    else if (kind == "Line")
                    {
                        s = new MyLine();
                        //s.LoadFrom(reader);
                    }
                    else
                    {
                        throw new InvalidDataException("Unknown shape kind: " + kind);
                    }
                    s.LoadFrom(reader);
                    this._shapes.Add(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
