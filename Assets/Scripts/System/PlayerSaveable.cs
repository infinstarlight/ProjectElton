using Lowscope.Saving;
using System;
using UnityEngine;

public class PlayerSaveable : MonoBehaviour, ISaveable
{
    [Serializable]
    public class PlayerSaveData
    {
        public Player savedPlayer;
        public InputSystem_PlayerCombatController savedCombatController;
        public float lastHealth = 100.0f;
        public Vector3 lastPosition = new Vector3();
        //This may not be necessary as we move forward
        public string lastScene = "";
        public Weapon[] playerWeapons;

    }

    [SerializeField]
    private PlayerSaveData playerSaveData;

    // Gets synced from the SaveMaster
    public void OnLoad(string data)
    {
        playerSaveData = JsonUtility.FromJson<PlayerSaveData>(data);
    }

    // Send data to the Saveable component, then into the SaveGame (On request of the save master)
    // On autosave or when SaveMaster.WriteActiveSaveToDisk() is called
    public string OnSave()
    {
        return JsonUtility.ToJson(playerSaveData);
    }

    // In case we don't want to do the save process.
    // We can decide within the script if it is dirty or not, for performance.
    public bool OnSaveCondition()
    {
        return true;
    }
}
