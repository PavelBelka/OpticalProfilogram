using Emgu.CV;
using Emgu.CV.CvEnum;

namespace dissertation.Models
{
    internal class ImageProcessing
    {
        public ImageProcessing() { }

        public Mat Filter_median(Mat source)
        {
            Mat filtered = null;
            CvInvoke.MedianBlur(source, filtered, 3);
            return filtered;
        }

        public Mat Binarization(Mat source)
        {
            Mat binarized = new Mat();
            Mat gray = new Mat();
            CvInvoke.CvtColor(source, gray, ColorConversion.Bgr2Gray);
            CvInvoke.AdaptiveThreshold(gray, binarized, 128, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 3, 5);
            return binarized;
        }
    }
}
