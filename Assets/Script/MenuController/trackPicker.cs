using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class trackPicker : MonoBehaviour
{
    [Header("UI Track Selector")]
    public RectTransform levelPagesRect;
    public Text trackNameText;
    public float targetPosX;
    private float _targetPosX;
    public Transform layerView;
    public Image backgroundImage;
    public GameObject itemPrefab;

    [Header("UI SFX")]
    [SerializeField] AudioSource enterSFX;
    [SerializeField] AudioSource backSFX;
    [SerializeField] AudioSource selectSFX;

    [Header("Track List")]
    public TrackData[] trackDataList;
    public int trackInteger = 0;
    public string trackDataStringName;

    [Header("Input Debugging")]
    [SerializeField]Vector2 navigateInput;

    public void NavigateInput(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        navigateInput = ctx.ReadValue<Vector2>();
        if (navigateInput.x > 0 && trackInteger < trackDataList.Length - 1) { trackInteger++; Refresh(); selectSFX.Play(); }
        if (navigateInput.x < 0 && trackInteger > 0) { trackInteger--; Refresh(); selectSFX.Play(); }
    }

    public void NavigateInputTouchScreen(int coba) 
    {
        if(coba == 1 && trackInteger < trackDataList.Length - 1) { trackInteger++; Refresh(); selectSFX.Play(); }
        if(coba == -1 && trackInteger > 0) { trackInteger--; Refresh(); selectSFX.Play(); }
    }

    private void Awake()
    {
        GameObject _renderTexture = GameObject.Find("RawImage");
        trackInteger = Mathf.Clamp(trackInteger, 0, trackDataList.Length - 1);
        trackDataStringName = trackDataList[trackInteger].name;
        PlayerPrefs.SetInt("trackPointer", 0);
        PlayerPrefs.SetString("trackDataName", trackDataStringName);
        trackInteger = PlayerPrefs.GetInt("trackPointer");
    }

    private void Start()
    {
        InstatiateCarIconList();
    }

    void Update() 
    {
        MovePages();
        ReadCarData();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void Refresh() 
    {
        trackDataStringName = trackDataList[trackInteger].name;
        PlayerPrefs.SetInt("trackPointer", trackInteger);
        PlayerPrefs.SetString("trackDataName", trackDataStringName);
        backgroundImage.sprite = trackDataList[trackInteger].trackImage;
    }

    void InstatiateCarIconList() 
    {
        for (int i = 0; i < trackDataList.Length; i++)
        {
            GameObject imageObj = Instantiate(itemPrefab, layerView);
            Image image = imageObj.GetComponentInChildren<Image>();
            if (image) image.sprite = trackDataList[i].trackIcon;
        }
    }

    void ReadCarData() 
    {
        trackNameText.text = trackDataList[trackInteger].trackName;
    }

    void MovePages() 
    {
        _targetPosX = Mathf.Lerp(_targetPosX, targetPosX * trackInteger, Time.deltaTime * 10f);
        Vector3 targetPos = new Vector3(_targetPosX, 0f, 0f);
        levelPagesRect.anchoredPosition = targetPos;
    }
}
