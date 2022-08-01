using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;
using System;
using TMPro;

public class Main : MonoBehaviour
{

    public static List<string> data = new List<string>();
    public static string text;
    public TMPro.TMP_Dropdown myDrop;

    public void OnClick()
    {
        data.Add("a");
        data.Add("b");
        data.Add("c");
        data.Add("d");
        data.Add("e");
        Debug.Log("finished");
        Debug.Log(string.Join("," , data));
        text = string.Join(",", data);
    }
    
    public void MakeTXT()
    { 
        //Debug.Log(string.Join(",", data));
        //Debug.Log("done");

        File.WriteAllTextAsync("dummy.txt" , text);

        Debug.Log(text);
        //string test = "dummy";

        //File.WriteAllTextAsync("dummy2.txt", test );
       //Debug.Log("complete");
    }

    public void MakeJSON()
    {
        string output = JsonUtility.ToJson(text);

        File.WriteAllTextAsync(Application.dataPath)
    }

    // get to later
   /* public void DropDown()
    {
        if(myDrop.value == 1)
        {
            MakeTXT();
        }
        

    }
    */
}