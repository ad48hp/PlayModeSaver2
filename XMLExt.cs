using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

 public static class XMLExt
 {
        public static string Serialize(object myobj)
        {
            string xxxml;
            XmlSerializer zzxmlserzz = new XmlSerializer(myobj.GetType());
            using (var sw = new StringWriter())
            {
                using (XmlWriter wr = XmlWriter.Create(sw))
                {
                    zzxmlserzz.Serialize(wr, myobj);
                    xxxml = sw.ToString();
                }
            }
            return xxxml;
        }
        public static object Deserialize(Type mytype,string mystr)
        {
            object xxxobj;
            XmlSerializer zzxmlserzz = new XmlSerializer(mytype);
            using (var sr = new StringReader(mystr))
            {
                using (XmlReader rdd911911 = XmlReader.Create(sr))
                {
                    xxxobj = zzxmlserzz.Deserialize(sr);
                 }
            }
            return xxxobj;
        }
 }