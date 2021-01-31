using AwsRekognitionCustomLabels.Models;

namespace AwsRekognitionCustomLabels.Services.AwsConfigurations
{
    public interface IAwsConfigurationsAccess
    {
        void SetRegion(AmazonConfigurationModel configurationModel);
        void SetCredential(Models.AmazonCredentialsModel credentialsModel);
    }
}