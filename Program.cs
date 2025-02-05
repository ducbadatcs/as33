using SplashKitSDK;
using System.Linq.Expressions;
namespace ShapeDrawer3._3
{
    public class Program
    {
        public static void Main()
        {
            // assign shape

            //student id: 105541452

            Drawing myDrawing = new Drawing();
            Window window = new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape added_shape = new Shape(152);
                    added_shape.X = SplashKit.MouseX();
                    added_shape.Y = SplashKit.MouseY();
                    myDrawing.AddShape(added_shape);
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