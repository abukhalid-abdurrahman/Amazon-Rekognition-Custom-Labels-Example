using System;
using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using AwsRekognitionCustomLabels.Models;

namespace AwsRekognitionCustomLabels.Services.ProjectVersion
{
    public class ProjectVersion : IProjectVersion
    {
        private RekognitionSettingsModel _rekognitionSettingsModel;
        private AmazonRekognitionClient _amazonRekognitionClient;
        
        public ProjectVersion(RekognitionSettingsModel rekognitionSettingsModel)
        {
            this._rekognitionSettingsModel = rekognitionSettingsModel ?? throw new ArgumentNullException();
            _amazonRekognitionClient = new AmazonRekognitionClient();
        }
        
        public async Task<StartProjectVersionResponse> StartProjectAsync()
        {
            var request = new StartProjectVersionRequest()
            {
                ProjectVersionArn = _rekognitionSettingsModel.ProjectNameArn,
                MinInferenceUnits = 1
            };

            return await _amazonRekognitionClient.StartProjectVersionAsync(request);   
        }

        public async Task<StopProjectVersionResponse> StopProjectAsync()
        {
            return await _amazonRekognitionClient.StopProjectVersionAsync(new StopProjectVersionRequest()
                { ProjectVersionArn = _rekognitionSettingsModel.ProjectNameArn });
        }
    }
}