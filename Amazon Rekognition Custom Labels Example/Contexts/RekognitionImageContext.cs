using System.IO;
using Amazon.Rekognition.Model;

namespace Amazon_Rekognition_Custom_Labels_Example.Contexts
{
    public static class RekognitionImageContext
    {
        public static Image GetImage(string localPath)
        {
            using var fileStream = new FileStream(localPath, FileMode.Open, FileAccess.Read);
            var data = new byte[fileStream.Length];
            fileStream.Read(data, 0, (int)fileStream.Length);
            return new Image()
            {
                Bytes = new MemoryStream(data)
            };
        }
    }
}