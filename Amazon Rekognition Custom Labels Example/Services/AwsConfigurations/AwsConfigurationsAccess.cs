using System;
using Amazon.Runtime.CredentialManagement;
using AwsRekognitionCustomLabels.Models;

namespace AwsRekognitionCustomLabels.Services.AwsConfigurations
{
    public class AwsConfigurationsAccess : IAwsConfigurationsAccess
    {
        public void SetRegion(AmazonConfigurationModel configurationModel)
        {
            if(configurationModel == null)
                throw new ArgumentNullException();
            
            var sharedFile = new SharedCredentialsFile();
            if (sharedFile.TryGetProfile(configurationModel.ProfileName, out CredentialProfile profile))
            {
                profile.Region = configurationModel.RegionEndpoint;
                sharedFile.RegisterProfile(profile);
            }        
        }

        public void SetCredential(AmazonCredentialsModel credentialsModel)
        {
            if(credentialsModel == null)
                throw new ArgumentNullException();
            
            var option = new CredentialProfileOptions()
            {
                AccessKey = credentialsModel.KeyId,
                SecretKey = credentialsModel.Secret
            };
            
            var profile = new CredentialProfile(credentialsModel.ProfileName, option);
            var sharedFile = new SharedCredentialsFile();
            sharedFile.RegisterProfile(profile);
        }
    }
}