
using System;
using System.IO;
using System.Numerics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

class JsonParser : MonoBehaviour
{
    public static long dc_clientkey;
    public JToken ParseDC(){
    using (StreamReader file = File.OpenText(Directory.GetCurrentDirectory()+ "\\Assets\\secrets.json"))
    using (JsonTextReader reader = new JsonTextReader(file))
    {
        JObject o2 = (JObject)JToken.ReadFrom(reader);
        return o2.GetValue("dc_clientId");
    }
    }

    private void Start()
    {
        dc_clientkey = Int64.Parse(ParseDC().ToString());
    }
}