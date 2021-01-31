using Amazon.Runtime.CredentialManagement;

namespace Amazon_Rekognition_Custom_Labels_Example.Contexts
{
    public class CredentialsContext
    {
        public void SetCredentials(Models.AmazonCredentialsModel credentialsModel)
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