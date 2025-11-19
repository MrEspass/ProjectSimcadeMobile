using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class raceLoader : MonoBehaviour
{
    public int startPosition = 1;
    public Transform sunLight;
    public bool loadingComplete;
    [SerializeField] CarData carData;
    [SerializeField] string carDataName;
    [SerializeField] TrackData trackData;
    [SerializeField] string trackDataName;

    // Start is called before the first frame update
    void Start()
    {
        loadingComplete = false;
        loadDataAssetA();
        resetPlayerPrefs(); //avoid anomalies
    }

    void loadDataAssetA()
    {
        trackDataName = PlayerPrefs.GetString("trackDataName");
        trackData = Resources.Load<TrackData>("Tracks/TrackData/" + trackDataName);
        Vector3 trackPos = Vector3.zero;
        Quaternion trackRot = Quaternion.identity;
        GameObject trackObject = Instantiate(trackData.trackPrefab, trackPos, trackRot);
        TrackController trackController = trackObject.GetComponent<TrackController>();
        sunLight.transform.eulerAngles = trackData.sunRotation;

        //load Car
        carDataName = PlayerPrefs.GetString("carDataName");
        carData = Resources.Load<CarData>("Cars/CarData/" + carDataName);

        Vector3 carPos = trackController.pitStopTransform[startPosition - 1].transform.position;
        Quaternion carRot = trackController.pitStopTransform[startPosition - 1].transform.rotation;
        //Quaternion carRot = Quaternion.identity;
        GameObject carObject = Instantiate(carData.carPrefab, carPos, carRot);
        CarController carController = carObject.GetComponent<CarController>();
        carController.isPlayer = true;
        carController.isStatic = false;

        loadingComplete = true;
    }


    void resetPlayerPrefs()
    {
        PlayerPrefs.SetString("trackDataName", "");
        PlayerPrefs.SetString("carDataName", "");
    }

    // Update is called once per frame
    void Update()
    {
        if (loadingComplete)
        {
            
        }
        else
        {
            
        }
    }
}
