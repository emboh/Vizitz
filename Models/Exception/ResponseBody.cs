using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Vizitz.Models.Exception
{
    public class ResponseBody
    {
        //public IList<KeyValuePair<string, string>> Errors { get; set; }

        //public KeyValuePair<string, IList<string>> Errors { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public int? Status { get; set; }

        public Guid? TraceId { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
