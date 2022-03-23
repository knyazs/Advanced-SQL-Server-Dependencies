using System;
using System.Drawing;
using AdvancedSqlServerDependencies.Properties;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace AdvancedSqlServerDependencies.Progress
{
    public class LongRunningOperation
    {
        public EProgressState State;
        public string OperationName;
        public DateTime DateTimeStarted;
        public DateTime DateTimeFinished;
        public int ProgressPercentage;
        public double Weight;

        public string ProgressPercentagePct
        {
            get {
                return ProgressPercentage >= 0 ? string.Format("{0}%", ProgressPercentage) : "N/A";
            }
        }

        public Image Image
        {
            get
            {
                Image img;
                switch (State)
                {
                    case EProgressState.NotStarted:
                        img = Resources.circle_red_16_ns; break; //Resources.wait_16x16;
                    case EProgressState.Running:
                        img = Resources.circle_yellow_16_ns; break; //Resources.StatusAnnotations_Play_16xLG_color;
                    case EProgressState.Finished:
                        img = Resources.circle_green_16_ns; break; //Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
                    default:
                        img = null; break;
                }

                return ResizeImage(img, 8, 8);
            }
        }

        public string Duration
        {
            get
            {
                switch (State)
                {
                    case EProgressState.NotStarted:
                        return "";
                    case EProgressState.Running:
                        return (DateTime.Now - this.DateTimeStarted).ToString(@"hh\:mm\:ss");
                    case EProgressState.Finished:
                        return (this.DateTimeFinished - this.DateTimeStarted).ToString(@"hh\:mm\:ss");
                    default:
                        return null;
                }
            }
        }

        public LongRunningOperation(string operationName, double weight = -1)
        {
            this.OperationName = operationName;
            this.Weight = weight;
            this.State = EProgressState.NotStarted;
            this.ProgressPercentage = 0;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }

    public enum EProgressState
    {
        NotStarted,
        Running,
        Finished
    }
}
