using Amazon.Runtime.CredentialManagement;

namespace AwsRekognitionCustomLabels.Contexts
{
    public class CredentialContext
    {
        public void SetCredential(Models.AmazonCredentialsModel credentialsModel)
        {
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