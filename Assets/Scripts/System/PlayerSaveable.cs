using Lowscope.Saving;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerSaveable : MonoBehaviour, ISaveable
{

    public Player savedPlayer;
    public InputSystem_PlayerCombatController savedCombatController;
    public float lastHealth;
    public Vector3 lastPosition;
    //This may not be necessary as we move forward
    public Scene lastScene;
    public PlayerWeapon[] playerWeapons;


    [Serializable]
    public struct PlayerSaveData
    {
        public Player myPlayer;
        public InputSystem_PlayerCombatController combatController;
        public float myHealth;
        public Vector3 myPosition;
        //This may not be necessary as we move forward
        public Scene myScene;
        public PlayerWeapon[] myWeapons;
    }

    [SerializeField]
    private PlayerSaveData stats;

    // Gets synced from the SaveMaster
    public void OnLoad(string data)
    {
        var pos = JsonUtility.FromJson<PlayerSaveData>(data).myPosition;
        transform.position = pos;
        lastPosition = pos;
        // var player = JsonUtility.FromJson<PlayerSaveData>(data).myPlayer;
        // savedPlayer = player;
        var health = JsonUtility.FromJson<PlayerSaveData>(data).myHealth;
        var scene = JsonUtility.FromJson<PlayerSaveData>(data).myScene;
        lastScene = scene;
        SceneManager.LoadScene(lastScene.name);
        // if (savedPlayer != null)
        // {
        //     savedPlayer.PlayerStats.MaxHealth = health;
        // }
        // var combat = JsonUtility.FromJson<PlayerSaveData>(data).combatController;
        // savedCombatController = combat;
        // playerWeapons[0] = savedCombatController.Weapons[0].GetComponent<PlayerWeapon>();
        // playerWeapons[1] = savedCombatController.Weapons[1].GetComponent<PlayerWeapon>();
        // playerWeapons[2] = savedCombatController.Weapons[2].GetComponent<PlayerWeapon>();

    }

    // Send data to the Saveable component, then into the SaveGame (On request of the save master)
    // On autosave or when SaveMaster.WriteActiveSaveToDisk() is called
    public string OnSave()
    {
        lastPosition = transform.position;
        savedPlayer = GetComponent<Player>();
        savedCombatController = savedPlayer.GetComponentInChildren<InputSystem_PlayerCombatController>();
        // playerWeapons[0] = savedCombatController.Weapons[0].GetComponent<PlayerWeapon>();
        // // playerWeapons[1] = savedCombatController.Weapons[1].GetComponent<PlayerWeapon>();
        // playerWeapons[2] = savedCombatController.Weapons[2].GetComponent<PlayerWeapon>();
        lastHealth = savedPlayer.PlayerStats.MaxHealth;
        lastScene = SceneManager.GetActiveScene();
        return JsonUtility.ToJson(new PlayerSaveData { myPosition = lastPosition, myPlayer = savedPlayer, myHealth = lastHealth, myScene = lastScene, myWeapons = playerWeapons });
    }

    // In case we don't want to do the save process.
    // We can decide within the script if it is dirty or not, for performance.
    public bool OnSaveCondition()
    {
        return lastPosition != transform.position;
    }

}