using System.Threading.Tasks;
using Amazon.Rekognition.Model;

namespace AwsRekognitionCustomLabels.Services.CustomLabelsRekognition
{
    public interface ICustomLabelsRekognitionAccess
    {
        Task<DetectCustomLabelsResponse> GetDetectionCustomLabelsResponseAsync(DetectCustomLabelsRequest customLabelsRequest);
        DetectCustomLabelsRequest CreateDetectCustomLabelsRequest(Image image);
    }
}