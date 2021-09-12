using Emgu.CV;

namespace dissertation.Models
{
    internal class Camera
    {
        private VideoCapture Capture;
        public double Focus { get; set; }
        public double Distance { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Camera()
        {
            Capture = new VideoCapture();
        }

        public Camera(double focus, double distance, double width, double height) : this()
        {
            Focus = focus;
            Distance = distance;
            Width = width;
            Height = height;
        }

        public Mat GetFrame()
        {
            Mat image = Capture.QueryFrame();
            return image;
        }
    }
}
