using SplashKitSDK;
using System.Linq.Expressions;
namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle, Circle, Line
        };
        public static void Main()
        {
            // assign shape

            //student id: 105541452

            Drawing myDrawing = new Drawing();
            Window window = new Window("Shape Drawer", 800, 600);

            ShapeKind kindToAdd = ShapeKind.Circle;
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyDown(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                else if (SplashKit.KeyDown(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                else if (SplashKit.KeyDown(KeyCode.LKey)) 
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        newShape = new MyCircle();
                    }

                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        newShape = new MyRectangle();
                    }

                    else
                    {
                         newShape = new MyLine();
                    }

                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    int add_times = 1;
                    if (kindToAdd == ShapeKind.Line) 
                    {
                        add_times = 2;
                    }
                    for (int i = 0; i < add_times; i++)
                    {
                        myDrawing.AddShape(newShape);
                    }
                }
                

                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    myDrawing.Background = Color.Random();
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    Point2D mouseLocation;
                    mouseLocation.X = SplashKit.MouseX();
                    mouseLocation.Y = SplashKit.MouseY();

                    myDrawing.SelectShapesAt(mouseLocation);
                    //List<Shape> selected_shapes = myDrawing.SelectedShapes;
                    //foreach (Shape shape in selected_shapes)
                    //{
                    //    shape.Draw();
                    //}
                    foreach (Shape shape in myDrawing.SelectedShapes)
                    {
                        Console.WriteLine("sel");
                    }
                }

                if (
                    SplashKit.KeyDown(KeyCode.DeleteKey) ||
                    SplashKit.KeyDown(KeyCode.BackspaceKey))
                {
                    foreach(Shape shape in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }


                myDrawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}