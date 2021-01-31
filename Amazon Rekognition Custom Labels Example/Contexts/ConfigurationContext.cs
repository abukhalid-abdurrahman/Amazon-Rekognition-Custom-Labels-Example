using Amazon.Runtime.CredentialManagement;
using AwsRekognitionCustomLabels.Models;

namespace AwsRekognitionCustomLabels.Contexts
{
    public class ConfigurationContext
    {
        public void AddRegion(AmazonConfigurationModel configurationModel)
        {
            var sharedFile = new SharedCredentialsFile();
            CredentialProfile profile;
            if (sharedFile.TryGetProfile(configurationModel.ProfileName, out profile))
            {
                profile.Region = configurationModel.RegionEndpoint;
                sharedFile.RegisterProfile(profile);
            }
        }
    }
}