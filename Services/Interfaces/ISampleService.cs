using Services.Models;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISampleService
    {
        Task<ResponseModel> SaveDataAsync(SampleModel model);
    }
}
