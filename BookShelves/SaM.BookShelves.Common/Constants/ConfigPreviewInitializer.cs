using System.IO;

namespace SaM.BookShelves.Common.Constants
{
    public class ConfigPreviewInitializer
    {
        public static class LoaderPreview
        {
            public static byte[] Init(string path)
            {
                byte[] photoBytes;
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    photoBytes = new byte[fileStream.Length];
                    fileStream.Read(photoBytes, 0, photoBytes.Length);
                }
                return photoBytes;
            }
        }

        public static class Previews
        {
            public static readonly string Extension = ".jpg";
            public static readonly string Type = "image/jpeg";

            public static readonly string ISBN1 = "9785990980532";
            public static readonly string ISBN2 = "9785001467526";
            public static readonly string ISBN3 = "9785001461289";
            public static readonly string ISBN4 = "9785446106745";
            public static readonly string ISBN5 = "9785990980518";
            public static readonly string ISBN6 = "9785446112135";
            public static readonly string ISBN7 = "9785446109609";
            public static readonly string ISBN8 = "9785970602300";
            public static readonly string ISBN9 = "9785845916259";
            public static readonly string ISBN10 = "9785961467420";
            public static readonly string ISBN11 = "9785969304017";
        }
    }
}
