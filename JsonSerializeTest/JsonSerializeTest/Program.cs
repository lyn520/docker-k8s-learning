using Newtonsoft.Json;

namespace JsonSerializeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str = JsonConvert.SerializeObject(new { VideoRecordArg = @"StartFromMVTM", CameraWindowTop = 100, CameraWindowLeft = 100 });
            Console.WriteLine(str);
            var o = JsonConvert.DeserializeObject<dynamic>(str);
            Console.WriteLine(o.VideoRecordArg);
            Console.WriteLine(o.CameraWindowTop);
            Console.WriteLine(o.CameraWindowLeft);
            Console.ReadKey();
        }
    }
}