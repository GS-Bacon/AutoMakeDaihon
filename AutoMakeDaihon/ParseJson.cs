using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace AutoMakeDaihon
{
    public class ParseJson
    {
        string Json;
        public ParseJson(string json) 
        {
            this.Json= json;
        }
        public JObject parse()
        {
            return JObject.Parse(Json);
        }

    }


}
