using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class carPicker : MonoBehaviour
{
    [Header("Render Texture")]
    [SerializeField]Shader transparentShader;
    RawImage renderTexture;

    [Header("UI Car Selector")]
    public RectTransform levelPagesRect;
    public Text carNameText;
    public float targetPosX;
    private float _targetPosX;
    public Transform layerView;
    public GameObject itemPrefab;

    [Header("UI SFX")]
    [SerializeField] AudioSource enterSFX;
    [SerializeField] AudioSource backSFX;
    [SerializeField] AudioSource selectSFX;

    [Header("Camera Manager")]
    Transform carPickerRotation;
    GameObject cameraPosition;
    float colorFader = 1f;
    float zPos = 0f;

    [Header("Car List")]
    public CarData[] carDataList;
    public int carInteger = 0;
    public string carDataStringName;

    [Header("Input Debugging")]
    [SerializeField]Vector2 navigateInput;

    public void NavigateInput(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        navigateInput = ctx.ReadValue<Vector2>();
        if (navigateInput.x > 0 && carInteger < carDataList.Length - 1) { carInteger++; Refresh(); selectSFX.Play(); }
        if (navigateInput.x < 0 && carInteger > 0) { carInteger--; Refresh(); selectSFX.Play(); }
    }

    public void NavigateInputTouchScreen(int coba) 
    {
        if(coba == 1 && carInteger < carDataList.Length - 1) { carInteger++; Refresh(); selectSFX.Play(); }
        if(coba == -1 && carInteger > 0) { carInteger--; Refresh(); selectSFX.Play(); }
    }

    private void Awake()
    {
        GameObject _renderTexture = GameObject.Find("RawImage");
        renderTexture = _renderTexture.GetComponent<RawImage>();
        carPickerRotation = GetComponent<Transform>();
        cameraPosition = GameObject.Find("Main Camera");
        carInteger = Mathf.Clamp(carInteger, 0, carDataList.Length - 1);
        carDataStringName = carDataList[carInteger].name;
        PlayerPrefs.SetInt("carPointer", 0);
        PlayerPrefs.SetString("carDataName", carDataStringName);
        carInteger = PlayerPrefs.GetInt("carPointer");
        Vector3 newPos = Vector3.zero;
        Quaternion newRot = Quaternion.identity;
        GameObject childObject = Instantiate(carDataList[carInteger].carPrefab, newPos, newRot);
        childObject.transform.SetParent(carPickerRotation);
        SetLayerRecursively(childObject, 3);
        childObject.transform.localPosition = newPos;
        childObject.transform.localRotation = newRot;
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
        
        colorFader = Mathf.Lerp(colorFader, 0f, Time.deltaTime * 1f);
        zPos = Mathf.Lerp(zPos, 7.5f, Time.deltaTime * 2f);

        renderTexture.color = new Color(1f, 1f, 1f,colorFader);
        Vector3 camPos = new Vector3(0, 1f, zPos);
        cameraPosition.transform.localPosition = camPos;
        carPickerRotation.transform.Rotate(Vector3.up * -20f * Time.deltaTime);
    }

    void Refresh() 
    {
        DeployNewCar();
        colorFader = 1f;
        zPos = 0f;
        carPickerRotation.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        
    }

    void InstatiateCarIconList() 
    {
        for (int i = 0; i < carDataList.Length; i++)
        {
            GameObject imageObj = Instantiate(itemPrefab, layerView);
            Image image = imageObj.GetComponentInChildren<Image>();
            if (image) image.sprite = carDataList[i].carIcon;
        }
    }

    void ReadCarData() 
    {
        carNameText.text = carDataList[carInteger].carBrandName + " " + carDataList[carInteger].carName + " " + carDataList[carInteger].year;
    }

    void DeployNewCar() 
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        carDataStringName = carDataList[carInteger].name;
        PlayerPrefs.SetInt("carPointer", carInteger);
        PlayerPrefs.SetString("carDataName", carDataStringName);
        Vector3 newPos = Vector3.zero;
        Quaternion newRot = Quaternion.identity;
        GameObject childObject = Instantiate(carDataList[carInteger].carPrefab, newPos, newRot);
        childObject.transform.SetParent(carPickerRotation);
        SetLayerRecursively(childObject, 3);
        childObject.transform.localPosition = newPos;
        childObject.transform.localRotation = newRot;
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null) return;

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (child == null) continue;
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }

    void MovePages() 
    {
        _targetPosX = Mathf.Lerp(_targetPosX, targetPosX * carInteger, Time.deltaTime * 10f);
        Vector3 targetPos = new Vector3(_targetPosX, 0f, 0f);
        levelPagesRect.anchoredPosition = targetPos;
    }
}
