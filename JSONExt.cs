using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
    public class JSONExt
    {
     public static JsonSerializer jzzonform911911 = new JsonSerializer();

    public static string Serialize(object myobj)
    {
        StringWriter ss = new StringWriter();
            using (JsonWriter wrt96 = new JsonTextWriter(ss))
            {
                jzzonform911911.Serialize(wrt96, myobj);
            }
        return ss.ToString();
    }

    public static object Deserialize(string mystr)
    {
        StringReader ss = new StringReader(mystr);
        object mbobj;
        using (JsonReader wrt96 = new JsonTextReader(ss))
        {
            mbobj = jzzonform911911.Deserialize(wrt96);
        }
        return mbobj;
    }
    }