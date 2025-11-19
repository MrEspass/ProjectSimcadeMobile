using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carEngine : MonoBehaviour
{
    carTurbo turbo;

    [Header("Engine Data")]
    public AnimationCurve torqueGraph; // using torque graph instead of power graph for easier implementing motorTorque to WheelCollider
    public float torqueFriction;
    public float engineInertiaSpeed;
    public float maxRPM;
    public float minRPM;
    public float redlineRPM;
    public float RPMHudLimit;
    public float torqueValue;

    [Header("Engine Sound")]
    public AudioSource[] engineOn;
    public AudioSource[] engineOff;
    public AnimationCurve[] Crossover;
    public float[] CrossoverPoint;
    public float engineVolume;

    [HideInInspector] public float engineTorque;
    [HideInInspector] public float engineTorqueFriction;
    [HideInInspector] public float engineTorqueTotal;
    [HideInInspector] public float currentTuboCapasity;
    [HideInInspector] public float forceInductionTorque = 0f;
    [HideInInspector] public bool isUseTurbo = false;

    private float throttleLerp = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turbo = GetComponentInChildren<carTurbo>();
        if (turbo != null)
        {
            currentTuboCapasity = turbo.turboCapasity();
            isUseTurbo = true;
        }
        else
        {
            isUseTurbo = false;
        }
        crossoverPointCalculator();
    }

    public void volumeControl(float rpm, float throttle) 
    {
        throttleLerp = Mathf.Lerp(throttleLerp, throttle, Time.deltaTime * 5f);
        for (int i = 0; i < Crossover.Length; i++) 
        {
            float volumeFactor = 0.25f + (0.75f * (rpm / maxRPM));
            float volume = Crossover[i].Evaluate(rpm) * volumeFactor;
            engineOn[i].volume = volume * throttleLerp * engineVolume;
            engineOff[i].volume = volume * (1f- throttleLerp) * engineVolume;

            float pitchTarget = (rpm / CrossoverPoint[i]);
            engineOn[i].pitch = pitchTarget;
            engineOff[i].pitch = pitchTarget;
        }
    }

    void crossoverPointCalculator() 
    {
        Crossover = new AnimationCurve[4];

        // Helper to make a linear curve
        AnimationCurve MakeLinear(params Keyframe[] keys)
        {
            var curve = new AnimationCurve(keys);
            for (int i = 1; i < curve.length; i++)
            {
                var prev = curve[i - 1];
                var curr = curve[i];
                float slope = (curr.value - prev.value) / (curr.time - prev.time);
                prev.outTangent = slope;
                curr.inTangent = slope;
                curve.MoveKey(i - 1, prev);
                curve.MoveKey(i, curr);
            }
            return curve;
        }

        Crossover[0] = MakeLinear(
            new Keyframe(0f, 1f),
            new Keyframe(CrossoverPoint[0] - 500f, 1f),
            new Keyframe(CrossoverPoint[0] + 500f, 0f)
        );

        Crossover[1] = MakeLinear(
            new Keyframe(CrossoverPoint[0] - 500f, 0f),
            new Keyframe(CrossoverPoint[0] + 500f, 1f),
            new Keyframe(CrossoverPoint[1] - 500f, 1f),
            new Keyframe(CrossoverPoint[1] + 500f, 0f)
        );

        Crossover[2] = MakeLinear(
            new Keyframe(CrossoverPoint[1] - 500f, 0f),
            new Keyframe(CrossoverPoint[1] + 500f, 1f),
            new Keyframe(CrossoverPoint[2] - 500f, 1f),
            new Keyframe(CrossoverPoint[2] + 500f, 0f)
        );

        Crossover[3] = MakeLinear(
            new Keyframe(CrossoverPoint[2] - 500f, 0f),
            new Keyframe(CrossoverPoint[2] + 500f, 1f)
        );
    }

    public float torqueCalculator(float throttle, float engineRPM) 
    {
        float _throttle = 0f;
        if (engineRPM > maxRPM)
        {
            _throttle = 0f;
        }
        else if (engineRPM < minRPM)
        {
            _throttle = 0.25f + throttle;
        }
        else 
        {
            _throttle = throttle;
        }
        engineTorque = torqueGraph.Evaluate(engineRPM) * _throttle;
        engineTorqueFriction = torqueGraph.Evaluate(engineRPM) * (1f-_throttle) * -torqueFriction;
        engineTorqueTotal = engineTorque + engineTorqueFriction;
        
        if (isUseTurbo) 
        {
            forceInductionTorque = turbo.forcedInductionCalculator(throttle, engineRPM, maxRPM);
        }
        else 
        {
            forceInductionTorque = 0f;
        }

        float _engineTorqueTotal = engineTorqueTotal + forceInductionTorque;
        return _engineTorqueTotal;
    }
}
