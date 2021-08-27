using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dissertation.Models
{
    class Camera
    {
        private VideoCapture Capture;
        public double Focus { get; set; }
        public double Distance { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public Camera() { }

        public Camera(double focus, double distance, double width, double height)
        {
            Capture = new VideoCapture();
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
