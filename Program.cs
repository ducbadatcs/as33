using SplashKitSDK;
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

            bool pending_line = false;
            MyLine newLine = new MyLine(myDrawing.Background, 0, 0, 0, 0);
            const string fname = "C:\\Users\\minhduc\\Desktop\\TestWriter.txt"; // just too lazy to type everything out
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        newShape = new MyCircle();
                        newShape.X = SplashKit.MouseX();
                        newShape.Y = SplashKit.MouseY();
                        myDrawing.AddShape(newShape);
                    }

                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        newShape = new MyRectangle();
                        newShape.X = SplashKit.MouseX();
                        newShape.Y = SplashKit.MouseY();
                        myDrawing.AddShape(newShape);
                    }

                    else
                    {
                        // why are lines a pain
                        if (pending_line == false)
                        {
                            newLine = new MyLine();
                            //int add_times = 2;
                            newLine.X = SplashKit.MouseX();
                            newLine.Y = SplashKit.MouseY();
                            //newLine.EndX = SplashKit.MouseX();
                            //newLine.EndY = SplashKit.MouseY();
                            pending_line = true;
                        }
                        else
                        {
                            newLine.EndX = SplashKit.MouseX();
                            newLine.EndY = SplashKit.MouseY();
                            myDrawing.AddShape(newLine);
                            newLine = new MyLine(myDrawing.Background, 0, 0, 0, 0);
                            pending_line = false;
                        }
                        // waiting for another mouse click
                    }
                }


                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
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
                    (
                        SplashKit.KeyTyped(KeyCode.DeleteKey) ||
                        SplashKit.KeyTyped(KeyCode.BackspaceKey)
                    )
                )
                {
                    foreach (Shape shape in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {

                    myDrawing.Save(fname);
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load(fname);
                    }
                    catch (Exception e)
                    {
                        Console.Error.Write("Error loading file {0}: ", e.Message);
                    }
                }


                myDrawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}