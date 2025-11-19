using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class savePlayerChoice : MonoBehaviour
{
    public enum option
    { 
        save,
        load
    }

    public option saveDataOption;
    public static savePlayerChoice instance { get; private set; }

    public string currentTrack;
    public string currentCar;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (saveDataOption) 
        {
            case option.save:
                //Save();
                break;
            case option.load:
                Load();
                break;
        }
    }

    public void Load() 
    {
        if (File.Exists(Application.persistentDataPath + "/playerChoice.dat")) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerChoice.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            currentCar = data.currentCar;
            currentTrack = data.currentTrack;
        }
    }

    public void Save() 
    {
        currentTrack = PlayerPrefs.GetString("trackDataName");
        currentCar = PlayerPrefs.GetString("carDataName");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerChoice.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.currentCar = currentCar;
        data.currentTrack = currentTrack;
        bf.Serialize(file, data);
        file.Close();
    }

    [Serializable]

    class PlayerData_Storage
    {
        public string currentTrack;
        public string currentCar;
    }
}
