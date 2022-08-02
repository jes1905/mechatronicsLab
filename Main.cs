using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.JsonSerialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[Serializable]
public class Main : MonoBehaviour
{

    public static List<string> data = new List<string>();
    public static string text;
    public TMPro.TMP_Dropdown myDrop;
    public static string filePath = "data.json";

    public void OnClick()
    {
        data.Add("a");
        data.Add("b");
        data.Add("c");
        Debug.Log("finished");
        Debug.Log(string.Join("," , data));
        text = string.Join(",", data);
    }

    // makes txt file
    public void MakeTXT()
    {
        File.WriteAllTextAsync("dummy.txt" , text);

        Debug.Log(text);

    }


    //Still working on
    class DataSerializer
    {
      //Serializing function
      public void JsonSerialize(object data, string filePath)
      {
          JsonSerializer jsonSerializer = new JsonSerializer();
          if(File.Exists(filePath)) File.Delete(filePath);
          StreamWriter sw = new StreamWriter(filePath);
          JsonWriter jsonWriter = new JsonTextWriter(sw);

          jsonSerializer.Serialize(jsonWriter, data);

          jsonWriter.Close();
          sw.Close();

      }

      //Deserializes then writes
      public object JsonDeserialize(Type dataType, string filePath)
      {
        JObject obj = null;
        JsonSerializer jsonSerializer = new JsonSerializer();
        if(File.Exists(filePath))
        {
          StreamReader sr = new StreamReader(filePath);
          JsonReader jsonReader = new JsonTextReader(sr);
          obj = jsonSerializer.Deserialize(jsonReader) as JObject;
          sr.Close();
        }

        return obj.ToObject(dataType);
      }
    }

    public void MakeJSON()
    {
      DataSerializer dataSerializer = new DataSerializer();
      dataSerializer.JsonSerialize(text, filePath);
      dataSerializer.JsonDeserialize(text.GetType(), filePath);

      Debug.Log("fine");

    }

}
