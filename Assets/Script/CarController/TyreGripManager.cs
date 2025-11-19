using UnityEngine;

public class TyreGripManager : MonoBehaviour
{
    public WheelCollider wheelCollider;

    // Tire grip parameters
    [Header("Grip Settings")]
    public int tyreWidth = 325; //in MM
    public float gripFactor = 1f;
    public float lateralExtremumSlip;
    public float lateralAsymptoteSlip;
    public float longitudinalExtremumSlip;
    public float longitudinalAsympoteSlip;

    public float lateralGrip = 1.0f;
    public float longitudinalGrip = 1.0f;
    public float lateralFactor = 1.0f;
    public float longitudinalFactor = 1.0f;

    [Header("Load Settings")]
    public float referenceLoad = 3000f; // Reference load (N)

    [Header("Slip Settings")]
    public float baseSlipAngle = 5.0f;
    public float tireFlex = 1.0f; // How much the tire flexes under force

    [Header("Grip Falloff Settings")]
    public float longVsLateralRatio = 1.0f;
    public float falloffValue = 0.5f;
    public float falloffSpeed = 2.0f;

    [Header("Sideways Grip Falloff Animation Curve")]
    public float maxSlipAngleCurve;
    public float slipAngleValue;
    public float currentSidewaysGrip;

    [Header("Debug Only")]
    public float loadFactor;
    public float adjustedSlipAngle;
    public float slipAngleFactor;
    public float sidewaysStiffness;
    public float load;

    public float lateralFalloff;
    public float longitudinalFalloff;

    public float lateralForce;
    public float longitudinalForce;

    public float sidewaysSlip;
    public float forwardSlip;

    [Header("Particle System")]
    public ParticleSystem smokeParticles;
    public TrailRenderer trailSkid;
    private ParticleSystem.MainModule mainModule;
    [SerializeField]private float temperature = 0f;

    private void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
        smokeParticles = GetComponentInChildren<ParticleSystem>();
        trailSkid = GetComponentInChildren<TrailRenderer>();
        mainModule = smokeParticles.main;
    }

    void FixedUpdate()
    {
        wheelGripManager();
        wheelSmokeManager();
        trailSkidManager();
    }

    void wheelGripManager() 
    {
        WheelHit hit;
        if (wheelCollider.GetGroundHit(out hit))
        {
            load = Mathf.Abs(hit.force);
            loadFactor = load / referenceLoad;
            forwardSlip = Mathf.Clamp01(Mathf.Abs(hit.forwardSlip));

            if (load < referenceLoad)
            {
                sidewaysStiffness = (0.75f + (loadFactor * (0.25f))) * (1f - forwardSlip);
            }
            else
            {
                sidewaysStiffness = (1f + ((1f - loadFactor) * (0.25f))) * (1f - forwardSlip);
            }

            // Modify WheelCollider Friction Curves
            WheelFrictionCurve forwardFriction = wheelCollider.forwardFriction;
            WheelFrictionCurve sidewaysFriction = wheelCollider.sidewaysFriction;

            forwardFriction.extremumSlip = longitudinalExtremumSlip;
            forwardFriction.extremumValue = longitudinalGrip;
            forwardFriction.asymptoteSlip = longitudinalAsympoteSlip;
            forwardFriction.asymptoteValue = longitudinalFactor;
            forwardFriction.stiffness = gripFactor;

            sidewaysFriction.extremumSlip = lateralExtremumSlip;
            sidewaysFriction.extremumValue = lateralGrip;
            sidewaysFriction.asymptoteSlip = lateralAsymptoteSlip;
            sidewaysFriction.asymptoteValue = lateralFactor;
            sidewaysFriction.stiffness = sidewaysStiffness;

            wheelCollider.forwardFriction = forwardFriction;
            wheelCollider.sidewaysFriction = sidewaysFriction;
        }
    }

    void wheelSmokeManager() 
    {
        WheelHit hit;
        if(wheelCollider.GetGroundHit(out hit)) 
        {
            float forwardSlip = Mathf.Clamp01(Mathf.Abs(hit.forwardSlip));
            float sidewaysSlip = Mathf.Clamp01(Mathf.Abs(hit.sidewaysSlip));
            float slip = Mathf.Max(forwardSlip, sidewaysSlip) / 8f;
            float alpha = Mathf.InverseLerp(0f, 1f, slip);
            temperature = Mathf.Clamp01(temperature);
            temperature += Time.deltaTime * Mathf.Max(forwardSlip, sidewaysSlip) * 2f;
            temperature -= Time.deltaTime / 5f;

            Color startColor = mainModule.startColor.color;
            startColor.a = alpha;
            mainModule.startColor = startColor;

            var emmision = smokeParticles.emission;
            emmision.enabled = temperature > 1f;
        }
    }

    void trailSkidManager() 
    {
        WheelHit hit;
        if (wheelCollider.GetGroundHit(out hit)) 
        {
            Vector3 pos;
            Quaternion rot;
            wheelCollider.GetWorldPose(out pos, out rot);

            Vector3 localPos = transform.InverseTransformPoint(pos);

            float wheelRadius = wheelCollider.radius - 0.02f;
            float trailSkidPosition = localPos.y - wheelRadius;
            float trailSkidOpacity = Mathf.Clamp01(Mathf.Max(Mathf.Abs(hit.forwardSlip), Mathf.Abs(hit.sidewaysSlip)));

            Color trailColor = Color.black;
            trailColor.a = trailSkidOpacity;

            AnimationCurve widthCurve = new AnimationCurve(new Keyframe(0f, wheelRadius));

            trailSkid.startColor = trailColor; trailSkid.endColor = trailColor;
            trailSkid.transform.localPosition = new Vector3(0f, trailSkidPosition, 0f);
            trailSkid.widthCurve = widthCurve;
            trailSkid.time = 100f;
            trailSkid.emitting = trailSkidOpacity > 0.2f && wheelCollider.isGrounded;
        }
    }
}
