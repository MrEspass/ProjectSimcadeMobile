using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carGearbox : MonoBehaviour
{
    CarController car;

    [Header("Gearbox Setup")]
    public gearboxType gearbox;
    public enum gearboxType 
    {
        HShifter,
        SequentialShifterNew,
        SequentialShifterOld
    }
    public float[] gearRatio;  // element 0 and 1 should be Reverse and Neutral
    public float finalDrive;
    public float gearChangeTime;
    public int currentGear;
    public float RPM;
    public float timer;
    public AudioSource gearChangeSound;

    [SerializeField] bool changingGearUp = false;
    [SerializeField] bool changingGearDown = false;
    [SerializeField] bool changingGearUpSequential = false;
    [SerializeField] bool changingGearDownSequential = false;
    [SerializeField] int _currentGear = 1;

    // Start is called before the first frame update
    void Start()
    {
        RPM = 2000f;
        car = GetComponentInParent<CarController>();
        _currentGear = 1;
        gearRatio[0] = gearRatio[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        int expectedGear = car.expectedGear;
        //HShifterGearChanging(expectedGear);
    }

    public float wheelTorque(float engineTorque, float clutch) 
    {
        float wheelTorqueTotal = engineTorque * gearRatio[currentGear] * finalDrive * (1f-clutch);
        return wheelTorqueTotal;
    }

    public float gearboxRPM(float wheelRPM, float maxRPM, float clutch, float engineInertia) 
    {
        if (currentGear == 1 || clutch == 1f || RPM > maxRPM)
        {
            RPM += engineInertia;
        }
        else
        {
            float velocity = 0f;
            RPM = Mathf.SmoothDamp(RPM, wheelRPM, ref velocity, 0.05f);
            RPM += engineInertia * clutch;
        }
        
        return RPM;
    }

    public void Shifter(int expectedGear) 
    {
        switch (gearbox) 
        {
            case gearboxType.HShifter:
                hShifter(expectedGear) ;
                break;
            case gearboxType.SequentialShifterNew:
                sequentialShifterNew(expectedGear);
                break;
            case gearboxType.SequentialShifterOld:
                sequentialShifterOld(expectedGear);
                break;
        }
    }
    public void hShifter(int expectedGear)
    {
        if (expectedGear > _currentGear && !car.isChangingGearUp)
        {
            currentGear = 1;
            car.isChangingGearUp = true;
            timer = gearChangeTime;
        }
        if (expectedGear < _currentGear && !car.isChangingGearDown)
        {
            currentGear = 1;
            car.isChangingGearDown = true;
            timer = gearChangeTime;
        }

        if (car.isChangingGearUp)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                currentGear = expectedGear;
                _currentGear = currentGear;
                car.isChangingGearUp = false;
            }
        }
        if (car.isChangingGearDown)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                currentGear = expectedGear;
                _currentGear = currentGear;
                car.isChangingGearDown = false;
            }
        }
    }

    public void sequentialShifterNew(int expectedGear)
    {
        if(expectedGear > _currentGear) 
        {
            currentGear = expectedGear;
            _currentGear = currentGear;
        }
        if(expectedGear < _currentGear && !car.isChangingGearDown) 
        {
            currentGear = 1;
            car.isChangingGearDown = true;
            timer = gearChangeTime;
        }

        if (car.isChangingGearDown)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                currentGear = expectedGear;
                _currentGear = currentGear;
                car.isChangingGearDown = false;
            }
        }
    }

    public void sequentialShifterOld(int expectedGear)
    {
        if(expectedGear > _currentGear && !car.isChangingGearUpSequential) 
        {
            currentGear = 1;
            car.isChangingGearUpSequential = true;
            timer = gearChangeTime;
        }
        if (expectedGear < _currentGear && !car.isChangingGearDownSequential)
        {
            currentGear = 1;
            car.isChangingGearDownSequential = true;
            timer = gearChangeTime;
        }

        if(car.isChangingGearUpSequential) 
        {
            timer -= Time.deltaTime;
            if(timer <= 0f) 
            {
                currentGear = expectedGear;
                _currentGear = currentGear;
                car.isChangingGearUpSequential = false;
            }
        }
        if (car.isChangingGearDownSequential)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                currentGear = expectedGear;
                _currentGear = currentGear;
                car.isChangingGearDownSequential = false;
            }
        }
    }

    void HShifterGearChanging(int expectedGear)
    {
        timer -= Time.deltaTime;
        if (changingGearUp)
        {
            currentGear = 1;
            car.isChangingGearUp = true;
            if (timer < 0f)
            {
                currentGear = _currentGear + 1;
                gearChangeSound.Play();
                car.isChangingGearUp = false;
                changingGearUp = false;
            }
        }
        if (changingGearDown)
        {
            currentGear = 1;
            car.isChangingGearDown = true;
            if (timer < 0f)
            {
                currentGear = _currentGear - 1;
                gearChangeSound.Play();
                car.isChangingGearDown = false;
                changingGearDown = false;
            }
        }
        if (changingGearUpSequential)
        {
            currentGear = 1;
            car.isChangingGearUpSequential = true;
            if (timer < 0f)
            {
                currentGear = expectedGear;
                _currentGear = currentGear;
                gearChangeSound.Play();
                car.isChangingGearUpSequential = false;
                changingGearUpSequential = false;
            }
        }
        if (changingGearDownSequential)
        {
            currentGear = 1;
            car.isChangingGearDownSequential = true;
            if (timer < 0f)
            {
                currentGear = expectedGear;
                _currentGear = currentGear;
                gearChangeSound.Play();
                car.isChangingGearDownSequential = false;
                changingGearDownSequential = false;
            }
        }


        
    }
}
