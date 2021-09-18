using NUnit.Framework;
using Services.Models;
using Services.Services;
using Services.Common;
using System.Threading.Tasks;
using System.IO;
using System;

namespace BocasayExe.Test
{
    public class SampleServiceTests : BaseTest
    {
        [Test, Order(1)]
        public async Task SampleService_Post_ShouldAddDataSuccessfully()
        {
            SampleModel mockData = new SampleModel { FirstName = "Bocasay", LastName = "Exercise" };
            SampleService sampleService = new SampleService();
            var result = await sampleService.SaveDataAsync(mockData);
            Assert.AreEqual(result.Result, ResultStatus.SUCCESS);
        }

        [Test, Order(2)]
        [Category(Constant.SKIP_SETUP)]
        public async Task SampleService_Post_ShouldReturnDataExist()
        {
            SampleModel mockData = new SampleModel { FirstName = "Bocasay", LastName = "Exercise" };
            SampleService sampleService = new SampleService();
            var result = await sampleService.SaveDataAsync(mockData);
            Assert.AreEqual(result.Result, ResultStatus.ERROR);
            Assert.AreEqual(result.Message, Services.Common.Constant.DATA_EXIST_MESSAGE);
        }
    }
}