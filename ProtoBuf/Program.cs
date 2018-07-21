using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Google.Protobuf;
using ProtoBuf;

namespace ProtoBuf
{
    class Program
    {
        static void Main(string[] args)
        {
            HowDoesWorkProtoBuf objOfClassHowDoesWorkProtoBuf = new HowDoesWorkProtoBuf();
            objOfClassHowDoesWorkProtoBuf.Author = "Dostoevski";
            objOfClassHowDoesWorkProtoBuf.Name = "Idiot";
            objOfClassHowDoesWorkProtoBuf.PageCount = 653;
            byte[] tempByte = Serialization(objOfClassHowDoesWorkProtoBuf);

            //I don't have ideas how to convert byte array to class - BIG problem, which I can't solve...
            //HowDoesWorkProtoBuf ReconstructedObj = (HowDoesWorkProtoBuf)Serialization(tempByte);
        }
        
        public static byte[] Serialization(object ObjToSerialize)
        {
            if (ObjToSerialize == null)
                return null;
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    Serializer.Serialize(stream, ObjToSerialize);
                    return stream.ToArray();
                }
            }
            catch
            {
                throw;
            }
        }
        public static object ProtoBufSerialization(byte[] data)
        {
            if (data == null)
                return null;
            try
            {
                using (MemoryStream stream = new MemoryStream(data))
                {
                    return Serializer.Deserialize(typeof(HowDoesWorkProtoBuf), stream);
                }
            }
            catch
            {
                throw;
            }
        }
    }
    [ProtoContract]
    public class HowDoesWorkProtoBuf
    {
        [ProtoMember(1)]
        public string Author { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public int PageCount { get; set; }
    }

}