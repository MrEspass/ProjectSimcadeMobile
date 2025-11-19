using UnityEngine;

[CreateAssetMenu(fileName = "NewTrackData", menuName = "Track Game/Track Data")]
public class TrackData : ScriptableObject
{
    [Header("Basic Info")]
    public string trackName;
    public string trackSurName;
    public string trackCountryLocation;
    public int trackLength;
    public int trackCorners;
    public string trackType;

    [Header("Sun Data")]
    public Vector3 sunRotation;

    [Header("Visuals")]
    public Sprite trackIcon;
    public Sprite trackImage;
    public GameObject trackPrefab;
}
