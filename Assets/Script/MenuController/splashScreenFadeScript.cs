using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class splashScreenFadeScript : MonoBehaviour
{
    [SerializeField] private GameObject eventSystemGameObject;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private CanvasGroup myUIGroup;

    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;

    [SerializeField] string sceneName;

    public void ShowUI() 
    {
        if (eventSystemGameObject.activeSelf || eventSystem.enabled)
        {
            fadeOut = false;
        }
    }

    public void HideUI(string scene)
    {
        if (eventSystemGameObject.activeSelf || !eventSystem.enabled) 
        {
            fadeOut = true;
            sceneName = scene;
        }
    }

    public void ExitGame() 
    {
        if (eventSystemGameObject.activeSelf || !eventSystem.enabled)
        {
            fadeOut = true;
            Application.Quit();
        }
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        myUIGroup.alpha = 0;
        eventSystem = eventSystemGameObject.GetComponent<EventSystem>();
        fadeIn = true;
        fadeOut = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (fadeIn) 
        {
            if(myUIGroup.alpha < 1) 
            {
                myUIGroup.alpha += Time.deltaTime;
                if(myUIGroup.alpha >= 1) 
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (myUIGroup.alpha > 0)
            {
                myUIGroup.alpha -= Time.deltaTime;
                if (myUIGroup.alpha == 0)
                {
                    fadeOut = false;
                    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
                }
            }
        }

        if(!fadeIn && !fadeOut)
        {
            //eventSystemGameObject.SetActive(true);
            eventSystem.enabled = true;
            if(playerInput != null) 
            {
                playerInput.enabled = true;
            }
        }
        else 
        {
            //eventSystemGameObject.SetActive(false);
            eventSystem.enabled = false;
            if (playerInput != null)
            {
                playerInput.enabled = false;
            }
        }
    }
}
