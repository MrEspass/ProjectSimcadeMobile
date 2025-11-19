using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public bool isPlayer = true;
    public bool isStatic = false;

    private float rawThrottleInput;
    private float rawBrakeInput;
    private float rawHandBrakeInput;
    private float rawClutchInput;
    private float rawSteerInput;

    [HideInInspector] public float throttleInput;
    [HideInInspector] private float _throttleInput = 0f;
    [HideInInspector] public float brakeInput;
    [HideInInspector] private float _brakeInput = 0f;
    [HideInInspector] public float handBrakeInput;
    [HideInInspector] public float clutchInput;
    [HideInInspector] private float _clutchInput = 0f;
    [HideInInspector] public float steerInput;
    [HideInInspector] public bool isChangingGearUp = false;
    [HideInInspector] public bool isChangingGearDown = false;
    [HideInInspector] public bool isChangingGearUpSequential = false;
    [HideInInspector] public bool isChangingGearDownSequential = false;

    GameObject mainCameraGameObject;
    GameObject SFXGameObject;
    GameObject wheelCollidersGameObject;
    GameObject ColliderGameObject;
    GameObject engineGameObject;
    GameObject gearboxGameObject;

    [Header("Driving Aids")]
    public bool tractionControl = false;
    public bool ABS = false;
    public bool automaticTransmission = false;
    public bool pitLimiter = false;
    [HideInInspector] public bool tractionControlActivated = false;
    [HideInInspector] public bool ABSActivated = false;
    [HideInInspector] public bool automaticTransmissionActivated = false;

    [Header("Car Lights Manager")]
    public GameObject frontLightOn;
    public GameObject brakeLightOn;
    public GameObject leftSignLightOn;
    public GameObject rightSignLightOn;
    public GameObject rearGearLightOn;
    public bool isBulbLight;
    public bool enableFrontLight;
    private bool enableBrakeLight = false;
    private bool enableLeftSignLight = false;
    private bool enableRightSignLight = false;
    private bool enableHazardSignLight = false;
    private bool enableRearGearLight = false;
    private float signTimer = 0f;
    private bool signTrigger = false;
    //White
    float rFront = 0f; float gFront = 0f; float bFront = 0f;
    //Red
    float rBrake = 0f; float gBrake = 0f; float bBrake = 0f;
    //Orange
    float rSign = 0f; float gSign = 0f; float bSign = 0f;
    //Dark
    float rRear = 0f; float gRear = 0f; float bRear = 0f;

    [Header("Car Dimension")]
    public int carMass = 1000;
    [Range(0, 100)] public int weightDistribution;
    [HideInInspector] public Rigidbody carRigidbody;

    [Header("Wheels Transform")]
    public Transform[] WheelMesh; // Note : the order should be FL, FR, RL, RR
    public Transform[] CaliperMesh;
    public WheelCollider[] WheelCollider;

    public bool wheelGrounded = false;
    public bool wheelSkids = false;

    float eulerX = 0f;
    float eulerY = 0f;

    [Header("Car Drivetrain")]
    public drivetrain carDrivetrain;
    public enum drivetrain 
    {
        FWD,
        RWD,
        AWD
    }
    [Range(1, 100)] public int drivetrainDistribution; // for AWD
    [HideInInspector] public float wheelRPM;
    [HideInInspector] public float wheelGearboxRPM;

    [Header("Car Max Steering and Max Brake")]
    public int steeringAngleMax;
    [HideInInspector] public float steerAngle;
    public float brakeTorque;
    [Range(1, 100)] public int brakeDistribution;
    public float handBrakeTorque;

    carEngine engine;
    carGearbox gearbox;
    [Header("Car SFX")]
    public AudioSource whineSound;
    public AudioSource skidSound;
    public AudioSource windSound;
    [HideInInspector] public float engineTorque; // in NM
    [HideInInspector] public float engineInertia; // in NM
    [HideInInspector] public float enginePower; // in HP
    [HideInInspector] public float torqueFriction;
    [HideInInspector] public float engineInertiaSpeed;
    [HideInInspector] public float maxRPM;
    [HideInInspector] public float minRPM;
    [HideInInspector] public float redlineRPM;
    [HideInInspector] public float RPMHudLimit;
    [HideInInspector] public float torqueValue; //applied torque to gearbox then to WheelCollider
    [HideInInspector] public float engineRPM;
    [HideInInspector] public bool isUseTurbo = false;
    [HideInInspector] public float currentTurboCapasity;
    [HideInInspector] public int currentGear;

    [Header("Car Automatic Debugging")]
    [SerializeField] private float[] gearboxRPM;
    public int expectedGear = 0;

    [Header("Car Anti-Rollbar")]
    [Range(1, 10)] public int antiRollFront = 7;  // Force applied to prevent rolling
    [Range(1, 10)] public int antiRollRear = 3;  // Force applied to prevent rolling
    [SerializeField] private float frontWheelDifference;
    [SerializeField] private float rearWheelDifference;

    [Header("Car Force Feedback For Steering Assist")]
    private float feedbackIntensity = 1f;
    private float totalFeedback;

    [Header("Car Drag")]
    public float minDrag; //drag at 400KM/H
    public float maxDrag; //drag at 400KM/H

    [Header("Car Aerodynamics")]
    public GameObject frontAero;
    public GameObject floorAero;
    public GameObject rearAero;
    [SerializeField] private CarAerodynamics frontAeroData;
    [SerializeField] private CarAerodynamics floorAeroData;
    [SerializeField] private CarAerodynamics rearAeroData;

    public void ThrottleInput(InputAction.CallbackContext ctx)
    {
        rawThrottleInput = ctx.ReadValue<float>();
    }
    public void BrakeInput(InputAction.CallbackContext ctx)
    {
        rawBrakeInput = ctx.ReadValue<float>();
    }

    public void HandBrakeInput(InputAction.CallbackContext ctx)
    {
        rawHandBrakeInput = ctx.ReadValue<float>();
    }
    public void ClutchInput(InputAction.CallbackContext ctx)
    {
        rawClutchInput = ctx.ReadValue<float>();
    }
    public void SteerInput(InputAction.CallbackContext ctx)
    {
        rawSteerInput = ctx.ReadValue<float>();
    }
    public void ShiftUp(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) 
        {
            expectedGear++;
        }
    }
    public void ShiftDown(InputAction.CallbackContext ctx)
    {
        if (ctx.performed) 
        {
            expectedGear--;
        }
    }
    public void leftSign(InputAction.CallbackContext ctx) 
    {
        enableLeftSignLight = !enableLeftSignLight;
        enableRightSignLight = false;
        enableHazardSignLight = false;
    }
    public void rightSign(InputAction.CallbackContext ctx)
    {
        enableLeftSignLight = false;
        enableRightSignLight = !enableRightSignLight;
        enableHazardSignLight = false;
    }
    public void hazardSign(InputAction.CallbackContext ctx)
    {
        enableLeftSignLight = false;
        enableRightSignLight = false;
        enableHazardSignLight = !enableHazardSignLight;
    }
    public void frontLight(InputAction.CallbackContext ctx)
    {
        enableFrontLight = !enableFrontLight;
    }

    // Start is called before the first frame update
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        adjustWeightDistribution();
        currentGear = 1;
        engineRPM = minRPM;
        engine = GetComponentInChildren<carEngine>();
        gearbox = GetComponentInChildren<carGearbox>();
        expectedGear = 1;

        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.enabled = isPlayer && !isStatic;

        string cameraname = "MainCameraGameObject";
        string sfxname = "sfx";
        string wcname = "WheelCollider";
        string cname = "Collider";
        string enginename = engine.gameObject.name;
        string gearboxname = gearbox.gameObject.name;
        mainCameraGameObject = GameObject.Find(cameraname);
        SFXGameObject = GameObject.Find(sfxname);
        wheelCollidersGameObject = GameObject.Find(wcname);
        ColliderGameObject = GameObject.Find(cname);
        engineGameObject = GameObject.Find(enginename);
        gearboxGameObject = GameObject.Find(gearboxname);

        SFXGameObject.SetActive(!isStatic);
        wheelCollidersGameObject.SetActive(!isStatic);
        ColliderGameObject.SetActive(!isStatic);
        engineGameObject.SetActive(!isStatic);
        gearboxGameObject.SetActive(!isStatic);
        carRigidbody.useGravity = !isStatic;
        if (playerInput.enabled)
        {
            mainCameraGameObject.SetActive(true);
        }
        else
        {
            mainCameraGameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        inputManager();
    }

    void FixedUpdate()
    {
        if (!isStatic) 
        {
            WheelMeshRotation();
            WheelColliderManager();
            //ApplyAntiRoll();
            ForceFeedbackFrontWheels();
            carEngineCalculator();
            soundCalculator();
            aerodynamicCalculatorBeta();
            wheelRPMManager();
            DrivingAidsController();
            carLightsController();
        }
    }

    void adjustWeightDistribution()
    {
        carRigidbody.mass = carMass;
        float centerWheelBaseLengthZ = (WheelCollider[0].transform.localPosition.z + WheelCollider[2].transform.localPosition.z) /2f;

        float carLength = WheelCollider[0].transform.localPosition.z - WheelCollider[2].transform.localPosition.z;
        float frontDistribution = (carLength / 2f) * (weightDistribution / 100f);
        float rearDistribution = (carLength / 2f) * ((100f - weightDistribution) / 100f);

        float carHeight = (WheelCollider[0].transform.localPosition.y + WheelCollider[2].transform.localPosition.y) / 2f;

        float centerOfMassPosZ = centerWheelBaseLengthZ + (rearDistribution - frontDistribution);
        float centerOfMassPosY = carHeight;

        Vector3 pos = new Vector3(0, centerOfMassPosY, centerOfMassPosZ);
        carRigidbody.centerOfMass = pos;
    }

    void WheelMeshRotation()
    {
        for (int i = 0; i < 1; i++)
        {
            Vector3 pos;
            Quaternion rot;
            WheelCollider[i].GetWorldPose(out pos, out rot);
            WheelMesh[i].position = pos;

            float rotationSpeed = WheelCollider[i].rpm / 15f;
            eulerX += rotationSpeed;
            eulerY = WheelCollider[i].steerAngle;
            WheelMesh[i].localEulerAngles = new Vector3(eulerX, eulerY, 0f);

            float caliperRot = WheelCollider[i].steerAngle;
            CaliperMesh[i].position = pos;
            CaliperMesh[i].localEulerAngles = new Vector3(0, caliperRot, 0);
        }

        for (int i = 1; i < 2; i++)
        {
            Vector3 pos;
            Quaternion rot;
            WheelCollider[i].GetWorldPose(out pos, out rot);
            WheelMesh[i].position = pos;

            float rotationSpeed = WheelCollider[i].rpm / 15f;
            eulerX += rotationSpeed;
            eulerY = Mathf.Lerp(eulerY, WheelCollider[i].steerAngle, Time.deltaTime * 10f);
            WheelMesh[i].localEulerAngles = new Vector3(eulerX, eulerY, 0f);

            float caliperRot = WheelCollider[i].steerAngle;
            CaliperMesh[i].position = pos;
            CaliperMesh[i].localEulerAngles = new Vector3(0, caliperRot, 0);
        }

        for (int i = 2; i < 4; i++)
        {
            Vector3 pos;
            Quaternion rot;
            WheelCollider[i].GetWorldPose(out pos, out rot);
            WheelMesh[i].position = pos;
            WheelMesh[i].rotation = rot;
            CaliperMesh[i].position = pos;
        }
    }

    void WheelColliderManager()
    {
        AnimationCurve steeringAssistAngle = new AnimationCurve(
            new Keyframe(0f, steeringAngleMax),
            new Keyframe(40f, 12f),
            new Keyframe(110f, 4f),
            new Keyframe(220f, 2f),
            new Keyframe(440f, 1f)
            );

        float _totalFeedback = totalFeedback * (steeringAngleMax);

        float speed = Mathf.Abs(carRigidbody.velocity.magnitude * 3.6f);
        float speedFactor = steeringAssistAngle.Evaluate(speed);

        float currentSteerAngleMax = speedFactor;

        steerAngle = Mathf.Clamp((currentSteerAngleMax * (steerInput)) + _totalFeedback, -steeringAngleMax, steeringAngleMax);

        float brakeTorqueValue = brakeTorque * brakeInput;
        float handBrakeTorqueValue = handBrakeTorque * handBrakeInput;

        float frontTorqueValue = 0f;
        float rearTorqueValue = 0f;
        switch (carDrivetrain) 
        {
            case drivetrain.FWD:
                frontTorqueValue = torqueValue;
                rearTorqueValue = 0f;
                break;
            case drivetrain.RWD:
                frontTorqueValue = 0f;
                rearTorqueValue = torqueValue;
                break;
            case drivetrain.AWD:
                frontTorqueValue = torqueValue * ((100f - drivetrainDistribution) / 100f);
                rearTorqueValue = torqueValue * ((drivetrainDistribution) / 100f);
                break;
        }

        for (int i = 0; i < 2; i++)
        {
            float _motorTorqueValue = 0f;
            float _enginebrakeTorqueValue = 0f;
            if (frontTorqueValue >= 0f)
            {
                if (currentGear != 0)
                {
                    _motorTorqueValue = frontTorqueValue / 2f;
                }
                else
                {
                    _motorTorqueValue = -frontTorqueValue / 2f;
                }
                _enginebrakeTorqueValue = 0f;
            }
            if (frontTorqueValue < 0f)
            {
                _motorTorqueValue = 0f;
                _enginebrakeTorqueValue = Mathf.Abs(frontTorqueValue) / 2f;
            }
            WheelCollider[i].motorTorque = _motorTorqueValue;
            WheelCollider[i].brakeTorque = _enginebrakeTorqueValue + (brakeTorqueValue * ((100f - brakeDistribution) / 100f));
            WheelCollider[i].steerAngle = steerAngle;
        }

        for (int i = 2; i < 4; i++)
        {
            float _motorTorqueValue = 0f;
            float _enginebrakeTorqueValue = 0f;
            if(rearTorqueValue >= 0f) 
            {
                if(currentGear != 0) 
                {
                    _motorTorqueValue = rearTorqueValue / 2f;
                }
                else 
                {
                    _motorTorqueValue = -rearTorqueValue / 2f;
                }
                _enginebrakeTorqueValue = 0f;
            }
            if(rearTorqueValue < 0f)
            {
                _motorTorqueValue = 0f;
                _enginebrakeTorqueValue = Mathf.Abs(rearTorqueValue) / 2f;
            }
            WheelCollider[i].motorTorque = _motorTorqueValue;
            WheelCollider[i].brakeTorque = _enginebrakeTorqueValue + handBrakeTorqueValue + (brakeTorqueValue * ((100f - brakeDistribution) / 100f));
        }
        LSDSetting();
    }

    void LSDSetting() 
    {
        float frontWheelRPMDifference = Mathf.Abs(WheelCollider[0].rpm - WheelCollider[1].rpm);
        if(frontWheelRPMDifference > 100f) 
        {
            if (WheelCollider[0].rpm > WheelCollider[1].rpm)
            {
                WheelCollider[0].motorTorque = 0f;
            }
            else
            {
                WheelCollider[1].motorTorque = 0f;
            }
        }

        float rearWheelRPMDifference = Mathf.Abs(WheelCollider[2].rpm - WheelCollider[3].rpm);
        if (rearWheelRPMDifference > 100f) 
        {
            if (WheelCollider[2].rpm > WheelCollider[3].rpm)
            {
                WheelCollider[2].motorTorque = 0f;
            }
            else
            {
                WheelCollider[3].motorTorque = 0f;
            }
        }
    }

    void inputManager()
    {
        _throttleInput = Mathf.MoveTowards(_throttleInput, rawThrottleInput, Time.deltaTime * 5f);
        _brakeInput = Mathf.MoveTowards(_brakeInput, rawBrakeInput, Time.deltaTime * 5f);
        _clutchInput = Mathf.MoveTowards(_clutchInput, rawClutchInput, Time.deltaTime * 5f);
        expectedGear = Mathf.Clamp(expectedGear, 0, gearbox.gearRatio.Length - 1);

        //trigger change gear
        if (isChangingGearUp) 
        {
            clutchInput = 1f;
            throttleInput = 0f;
        }
        else if (isChangingGearDown)
        {
            clutchInput = 1f;
            throttleInput = 0.5f;
        }

        else if (isChangingGearUpSequential)
        {
            clutchInput = 0f;
            throttleInput = 0f;
        }

        else if (isChangingGearDownSequential)
        {
            clutchInput = 0f;
            throttleInput = 0.75f;
        }

        //anti-stall throttle
        else if(engineRPM < engine.minRPM + (engine.minRPM * 0.2f) && currentGear != 1) 
        {
            throttleInput = _throttleInput;
            clutchInput = 1f;
        }

        //traction control
        else if (tractionControlActivated) 
        {
            throttleInput = 0f;
        }
        else 
        {
            throttleInput = _throttleInput;
            clutchInput = _clutchInput;
        }

        if (ABSActivated) 
        {
            brakeInput = 0f;
        }
        else 
        {
            brakeInput = _brakeInput;
        }
        
        handBrakeInput = Mathf.MoveTowards(handBrakeInput, rawHandBrakeInput, Time.deltaTime * 10f);

        steerInput = Mathf.Lerp(steerInput, rawSteerInput, Time.deltaTime * 5f);

        if (pitLimiter) 
        {
            throttleInput = applyPitLimiter(throttleInput);
        }
        else 
        {
            throttleInput = Mathf.Clamp01(throttleInput);
        }
        brakeInput = Mathf.Clamp01(brakeInput);
        handBrakeInput = Mathf.Clamp01(handBrakeInput);
        clutchInput = Mathf.Clamp01(clutchInput);
        steerInput = Mathf.Clamp(steerInput, -1, 1);
    }

    float applyPitLimiter(float input) 
    {
        float speed = carRigidbody.velocity.magnitude * 3.6f;
        float overspeed = speed - 79f;
        float limiterAggressiveness = 0.9f;

        if (overspeed <= 0f) 
        {
            return input;
        }
        else 
        {
            float limiter = Mathf.Clamp01(1f - (overspeed / limiterAggressiveness));
            return input * limiter;
        }
    }

    void DrivingAidsController() 
    {
        //ABS Controller
        if(ABS)
        {
            if (wheelSkids)
            {
                ABSActivated = true;
            }
            else
            {
                ABSActivated = false;
            }
        }

        float FLRPM = WheelCollider[0].rpm;
        float FRRPM = WheelCollider[1].rpm;
        float RLRPM = WheelCollider[2].rpm;
        float RRRPM = WheelCollider[3].rpm;
        if (tractionControl) 
        {
            float front = Mathf.Max(Mathf.Abs(FLRPM), Mathf.Abs(FRRPM));
            float rear = Mathf.Max(Mathf.Abs(RLRPM), Mathf.Abs(RRRPM));
            float difference = Mathf.Abs(front - rear);
            if(difference > 100f) 
            {
                tractionControlActivated = true;
            }
            else 
            {
                tractionControlActivated = false;
            }
        }

        if (automaticTransmission)
        {
            if(currentGear != 0) 
            {
                AutomaticTransmissionManager(currentGear, redlineRPM, wheelRPM);
            }
        }
    }

    void AutomaticTransmissionManager(int currentGear, float redlineRPM, float wheelRPM) 
    {
        int totalGearbox = gearbox.gearRatio.Length;
        gearboxRPM = new float[totalGearbox];

        for (int i = 0; i < totalGearbox; i++) 
        {
            gearboxRPM[i] = wheelRPM * gearbox.gearRatio[i] * gearbox.finalDrive;
        }

        float rpmUpShiftGearPoint = redlineRPM;
        float rpmDownShiftGearPoint = redlineRPM * 0.8f;

        if(gearboxRPM[currentGear] > rpmUpShiftGearPoint && currentGear > 1 && wheelGrounded && !wheelSkids) 
        {
            expectedGear++;
        }

        if(gearboxRPM[currentGear-1] < rpmDownShiftGearPoint && currentGear > 2 && wheelGrounded && !wheelSkids) 
        {
            expectedGear--;
        }
    }

    void ApplyAntiRoll()
    {
        Vector3 wheelColliderFLTransform = WheelCollider[0].transform.localPosition;
        Vector3 wheelColliderFRTransform = WheelCollider[1].transform.localPosition;
        Vector3 wheelColliderRLTransform = WheelCollider[2].transform.localPosition;
        Vector3 wheelColliderRRTransform = WheelCollider[3].transform.localPosition;

        Vector3 wheelMeshFLTransform = WheelMesh[0].transform.localPosition;
        Vector3 wheelMeshFRTransform = WheelMesh[1].transform.localPosition;
        Vector3 wheelMeshRLTransform = WheelMesh[2].transform.localPosition;
        Vector3 wheelMeshRRTransform = WheelMesh[3].transform.localPosition;

        float FL = (wheelColliderFLTransform.y - wheelMeshFLTransform.y);
        float FR = (wheelColliderFRTransform.y - wheelMeshFRTransform.y);
        float RL = (wheelColliderRLTransform.y - wheelMeshRLTransform.y);
        float RR = (wheelColliderRRTransform.y - wheelMeshRRTransform.y);

        WheelCollider[0].center = new Vector3(0f, (0.05f + (FL * antiRollFront / 10f)), 0f);
        WheelCollider[1].center = new Vector3(0f, (0.05f + (FR * antiRollFront / 10f)), 0f);
        WheelCollider[2].center = new Vector3(0f, (0.05f + (RL * antiRollRear / 10f)), 0f);
        WheelCollider[3].center = new Vector3(0f, (0.05f + (RR * antiRollRear / 10f)), 0f);
    }

    void ForceFeedbackFrontWheels()
    {
        float forceFeedbackLeft = 0f;
        float forceFeedbackRight = 0f;

        if (WheelCollider[0].GetGroundHit(out WheelHit hitLeft))
        {
            forceFeedbackLeft = hitLeft.sidewaysSlip * feedbackIntensity;
        }
        if (WheelCollider[1].GetGroundHit(out WheelHit hitRight))
        {
            forceFeedbackRight = hitRight.sidewaysSlip * feedbackIntensity;
        }
        float _totalFeedback = (forceFeedbackLeft + forceFeedbackRight) / 2f;
        totalFeedback = _totalFeedback;
    }

    void carEngineCalculator() 
    {
        engineTorque = engine.torqueCalculator(throttleInput, engineRPM);
        engineInertia = engine.engineInertiaSpeed * engineTorque;
        engineRPM = gearbox.gearboxRPM(wheelGearboxRPM, engine.maxRPM, clutchInput, engineInertia);

        const float nmtolbft = 3.2808398950131f / 4.4482216152605f;
        enginePower = (engineTorque * nmtolbft) * engineRPM / 5252f;
        torqueValue = gearbox.wheelTorque(engineTorque, clutchInput);
        gearbox.Shifter(expectedGear);
        currentGear = gearbox.currentGear;
        maxRPM = engine.maxRPM;
        redlineRPM = engine.redlineRPM;
        RPMHudLimit = engine.RPMHudLimit;
        currentTurboCapasity = engine.currentTuboCapasity;
        isUseTurbo = engine.isUseTurbo;
    }

    void soundCalculator() 
    {
        float wheelColliderRPM = Mathf.Max(WheelCollider[2].rpm, WheelCollider[3].rpm);
        WheelHit hitFL;
        float skidFL = 0f;
        if(WheelCollider[0].GetGroundHit(out hitFL)) 
        {
            skidFL = Mathf.Abs(hitFL.forwardSlip + hitFL.sidewaysSlip);
        }
        WheelHit hitFR;
        float skidFR = 0f;
        if (WheelCollider[1].GetGroundHit(out hitFR))
        {
            skidFR = Mathf.Abs(hitFR.forwardSlip + hitFR.sidewaysSlip);
        }
        WheelHit hitRL;
        float skidRL = 0f;
        if (WheelCollider[2].GetGroundHit(out hitRL))
        {
            skidRL = Mathf.Abs(hitRL.forwardSlip + hitRL.sidewaysSlip);
        }
        WheelHit hitRR;
        float skidRR = 0f;
        if (WheelCollider[3].GetGroundHit(out hitRR))
        {
            skidRR = Mathf.Abs(hitRR.forwardSlip + hitRR.sidewaysSlip);
        }
        float skidTotal = (Mathf.Max(skidFL, skidFR, skidRL, skidRR) * 0.8f) - 0.1f;
        float _whineSoundPitch = wheelColliderRPM / 1000f;
        float _windSoundvolume = ((carRigidbody.velocity.magnitude * 3.6f) / 240f) * 0.5f;

        whineSound.pitch = _whineSoundPitch;
        whineSound.volume = 0.1f;
        skidSound.volume = Mathf.Lerp(skidSound.volume, Mathf.Clamp01(skidTotal), Time.deltaTime * 10f);
        windSound.volume = _windSoundvolume;

        engine.volumeControl(engineRPM, throttleInput);
    }

    void aerodynamicCalculatorBeta()
    {
        frontAero = GameObject.Find("Front_Aero");
        floorAero = GameObject.Find("Floor_Aero");
        rearAero = GameObject.Find("Rear_Aero");

        if (frontAero != null) 
        {
            frontAeroData = frontAero.GetComponent<CarAerodynamics>();
        }
        if (floorAero != null) 
        {
            floorAeroData = floorAero.GetComponent<CarAerodynamics>();
        }
        if (rearAero != null) 
        {
            rearAeroData = rearAero.GetComponent<CarAerodynamics>();
        }

        //Drag Calculator
        float frontDrag = 0f;
        float floorDrag = 0f;
        float rearDrag = 0f;
        if(frontAeroData != null) 
        {
            frontDrag = frontAeroData.aeroDrag();
        }
        if (frontAeroData != null)
        {
            floorDrag = floorAeroData.aeroDrag();
        }
        if (frontAeroData != null)
        {
            rearDrag = rearAeroData.aeroDrag();
        }
        float dragPerSpeed = minDrag + ((((carRigidbody.velocity.magnitude * 3.6f) / 400f) * (maxDrag - minDrag)));
        carRigidbody.drag = dragPerSpeed + frontDrag + floorDrag + rearDrag;

        //Lift Calculator
        float frontLift = 0f;
        float floorLift = 0f;
        float rearLift = 0f;
        float speed = carRigidbody.velocity.magnitude;
        if (frontAeroData != null)
        {
            frontLift = (0.5f) * (1.225f) * (speed) * (speed) * (frontAeroData.aeroLift());
        }
        if (floorAeroData != null)
        {
            floorLift = (0.5f) * (1.225f) * (speed) * (speed) * (floorAeroData.aeroLift());
        }
        if (rearAeroData != null)
        {
            rearLift = (0.5f) * (1.225f) * (speed) * (speed) * (rearAeroData.aeroLift());
        }

        carRigidbody.AddForce(frontLift * Vector3.down);
        carRigidbody.AddForce(rearLift * Vector3.down);
        carRigidbody.AddForce(floorLift * Vector3.down);
    }

    void wheelRPMManager() 
    {
        float gearRatio = gearbox.gearRatio[gearbox.currentGear];
        float finalDrive = gearbox.finalDrive;

        WheelHit hitFL;
        WheelCollider[0].GetGroundHit(out hitFL);
        float wheelSkidsFL = Mathf.Abs(hitFL.forwardSlip);

        WheelHit hitFR;
        WheelCollider[1].GetGroundHit(out hitFR);
        float wheelSkidsFR = Mathf.Abs(hitFR.forwardSlip);

        WheelHit hitRL;
        WheelCollider[2].GetGroundHit(out hitRL);
        float wheelSkidsRL = Mathf.Abs(hitRL.forwardSlip);

        WheelHit hitRR;
        WheelCollider[3].GetGroundHit(out hitRR);
        float wheelSkidsRR = Mathf.Abs(hitRR.forwardSlip);

        switch (carDrivetrain) 
        {
            case drivetrain.FWD:
                wheelRPM = Mathf.Max(Mathf.Abs(WheelCollider[0].rpm), Mathf.Abs(WheelCollider[1].rpm));
                wheelGearboxRPM = wheelRPM * gearRatio * finalDrive;
                if (WheelCollider[0].isGrounded && WheelCollider[1].isGrounded) { wheelGrounded = true; } else { wheelGrounded = false; }
                if (wheelSkidsFL > 0.2f || wheelSkidsFR > 0.2f) { wheelSkids = true; } else { wheelSkids = false; }
                break;
            case drivetrain.RWD:
                wheelRPM = Mathf.Max(Mathf.Abs(WheelCollider[2].rpm), Mathf.Abs(WheelCollider[3].rpm));
                wheelGearboxRPM = wheelRPM * gearRatio * finalDrive;
                if (WheelCollider[2].isGrounded && WheelCollider[3].isGrounded) { wheelGrounded = true; } else { wheelGrounded = false; }
                if (wheelSkidsRL > 0.2f || wheelSkidsRR > 0.2f) { wheelSkids = true; } else { wheelSkids = false; }
                break;
            case drivetrain.AWD:
                float frontWheelRPM = (((WheelCollider[0].rpm + WheelCollider[1].rpm) / 2f) * ((100f - drivetrainDistribution) / 100f));
                float rearWheelRPM = (((WheelCollider[2].rpm + WheelCollider[3].rpm) / 2f) * ((drivetrainDistribution) / 100f));
                wheelRPM = Mathf.Abs((frontWheelRPM + rearWheelRPM));
                wheelGearboxRPM = wheelRPM * gearRatio * finalDrive;
                if (WheelCollider[0].isGrounded && WheelCollider[1].isGrounded && WheelCollider[2].isGrounded && WheelCollider[3].isGrounded) { wheelGrounded = true; } else { wheelGrounded = false; }
                if (wheelSkidsFL > 0.2f || wheelSkidsFR > 0.2f || wheelSkidsRL > 0.2f || wheelSkidsRR > 0.2f) { wheelSkids = true; } else { wheelSkids = false; }
                break;
        }
    }

    void carLightsController()
    {
        // --Triggering Bool--
        if(rawBrakeInput > 0.1f) { enableBrakeLight = true; } else { enableBrakeLight = false; }
        if(currentGear == 0) { enableRearGearLight = true;  } else { enableRearGearLight = false; }

        // --Triggering Light--
        if (!isBulbLight) 
        {
            bulbLight(1000f);
        }
        else 
        {
            bulbLight(10f);
        }
    }

    void bulbLight(float time) 
    {
        Material frontLight = frontLightOn.GetComponent<Renderer>().material;
        Material brakeLight = brakeLightOn.GetComponent<Renderer>().material;
        Material leftSignLight = leftSignLightOn.GetComponent<Renderer>().material;
        Material rightSignLight = rightSignLightOn.GetComponent<Renderer>().material;
        Material rearGearLight = rearGearLightOn.GetComponent<Renderer>().material;

        Color white = new Color(0.7830189f, 0.7830189f, 0.7830189f);
        Color red = new Color(0.7058824f, 0f, 0f);
        Color redDark = new Color(0.3529412f, 0f, 0f);
        Color orange = new Color(1f, 0.6470588f, 0f);

        //Front Lights
        if (enableFrontLight)
        {
            rFront = Mathf.Lerp(rFront, white.r, Time.deltaTime * time);
            gFront = Mathf.Lerp(gFront, white.g, Time.deltaTime * time);
            bFront = Mathf.Lerp(bFront, white.b, Time.deltaTime * time);
        }
        else
        {
            rFront = Mathf.Lerp(rFront, 0f, Time.deltaTime * time);
            gFront = Mathf.Lerp(gFront, 0f, Time.deltaTime * time);
            bFront = Mathf.Lerp(bFront, 0f, Time.deltaTime * time);
        }

        //Brake Lights
        if (enableBrakeLight) 
        {
            rBrake = Mathf.Lerp(rBrake, red.r,Time.deltaTime * time);
            gBrake = Mathf.Lerp(gBrake, red.g, Time.deltaTime * time);
            bBrake = Mathf.Lerp(bBrake, red.b, Time.deltaTime * time);
        }
        else 
        {
            if (enableFrontLight) 
            {
                rBrake = Mathf.Lerp(rBrake, redDark.r, Time.deltaTime * time);
                gBrake = Mathf.Lerp(gBrake, redDark.g, Time.deltaTime * time);
                bBrake = Mathf.Lerp(bBrake, redDark.b, Time.deltaTime * time);
            } else 
            {
                rBrake = Mathf.Lerp(rBrake, 0f, Time.deltaTime * time);
                gBrake = Mathf.Lerp(gBrake, 0f, Time.deltaTime * time);
                bBrake = Mathf.Lerp(bBrake, 0f, Time.deltaTime * time);
            }
        }

        //Rear Gear Lights
        if (enableRearGearLight)
        {
            rRear = Mathf.Lerp(rRear, white.r, Time.deltaTime * time);
            gRear = Mathf.Lerp(gRear, white.g, Time.deltaTime * time);
            bRear = Mathf.Lerp(bRear, white.b, Time.deltaTime * time);
        }
        else
        {
            rRear = Mathf.Lerp(rRear, 0f, Time.deltaTime * time);
            gRear = Mathf.Lerp(gRear, 0f, Time.deltaTime * time);
            bRear = Mathf.Lerp(bRear, 0f, Time.deltaTime * time);
        }


        //Sign lights
        string signString;
        if (enableLeftSignLight) { signString = "left"; }
        else if (enableRightSignLight) { signString = "right"; }
        else if (enableHazardSignLight) { signString = "hazard"; }
        else { signString = ""; }

        if (signString != "")
        {
            signTimer -= Time.deltaTime;
            if (signTimer < 0)
            {
                signTrigger = !signTrigger;
                signTimer = 0.5f;
            }
        }
        else
        {
            signTrigger = false;
            signTimer = 0f;
        }
        
        //Sign Lights
        if (signTrigger)
        {
            rSign = Mathf.Lerp(rSign, orange.r, Time.deltaTime * time);
            gSign = Mathf.Lerp(gSign, orange.g, Time.deltaTime * time);
            bSign = Mathf.Lerp(bSign, orange.b, Time.deltaTime * time);
        }
        else
        {
            rSign = Mathf.Lerp(rSign, 0f, Time.deltaTime * time);
            gSign = Mathf.Lerp(gSign, 0f, Time.deltaTime * time);
            bSign = Mathf.Lerp(bSign, 0f, Time.deltaTime * time);
        }

        switch (signString) 
        {
            case "left":
                leftSignLight.SetColor("_EmissionColor", new Color(rSign, gSign, bSign));
                break;
            case "right":
                rightSignLight.SetColor("_EmissionColor", new Color(rSign, gSign, bSign));
                break;
            case "hazard":
                leftSignLight.SetColor("_EmissionColor", new Color(rSign, gSign, bSign));
                rightSignLight.SetColor("_EmissionColor", new Color(rSign, gSign, bSign));
                break;
            default:
                leftSignLight.SetColor("_EmissionColor", new Color(0f, 0f, 0f));
                rightSignLight.SetColor("_EmissionColor", new Color(0f, 0f, 0f));
                break;
        }

        //apply lightings beside signs
        frontLight.SetColor("_EmissionColor", new Color(rFront, gFront, bFront));
        brakeLight.SetColor("_EmissionColor", new Color(rBrake, gBrake, bBrake));
        rearGearLight.SetColor("_EmissionColor", new Color(rRear, gRear, bRear));
    }

    void OnDrawGizmosSelected()
    {
        if (TryGetComponent(out Rigidbody rb))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(rb.worldCenterOfMass, 0.1f);
        }
    }

}