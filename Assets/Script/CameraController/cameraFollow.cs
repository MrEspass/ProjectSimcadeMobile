using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cameraFollow : MonoBehaviour
{
    public GameObject Car;

    public Transform[] cameraTransform;
    public Camera[] cameraObject;
    public int cameraSelect;

    public cameraMode camMode;

    public enum cameraMode
    {
        precise,
        speedSense
    }
    

    private bool isCameraChanging = false;
    [SerializeField]private Vector2 cameraRotate;
    [SerializeField]private Vector3 rotThirdPerson = Vector3.zero;
    private Vector3 rotFirstPerson = Vector3.zero;
    private Vector3 transformPos;
    private Quaternion transformRot;

    public void changeCameraInput(InputAction.CallbackContext ctx) 
    {
        isCameraChanging = ctx.ReadValueAsButton();
    }

    public void cameraRotationX(InputAction.CallbackContext ctx) 
    {
        cameraRotate.x = ctx.ReadValue<float>();
    }

    public void cameraRotationY(InputAction.CallbackContext ctx)
    {
        cameraRotate.y = ctx.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraSelect = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mainCameraMovement();
        firstPersonCameraMovement();
        changeCamera();
        changeCameraMode();

        switch (cameraSelect) 
        {
            case 0:
                mainCamera();
                break;
            case 1:
                bumperCamera();
                break;
            case 2:
                hoodCamera();
                break;
            case 3:
                firstPersonCamera();
                break;
        }
    }

    int changeCamera() 
    {
        if (isCameraChanging) 
        {
            cameraSelect++;
            isCameraChanging = false;
        }
        if(cameraSelect > cameraTransform.Length - 1) 
        {
            cameraSelect = 0;
        }
        return cameraSelect;
    }

    private void changeCameraMode() 
    {
        switch (camMode)
        {
            case cameraMode.precise:
                cameraObject[0].transform.localPosition = new Vector3(0f, 0f, 0f);
                cameraObject[0].fieldOfView = 55f;
                break;
            case cameraMode.speedSense:
                cameraObject[0].transform.localPosition = new Vector3(0f, 0f, 1.2f);
                cameraObject[0].fieldOfView = 80f;
                break;
        }
    }

    private void mainCameraMovement() 
    {
        float rot = 0f;
        float rotX = cameraRotate.x * 90f;
        float rotY = Mathf.Abs((Mathf.Clamp(cameraRotate.y, -1f, 0f)) * 180f);

        if (cameraRotate.y < 0f)
        {
            rot = 180f - rotX;
        }
        else
        {
            rot = rotX;
        }
        Vector3 newRot = new Vector3(0f, rot, 0f);
        rotThirdPerson = Vector3.Lerp(rotThirdPerson, newRot, Time.deltaTime * 5f);

        if (cameraRotate.x == 0f && cameraRotate.y == 0f) 
        {
            transformPos = Car.transform.position;
            transformRot = Quaternion.Lerp(transformRot, Car.transform.rotation, Time.deltaTime * 5f);

            cameraTransform[0].transform.position = transformPos;
            cameraTransform[0].transform.rotation = transformRot;
        }
        else 
        {
            cameraTransform[0].localEulerAngles = rotThirdPerson;
        }
    }

    private void firstPersonCameraMovement() 
    {
        
        float rotY = cameraRotate.x * 45f;
        float rotX = -cameraRotate.y * 15f;

        Vector3 newRot = new Vector3(rotX, rotY, 0f);
        rotFirstPerson = Vector3.Lerp(rotFirstPerson, newRot, Time.deltaTime * 5f);

        cameraTransform[3].localEulerAngles = rotFirstPerson;
    }

    void mainCamera() 
    {
        cameraObject[0].gameObject.SetActive(true);
        cameraObject[1].gameObject.SetActive(false);
        cameraObject[2].gameObject.SetActive(false);
        cameraObject[3].gameObject.SetActive(false);
    }

    void bumperCamera()
    {
        cameraObject[0].gameObject.SetActive(false);
        cameraObject[1].gameObject.SetActive(true);
        cameraObject[2].gameObject.SetActive(false);
        cameraObject[3].gameObject.SetActive(false);
    }

    void hoodCamera()
    {
        cameraObject[0].gameObject.SetActive(false);
        cameraObject[1].gameObject.SetActive(false);
        cameraObject[2].gameObject.SetActive(true);
        cameraObject[3].gameObject.SetActive(false);
    }

    void firstPersonCamera()
    {
        cameraObject[0].gameObject.SetActive(false);
        cameraObject[1].gameObject.SetActive(false);
        cameraObject[2].gameObject.SetActive(false);
        cameraObject[3].gameObject.SetActive(true);
    }
}
