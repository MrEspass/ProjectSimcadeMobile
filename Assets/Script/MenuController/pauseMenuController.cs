using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class pauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject GameplayHUDCanvas;
    public GameObject GearboxGameobject;
    public GameObject EngineGameobject;
    public GameObject CarSFXGameobject;
    public bool isPaused;
    [SerializeField] private bool _isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        GearboxGameobject = GameObject.FindGameObjectWithTag("Gearbox");
        EngineGameobject = GameObject.FindGameObjectWithTag("Engine");
        CarSFXGameobject = GameObject.FindGameObjectWithTag("CarSFX");
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) 
        {
            Pause();
        }
        else 
        {
            Continue();
        }
    }

    public void PauseBool() 
    {
        //if (ctx.performed)
        //{
            isPaused = !isPaused;
        //}
    }

    public void ContinueBool() 
    {
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        GameplayHUDCanvas.SetActive(false);
        GearboxGameobject.SetActive(false);
        EngineGameobject.SetActive(false);
        CarSFXGameobject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        pauseMenuCanvas.SetActive(false);
        GameplayHUDCanvas.SetActive(true);
        GearboxGameobject.SetActive(true);
        EngineGameobject.SetActive(true);
        CarSFXGameobject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ExitButton(string scene) 
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
