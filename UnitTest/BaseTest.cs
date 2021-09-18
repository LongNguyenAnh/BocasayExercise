using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace BocasayExe.Test
{
    public class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            if(!CheckForSkipSetup())
            {
                string storedFile = Path.Combine(Directory.GetCurrentDirectory(), Constant.JSON_FILE);
                try
                {
                    if (File.Exists(storedFile))
                    {
                        File.Delete(storedFile);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private static bool CheckForSkipSetup()
        {
            bool skipSetup = false;
            var categoryKeys = TestContext.CurrentContext.Test.Properties.Keys.ToList();

            if (categoryKeys != null && categoryKeys.Any(s => s.Contains(Constant.CATEGORY)))
            {
                skipSetup = TestContext.CurrentContext.Test.Properties.Get(Constant.CATEGORY).Equals(Constant.SKIP_SETUP);
            }
            
            return skipSetup;
        }
    }
}
