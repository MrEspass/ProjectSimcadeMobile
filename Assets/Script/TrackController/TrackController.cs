using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    public Transform[] pitStopTransform;
    public Collider[] checkpointTransform;
    public TrackCheckpoint[] trackCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        trackCheckpoint = new TrackCheckpoint[checkpointTransform.Length];
        for (int i = 0; i < checkpointTransform.Length; i++) 
        {
            trackCheckpoint[i] = checkpointTransform[i].gameObject.GetComponent<TrackCheckpoint>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
