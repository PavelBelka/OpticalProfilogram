using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using dissertation.Commands;
using dissertation.Models;
using Emgu.CV;

namespace dissertation.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        [DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr o);

        private Camera _camera;
        private ImageProcessing _imgproc;

        private string _Text_log;
        private ImageSource _Image_Box;

        /// <summary>Текст лога</summary>
        public string Text_log
        {
            get => _Text_log;
            set => Set(ref _Text_log, value);
        }

        public ImageSource Image_Box
        {
            get => _Image_Box;
            set => Set(ref _Image_Box, value);
        }

        public ICommand CloseApplicationCommand { get; }

        public ICommand GetFrameCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
 

        private void OnCloseApplicationCommandExecute(object p) => Application.Current.Shutdown();

        private bool CanGetFrameCommandExecute(object p) => true;

        private void OnGetFrameCommandExecute(object p)
        {
            Mat img2 = _camera.GetFrame();
            Mat proc = _imgproc.Binarization(img2);
            //Bitmap img = _camera.GetFrame().ToBitmap();
            Bitmap img = proc.ToBitmap();
            IntPtr ptr = img.GetHbitmap();

            BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                ptr,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(ptr);
            Image_Box = bs;
        }

        public MainWindowViewModel(Camera cam, ImageProcessing imgproc)
        {
            _camera = cam;
            _imgproc = imgproc;
            CloseApplicationCommand = new ActionCommand(OnCloseApplicationCommandExecute, CanCloseApplicationCommandExecute);
            GetFrameCommand = new ActionCommand(OnGetFrameCommandExecute, CanGetFrameCommandExecute);
            Text_log = "Тест лога";
        }
    }
}
