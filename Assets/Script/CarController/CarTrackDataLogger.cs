using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class CarTrackDataLogger : MonoBehaviour
{
    public TrackController trackController;
    public MeshCollider carCollider;
    public int Lap;
    public double sessionTimer;
    public double lapTimer;
    public double lapBestTime;
    public List<double> lapTimeRecord = new List<double>();
    public double[] checkpointTimeRecord;
    public Collider[] checkpointTransform;
    public bool[] checkpointChecker;

    public string lapTimerString;
    public string lapBestTimeString;
    public string[] lapTimeRecordString;
    public string[] checkpointTimeRecordString;
    // Start is called before the first frame update
    void Start()
    {
        GameObject _trackController = GameObject.FindGameObjectWithTag("RaceTrack");
        GameObject carColliderMesh = GameObject.Find("Collider");
        trackController = _trackController.GetComponent<TrackController>();
        carCollider = carColliderMesh.GetComponent<MeshCollider>();

        checkpointChecker = new bool[trackController.checkpointTransform.Length];
        checkpointTransform = new Collider[trackController.checkpointTransform.Length];
        for (int i = 0; i < trackController.checkpointTransform.Length; i++)
        {
            checkpointTransform[i] = trackController.checkpointTransform[i];
        }

        Lap = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GenTimeSpanFromSeconds(lapTimer);
        PrintBestLapTime();
    }

    private void Update()
    {
        LapTimerCounter();
    }

    void GenTimeSpanFromSeconds(double seconds) 
    {
        TimeSpan _interval = TimeSpan.FromSeconds(seconds);
        string interval = string.Format("{0:00}:{1:00}:{2:000}", _interval.Minutes, _interval.Seconds, _interval.Milliseconds);
        lapTimerString = interval;
    }

    void LapTimerCounter() 
    {
        if (checkpointChecker[0]) 
        {
            lapTimer += Time.deltaTime;
        }
        else 
        {
            lapTimer = 0f;
        }
    }

    public void SubmitLapTime() 
    {
        lapTimeRecord.Add(lapTimer);
        lapTimeRecord.Remove(0);
        lapTimer = 0f;
        Lap += 1;

        lapTimeRecordString = new string[lapTimeRecord.Count];
        for(int i = 0; i < lapTimeRecord.Count; i++) 
        {
            TimeSpan _interval = TimeSpan.FromSeconds(lapTimeRecord[i]);
            string interval = string.Format("{0:00}:{1:00}:{2:000}", _interval.Minutes, _interval.Seconds, _interval.Milliseconds);
            lapTimeRecordString[i] = interval;
        }
    }

    public void PrintBestLapTime() 
    {
        if (lapTimeRecord.Count != 0) 
        {
            lapBestTime = lapTimeRecord.Min();
            TimeSpan _interval = TimeSpan.FromSeconds(lapBestTime);
            string interval = string.Format("{0:00}:{1:00}:{2:000}", _interval.Minutes, _interval.Seconds, _interval.Milliseconds);
            lapBestTimeString = interval;
        }
    }
}
