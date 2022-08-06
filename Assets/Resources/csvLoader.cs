using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

public class csvLoader
{
    //Reference File
    private TextAsset csvFile;
    private char lineSeparator = '\n';
    private char surround = '"';
    private string[] fieldSeparator = { "\",\"" };

    public void loadCSV()
    {
        csvFile = Resources.Load<TextAsset>("Localisation");
    }

    public Dictionary<string, string> GetDictionaryValues(int attributedID)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            var splitStr = line.Split(',');
            if (!dictionary.ContainsKey(splitStr[0]))
            {
                dictionary.Add(splitStr[0], splitStr[attributedID + 1]);
            }
        }

        return dictionary;
    }

#if UNITY_EDITOR
    public void Add(string key, string value)
    {
        string appended = string.Format("\n\"{0}\",\"{1}\",\"\"", key, value);
        File.AppendAllText("Assets/Resources/Localisation.csv", appended);

        UnityEditor.AssetDatabase.Refresh();

    }

    public void Remove(string key)
    {
        string[] lines = csvFile.text.Split(lineSeparator)
;        string[] keys = new string[lines.Length];

        for(int i=0; i<lines.Length; i++)
        {
            string line = lines[i];
            keys[i] = line.Split(fieldSeparator, StringSplitOptions.None)[0];

        }

        int index = -1;

        for (int i=0; i < keys.Length; i++)
          
        {
            if (keys[i].Contains(key))
            {
                index = i;
                break;

            }
        
        }

        if(index>-1)
        {
            string[] newlines;
            newlines = lines.Where(w => w != lines[index]).ToArray();
            string replaced = string.Join(lineSeparator.ToString(), newlines);
            File.WriteAllText("Assets/Resources/localisation.csv", replaced);
        }
    }

    public void Edit(string key, string value)
    {
        Remove(key);
        Add(key, value);
    }
#endif
}
