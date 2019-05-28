using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Must use System.IO and System.runtime.serialization.formatters.binary
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame  {

    public static void SaveData(Player player)
    {
        // Create new binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        // Create path to save to
        string path = Application.persistentDataPath + "/newsave.file";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData(player);
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/newsave.file";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            
            return data;

        }
        else
        {
            Debug.LogError("No file found at path " + path);
            return null;
        }
    }

}
