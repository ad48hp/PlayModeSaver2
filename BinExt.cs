using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public static class BinExt
{

    public static BinaryFormatter binform911911 = new BinaryFormatter();

    public static string Serialize(object myobj)
    {
        string bw96;
       using (MemoryStream ms = new MemoryStream())
        {
            binform911911.Serialize(ms, myobj);
            StreamReader reader = new StreamReader(ms, Encoding.ASCII);
            bw96 = reader.ReadToEnd();
        }
        return bw96;
    }

    public static object Deserialize(string mystr)
    {
        byte[] ba = Encoding.ASCII.GetBytes(mystr);
        MemoryStream st = new MemoryStream(ba);
        return binform911911.Deserialize(st);
    }
}