using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoint : MonoBehaviour
{
    [SerializeField] CarTrackDataLogger carTrackDataLogger;
    [SerializeField] int checkpointIndex;

    private void Start()
    {
        GameObject gameobject = GameObject.FindGameObjectWithTag("Player");
        carTrackDataLogger = gameobject.GetComponent<CarTrackDataLogger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarCollider"))
        {
            if (checkpointIndex == 0)
            {
                // Check if ALL checkpoints are true
                bool allCheckpointsPassed = true;

                for (int i = 0; i < carTrackDataLogger.checkpointChecker.Length; i++)
                {
                    if (carTrackDataLogger.checkpointChecker[i] == false)
                    {
                        allCheckpointsPassed = false;
                        break;
                    }
                }

                // If all were true → submit lap
                if (allCheckpointsPassed)
                {
                    carTrackDataLogger.SubmitLapTime();

                    // Reset all checkpoints
                    for (int i = 0; i < carTrackDataLogger.checkpointChecker.Length; i++)
                    {
                        carTrackDataLogger.checkpointChecker[i] = false;
                    }
                }

                // Start new lap by marking checkpoint 0
                carTrackDataLogger.checkpointChecker[0] = true;
            }
            else
            {
                // Just mark this checkpoint as passed
                carTrackDataLogger.checkpointChecker[checkpointIndex] = true;
            }

            Debug.Log("Car reached checkpoint: " + gameObject.name);
        }
    }

}
