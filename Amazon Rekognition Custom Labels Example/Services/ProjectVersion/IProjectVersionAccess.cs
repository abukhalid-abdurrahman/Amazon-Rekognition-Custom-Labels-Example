using System.Threading.Tasks;
using Amazon.Rekognition.Model;

namespace AwsRekognitionCustomLabels.Services.ProjectVersion
{
    public interface IProjectVersion
    {
        Task<StartProjectVersionResponse> StartProjectAsync();
        Task<StopProjectVersionResponse> StopProjectAsync();
    }
}