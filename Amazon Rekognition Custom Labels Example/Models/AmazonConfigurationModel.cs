using Amazon;

namespace AwsRekognitionCustomLabels.Models
{
    public class AmazonConfigurationModel
    {
        public string ProfileName { get; set; }
        public RegionEndpoint RegionEndpoint { get; set; }
    }
}