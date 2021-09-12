using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Mat binarized = null;
            CvInvoke.AdaptiveThreshold(source, binarized, 255, AdaptiveThresholdType.MeanC, ThresholdType.Binary, 3, 5);
            return binarized;
        }
    }
}
