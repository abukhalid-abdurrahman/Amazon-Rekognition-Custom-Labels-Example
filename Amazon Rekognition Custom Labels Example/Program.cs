using System;
using System.Threading.Tasks;
using Amazon;
using Amazon_Rekognition_Custom_Labels_Example.Contexts;
using AwsRekognitionCustomLabels.Contexts;
using AwsRekognitionCustomLabels.Models;

namespace AwsRekognitionCustomLabels
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var credentialModel = new AmazonCredentialsModel()
            {
                Secret = "k1O7DJbIE+yXkqT65gde7saFtNDJ3VCF29CmL6BK",
                KeyId = "AKIARDJBQ37DC227BIMY",
                ProfileName = "default"
            };
            var credentialContext = new CredentialContext();
            credentialContext.SetCredential(credentialModel);

            var configModel = new AmazonConfigurationModel()
            {
                ProfileName = "default",
                RegionEndpoint = RegionEndpoint.USWest2
            };
            var configContext = new ConfigurationContext();
            configContext.AddRegion(configModel);

            string localFilePath =
                @"E:\Faridun's Projects\Faridun's\Back-End\AWS\Object Detection\Resources\45a67fe8-8713-4b1f-93ce-d005bf2d4319.jpg";
            var image = RekognitionImageContext.GetImage(localFilePath);
            var settingsModel = new RekognitionSettingsModel()
            {
                ProjectNameArn = "project_version_arn"
            };
            var rekContext = new CustomLabelsRekognitionContext(settingsModel);
            await rekContext.StartProject();
            var data = await rekContext.GetCustomDetectLabelsResponse(image);

            foreach (var label in data.CustomLabels)
            {
                Console.WriteLine($"Label Name: {label.Name}, Confidence: {label.Confidence}");
            }

            await rekContext.StopProject();
        }
    }
}
