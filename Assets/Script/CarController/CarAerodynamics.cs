using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAerodynamics : MonoBehaviour
{

    public AnimationCurve aeroForceCurve;
    public AnimationCurve aeroDragCurve;
    public int aeroDegrees;
    public float wingSpan;
    public float wingChord;

    public float aeroLift() 
    {
        float aeroLiftStrength = aeroForceCurve.Evaluate(aeroDegrees);

        return aeroLiftStrength / 1f;
    }

    public float aeroDrag()
    {
        float aeroDragStrength = aeroDragCurve.Evaluate(aeroDegrees);
        return aeroDragStrength / 10f;
    }
}
