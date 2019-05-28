using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Must use System.IO and System.runtime.serialization.formatters.binary
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveInventory  {

    public static void SaveData(InventoryManager inventory)
    {
        // Create new binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        // Create path to save to
        string path = Application.persistentDataPath + "/inventoryData.file";
        FileStream stream = new FileStream(path, FileMode.Create);
        InventoryData data = new InventoryData(inventory);
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static InventoryData LoadData()
    {
        string path = Application.persistentDataPath + "/inventoryData.file";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            InventoryData data = formatter.Deserialize(stream) as InventoryData;
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
