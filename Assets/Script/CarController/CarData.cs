using UnityEngine;

[CreateAssetMenu(fileName = "NewCarData", menuName = "Car Game/Car Data")]
public class CarData : ScriptableObject
{
    [Header("Basic Info")]
    public string carBrandName;
    public string carName;
    public int year;

    [Header("Performance")]
    public string Power;
    public string Torque;
    public string Gearbox;
    public string Drivetrain;

    [Header("Visuals")]
    public Sprite carIcon;
    public GameObject carPrefab;
}
