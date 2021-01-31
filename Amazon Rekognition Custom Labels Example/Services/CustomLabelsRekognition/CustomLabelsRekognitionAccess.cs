using System;
using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using AwsRekognitionCustomLabels.Models;

namespace AwsRekognitionCustomLabels.Services.CustomLabelsRekognition
{
    public class CustomLabelsRekognitionAccess : ICustomLabelsRekognitionAccess
    {
        private readonly RekognitionSettingsModel _rekognitionSettingsModel;
        private readonly AmazonRekognitionClient _amazonRekognitionClient;
        
        public CustomLabelsRekognitionAccess(RekognitionSettingsModel rekognitionSettingsModel)
        {
            this._rekognitionSettingsModel = rekognitionSettingsModel ?? throw new ArgumentNullException();
            this._amazonRekognitionClient = new AmazonRekognitionClient();
        }
        
        public async Task<DetectCustomLabelsResponse> GetDetectionCustomLabelsResponseAsync(DetectCustomLabelsRequest customLabelsRequest)
        {
            if(customLabelsRequest == null)
                throw new ArgumentNullException();

            return await _amazonRekognitionClient.DetectCustomLabelsAsync(customLabelsRequest);
        }

        public DetectCustomLabelsRequest CreateDetectCustomLabelsRequest(Image image)
        {
            if(image == null)
                throw new ArgumentNullException();
            
            return new DetectCustomLabelsRequest()
            {
                Image = image,
                ProjectVersionArn = _rekognitionSettingsModel.ProjectNameArn,
                MinConfidence = 0,
                MaxResults = 100
            };        
        }
    }
}