using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public static class XMLOp
{
    public static void Serialize(object item, string path)
    {
        XmlSerializer serializer = new XmlSerializer(item.GetType());
        StreamWriter writer = new StreamWriter(path);
        serializer.Serialize(writer.BaseStream, item);
        writer.Close();
    }

    public static Building DeserializeBuilding(string path) {
        XmlSerializer serializer = new XmlSerializer(typeof(Building));
        StreamReader reader = new StreamReader(path);
        Building item = serializer.Deserialize(reader.BaseStream) as Building;
        reader.Close();
        return item;
    }

    public static Resource DeserializeResource(string path) {
        XmlSerializer serializer = new XmlSerializer(typeof(Resource));
        StreamReader reader = new StreamReader(path);
        Resource item = serializer.Deserialize(reader.BaseStream) as Resource;
        reader.Close();
        return item;
    }
}
