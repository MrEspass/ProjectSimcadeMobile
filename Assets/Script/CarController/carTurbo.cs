using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carTurbo : MonoBehaviour
{
    carEngine engine;
    CarController car;

    public bool isEnable;
    public float torqueBoostMultiplier; //max boost at 1
    public float maxTurboCapasity; //for simulating how much liters of air can going through the engine
    public float minTurboCapasity; //for simulating how much liters of air can going through the engine
    public float spoolingSpeedMultiplier;

    public AudioSource turboWhine;
    public AudioSource turboBlowOff;

    [HideInInspector] public float currentTurboCapasity;
    [HideInInspector] public float torqueBoost;
    [HideInInspector] public float rawEngineTorque;

    [HideInInspector] private float pitch;
    [HideInInspector] private float pitchMemory;

    // Start is called before the first frame update
    void Start()
    {
        engine = GetComponentInParent<carEngine>();
        car = GetComponentInParent<CarController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        turboSoundManager();
    }

    public float forcedInductionCalculator(float throttle, float engineRPM, float maxRPM) 
    {
        if(isEnable == true) 
        {
            float carSpeed = car.carRigidbody.velocity.magnitude * 3.6f; // in KMH/H, for simulating wind
            float spoolingSpeed = (1f + (carSpeed / 100f) * spoolingSpeedMultiplier) / maxTurboCapasity;
            float spoolingLoss = 0.25f * (engineRPM / maxRPM);

            currentTurboCapasity = Mathf.Lerp(currentTurboCapasity, (maxTurboCapasity - spoolingLoss) * (throttle - (1f - throttle)), Time.deltaTime * spoolingSpeed);
            currentTurboCapasity = Mathf.Clamp(currentTurboCapasity, (-minTurboCapasity + spoolingLoss) * (1f - throttle), (maxTurboCapasity - spoolingLoss) * throttle);
            //rawEngineTorque = engine.torqueGraph.Evaluate(engineRPM) * 1f;
            rawEngineTorque = engine.engineTorqueTotal;
            torqueBoost = torqueBoostMultiplier * Mathf.Abs(currentTurboCapasity) * rawEngineTorque;
        }
        else 
        {
            torqueBoost = 0f;
        }
        
        return torqueBoost;
    }

    public float turboCapasity() 
    {
        return currentTurboCapasity;
    }

    void turboSoundManager() 
    {
        pitch = Mathf.Clamp01(currentTurboCapasity / maxTurboCapasity);
        bool blowOff = false;
        turboWhine.volume = pitch * 0.1f;
        //turboBlowOff.pitch = pitch;
        pitchMemory = pitch;
        if (pitch < pitchMemory && pitch > 0f) 
        {
            blowOff = true;
        }
        if (blowOff) 
        {
            turboBlowOff.Play();
            blowOff = false;
        }
    }
}
