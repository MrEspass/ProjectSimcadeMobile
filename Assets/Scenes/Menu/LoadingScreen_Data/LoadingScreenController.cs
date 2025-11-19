using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour
{
    public Image loadingCircle;
    private float loadingRotZ = 0f;
    private CanvasGroup myUIGroup;
    [SerializeField] private GameObject cameraBlackBackground;
    [SerializeField] private GameObject eventSystemGameObject;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    public bool loadingCheck = false;

    // Start is called before the first frame update
    private void Awake()
    {
        myUIGroup = GetComponent<CanvasGroup>();
        myUIGroup.alpha = 0;
        fadeIn = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        loadingCircleManager();
        UIFadeManager();
    }

    void loadingCircleManager() 
    {
        loadingRotZ = -10f;
        loadingCircle.transform.Rotate(new Vector3(0f, 0f, loadingRotZ));
    }

    void UIFadeManager() 
    {
        if (fadeIn)
        {
            eventSystemGameObject.SetActive(false);
            cameraBlackBackground.SetActive(true);
            if (myUIGroup.alpha < 1)
            {
                myUIGroup.alpha += Time.deltaTime / 2f;
                if (myUIGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            eventSystemGameObject.SetActive(false);
            cameraBlackBackground.SetActive(false);
            if (myUIGroup.alpha > 0)
            {
                myUIGroup.alpha -= Time.deltaTime * 2f;
                if (myUIGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }

        if (!fadeIn && !fadeOut)
        {
            eventSystemGameObject.SetActive(true);
        }

        if (loadingCheck) 
        {
            if (!fadeIn) 
            {
                HideUI();
                loadingCheck = false;
            }
        }
    }

    public void ShowUI()
    {
        fadeIn = true;
    }

    public void HideUI()
    {
        fadeOut = true;
    }
}
