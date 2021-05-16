using Newtonsoft.Json;

namespace Vizitz.Models.Exception
{
    public class Error
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
