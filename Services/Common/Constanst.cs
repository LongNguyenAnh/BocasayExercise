namespace Services.Common
{
    public static class Constant
    {
        public const string JSON_SAMPLE = @"./StoredFile/sample.json";
        public const string DATA_EXIST_MESSAGE = "Data already exist.";
    }

    public struct ResultStatus
    {
        public const string SUCCESS = "success";
        public const string ERROR = "error";
    }
}
