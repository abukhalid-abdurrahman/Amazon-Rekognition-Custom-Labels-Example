using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon_Rekognition_Custom_Labels_Example.Contexts
{
    public class RekognitionContext
    {
        
        private DetectCustomLabelsRequest CreateCustomLabelsRequest(Image image)
        {
            return new DetectCustomLabelsRequest()
            {
                Image = image,
                MaxResults = 100,
                ProjectVersionArn = 
                MinConfidence = 75F
            };
        }

        public async Task<DetectLabelsResponse> GetCustomDetectLabelsResponse(Image image)
        {
            var rekognitionClient = new AmazonRekognitionClient();
            var request = CreateCustomLabelsRequest(image);
            return await rekognitionClient.DetectLabelsAsync(request);
        }
    }
}