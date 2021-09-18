using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Services.Common;
using System.Linq;

namespace Services.Services
{
    public class SampleService : ISampleService
    {
        public async Task<ResponseModel> SaveDataAsync(SampleModel model)
        {
            try
            {
                List<SampleModel> sampleList = new List<SampleModel>();
                if (File.Exists(Constant.JSON_SAMPLE))
                {
                    var jsonString = await File.ReadAllTextAsync(Constant.JSON_SAMPLE);
                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        sampleList = JsonConvert.DeserializeObject<List<SampleModel>>(jsonString);
                    }
                }

                if (sampleList.Any() && sampleList.Exists(s => s.FirstName.Equals(model.FirstName, StringComparison.OrdinalIgnoreCase) && s.LastName.Equals(model.LastName, StringComparison.OrdinalIgnoreCase)))
                { return new ResponseModel { Result = ResultStatus.ERROR, Message = Constant.DATA_EXIST_MESSAGE }; }

                sampleList.Add(model);

                var updatedResult = JsonConvert.SerializeObject(sampleList);
                await File.WriteAllTextAsync(Constant.JSON_SAMPLE, updatedResult);
                return new ResponseModel { Result = ResultStatus.SUCCESS, Data = updatedResult };
            }
            catch(Exception e)
            {
                return new ResponseModel { Result = ResultStatus.ERROR, Message = e.Message };
            }
        }
    }
}
