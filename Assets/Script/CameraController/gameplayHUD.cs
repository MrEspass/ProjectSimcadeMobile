using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplayHUD : MonoBehaviour
{
    CarController carController;

    [Range(0.5f,1f)]public float HUDScale = 0.9f;
    public Canvas canvasHUD;
    public Slider rpmBarRed;
    public Slider rpmBarBlue;
    public Slider rpmLimiterRed;
    public Text gear;
    public Text speedometer;
    public GameObject rpmLimiterIndicator;
    public Slider throttle;
    public Slider brake;
    public Slider clutch;
    public Scrollbar steer;
    public Slider turboplus;
    public Slider turbominus;
    public GameObject turboHUD;
    public Text advanceTelemetry;

    // Start is called before the first frame update
    void Start()
    {
        carController = GetComponentInParent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        canvasHUD.transform.localScale = new Vector3(HUDScale, HUDScale, HUDScale);
        carTelemetry();
        pedalInput();
        carAdvanceTelemetry();
    }

    void carTelemetry() 
    {
        float engineRPM = carController.engineRPM;
        float maxRPM = carController.maxRPM;
        float redlineRPM = carController.redlineRPM;
        float RPMHudLimit = carController.RPMHudLimit;
        int currentGear = carController.currentGear - 1;
        float _currentSpeedometer = carController.carRigidbody.velocity.magnitude * 3.6f;
        int currentSpeedometer = (int)_currentSpeedometer;
        float turboCapasityPlus = Mathf.Clamp(carController.currentTurboCapasity, -2f, 2f);
        float turboCapasityMinus = Mathf.Clamp(-carController.currentTurboCapasity, -1f, 1f);
        
        rpmBarRed.maxValue = RPMHudLimit;
        rpmBarBlue.maxValue = RPMHudLimit;
        rpmLimiterRed.maxValue = RPMHudLimit;

        rpmBarRed.value = engineRPM;
        if(engineRPM <= redlineRPM) 
        {
            rpmBarBlue.value = engineRPM;
        }
        else 
        {
            rpmBarBlue.value = redlineRPM;
        }
        rpmLimiterRed.value = RPMHudLimit - redlineRPM;

        if(engineRPM >= maxRPM) 
        {
            rpmLimiterIndicator.SetActive(true);
        }
        else 
        {
            rpmLimiterIndicator.SetActive(false);
        }

        if(currentGear == 0) 
        {
            gear.text = "N";
        } else if (currentGear == -1) 
        {
            gear.text = "R";
        }
        else 
        {
            gear.text = currentGear.ToString();
        }
        speedometer.text = currentSpeedometer.ToString();

        if (carController.isUseTurbo) { turboHUD.SetActive(true); } else { turboHUD.SetActive(false); }
        turboplus.value = turboCapasityPlus;
        turbominus.value = turboCapasityMinus;
    }

    void pedalInput() 
    {
        float throttleInput = carController.throttleInput;
        float brakeInput = carController.brakeInput;
        float clutchInput = carController.clutchInput;
        float maxSteerAngle = carController.steeringAngleMax;
        float steerAngle = carController.steerAngle;
        float steerMovement = ((steerAngle / maxSteerAngle) * 0.5f);

        throttle.value = throttleInput;
        brake.value = brakeInput;
        clutch.value = clutchInput;
        steer.value = steerMovement + 0.5f;
    }

    void carAdvanceTelemetry() 
    {
        float engineRPM = carController.engineRPM;
        float engineTorque = carController.engineTorque;
        float enginePower = carController.enginePower;

        float FL = carController.WheelCollider[0].rpm;
        float FR = carController.WheelCollider[1].rpm;
        float RL = carController.WheelCollider[2].rpm;
        float RR = carController.WheelCollider[3].rpm;
        float frontWheelRPMDifference = Mathf.Abs(FL - FR);
        float rearWheelRPMDifference = Mathf.Abs(RL - RR);

        float FLForwardFriction = carController.WheelCollider[0].rpm;
        float FRForwardFriction = carController.WheelCollider[1].rpm;
        float RLForwardFriction = carController.WheelCollider[2].rpm;
        float RRForwardFriction = carController.WheelCollider[3].rpm;

        WheelHit FLhit;
        float FLForce = 0f;
        if(carController.WheelCollider[0].GetGroundHit(out FLhit)) 
        {
            FLForce = FLhit.force;
        }
        WheelHit FRhit;
        float FRForce = 0f;
        if (carController.WheelCollider[1].GetGroundHit(out FRhit))
        {
            FRForce = FRhit.force;
        }
        WheelHit RLhit;
        float RLForce = 0f;
        if (carController.WheelCollider[2].GetGroundHit(out RLhit))
        {
            RLForce = RLhit.force;
        }
        WheelHit RRhit;
        float RRForce = 0f;
        if (carController.WheelCollider[3].GetGroundHit(out RRhit))
        {
            RRForce = RRhit.force;
        }
        float FrontForceDiff = FLForce - FRForce;
        float RearForceDiff = RLForce - RRForce;

        advanceTelemetry.text = 
            "engine RPM     :   " + (int)engineRPM + " RPM " + "\n" +
            "engine Torque  :   " + (int)engineTorque + " NM  " + "\n" +
            "engine Power   :   " + (int)enginePower + " HP" + "\n" +
            "\n" +
            (int)FL + "  " + (int)FR + "  " + (int)frontWheelRPMDifference + "\n" +
            (int)RL + "  " + (int)RR + "  " + (int)rearWheelRPMDifference + "\n" +
            "\n" + 
            (int)FLForce + "  " + (int)FRForce + " " + (int)FrontForceDiff + "\n" +
            (int)RLForce + "  " + (int)RRForce + " " + (int)RearForceDiff + "\n" +
            "\n"
            ;

        
    }
}
