using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//Special thanks to Brackeys for demonstrating this new system! - Original source: https://youtu.be/XOjd_qU2Ido
public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);
        Debug.Log(Application.persistentDataPath);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveSettings(PlayerConfig config)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/settings.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        UserSettings userData = new UserSettings(config);
        //Debug.Log(Application.persistentDataPath);

        formatter.Serialize(stream, userData);
        stream.Close();   
    }

    

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
