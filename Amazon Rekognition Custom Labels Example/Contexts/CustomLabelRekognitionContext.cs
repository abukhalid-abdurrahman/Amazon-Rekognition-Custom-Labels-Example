using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using AwsRekognitionCustomLabels.Models;

namespace Amazon_Rekognition_Custom_Labels_Example.Contexts
{
    public class CustomLabelsRekognitionContext
    {
        private RekognitionSettingsModel _rekognitionSettingsModel;
        private AmazonRekognitionClient _rekognitionClient;

        public CustomLabelsRekognitionContext(RekognitionSettingsModel rekognitionSettingsModel)
        {
            this._rekognitionSettingsModel = rekognitionSettingsModel;
            this._rekognitionClient = new AmazonRekognitionClient();
        }
        
        private DetectCustomLabelsRequest CreateCustomLabelsRequest(Image image)
        {
            return new DetectCustomLabelsRequest()
            {
                Image = image,
                ProjectVersionArn = _rekognitionSettingsModel.ProjectNameArn,
                MinConfidence = 0,
                MaxResults = 100
            };
        }

        public async Task<DetectCustomLabelsResponse> GetCustomDetectLabelsResponse(Image image)
        {
            var request = CreateCustomLabelsRequest(image);
            return await _rekognitionClient.DetectCustomLabelsAsync(request);
        }

        public async Task<StopProjectVersionResponse> StopProject()
        {
            return await _rekognitionClient.StopProjectVersionAsync(new StopProjectVersionRequest()
                { ProjectVersionArn = _rekognitionSettingsModel.ProjectNameArn });
        }

        public async Task<StartProjectVersionResponse> StartProject()
        {
            var request = new StartProjectVersionRequest()
            {
                ProjectVersionArn = _rekognitionSettingsModel.ProjectNameArn,
                MinInferenceUnits = 1
            };

            return await _rekognitionClient.StartProjectVersionAsync(request);
        }
    }
}