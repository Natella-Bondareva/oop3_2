using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace oop3_2
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();
        public static Bitmap bitmap;
        private readonly object bitmapLock = new object();
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            UpdatePoints();
        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }
        private async void DrawVoronoiDiagram()
        {
            Stopwatch sw =new Stopwatch();
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);

            Dictionary<Point, Color> regionColors = new Dictionary<Point, Color>();
            foreach (Point point in points)
            {
                regionColors.Add(point, GetRandomColor());
            }

            sw.Start();


            if (MultiThreadMode.Checked == false)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Point closestPoint = GetClosestPoint(new Point(x, y));
                        bitmap.SetPixel(x, y, regionColors[closestPoint]);
                    }
                }
            }
            else
            {
                int numThreads = Environment.ProcessorCount;
                int rowsPerThread = bitmap.Height / numThreads;
                Task[] tasks = new Task[numThreads];
                double width = bitmap.Width;

                for (int i = 0; i < numThreads; i++)
                {
                    int threadIndex = i; 
                    tasks[i] = Task.Run(() =>
                    {
                        int startY = threadIndex * rowsPerThread;
                        int endY = (threadIndex == numThreads - 1) ? bitmap.Height : startY + rowsPerThread;

                        for (int y = startY; y < endY; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                Point closestPoint = GetClosestPoint(new Point(x, y));
                                Color color  = regionColors[closestPoint];
                                lock (bitmapLock)
                                {
                                    bitmap.SetPixel(x, y, color);
                                }
                            }
                        }
                    });
                }

                await Task.WhenAll(tasks);               
            }

            pictureBox.BackgroundImage = bitmap;
            DrawPoints();
            sw.Stop();
            textBox1.Text = $"Час виконання: {sw.ElapsedMilliseconds}";
        }

        private Point GetClosestPoint(Point pixel)
        {
            Point closestPoint = points[0];
            double closestDistance = Distance(points[0], pixel);
            foreach (Point point in points)
            {
                double distance = Distance(point, pixel);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPoint = point;
                }
            }
            return closestPoint;
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private void DrawPoints()
        {
            Graphics g = Graphics.FromImage(bitmap);
            foreach (Point point in points)
            {
                DrawPoint(g, point);
            }
            pictureBox.Image = bitmap;
        }

        private void DrawPoint(Graphics g, Point point)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            Pen whitePen = new Pen(Color.White, 3);
            int pointSize = 3;
            g.DrawEllipse(blackPen, point.X - pointSize / 2, point.Y - pointSize / 2, pointSize, pointSize);
            pointSize = 6;
            g.DrawEllipse(whitePen, point.X - pointSize / 2, point.Y - pointSize / 2, pointSize, pointSize);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = e.Location;

            int index = points.FindIndex(p => Math.Abs(p.X - e.X) <= 6 && Math.Abs(p.Y - e.Y) <= 6);
            if (index != -1)
            {
                points.RemoveAt(index);
            }
            else
            {
                points.Add(point);
            }
            UpdatePoints();
            DrawPoints();
        }

        public void UpdatePoints()
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.LightGray);
            pictureBox.BackgroundImage = bitmap;
        }
        public void ClearAll()
        {
            points.Clear();
            UpdatePoints();
            pictureBox.Refresh();
        }
        public void DrawRandomPoints(double cout)
        {
            Point point;

            for (int i = 0; i < cout; i++)
            {
                do
                {
                    point = new Point(rand.Next(pictureBox.Width), rand.Next(pictureBox.Height));
                } while (points.Contains(point));
                points.Add(point);              
            }
            DrawPoints();
        }
        private void buttonDoCalculation_Click(object sender, EventArgs e)
        {
            if(points.Count > 0)
            {
                DrawVoronoiDiagram(); 
            }
        }

        private void buttonRandomPoints_Click(object sender, EventArgs e)
        {
            ClearAll();
            DrawRandomPoints(500);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
