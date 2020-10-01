using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider m_LoadingBar;
    [SerializeField] private Text m_LoadingValueText;
    [SerializeField] private Text m_LoadedText;
    private AsyncOperation m_asyncOperation;
    private string m_SceneToLoad;

    public void Start()
    {
        m_LoadedText.text = "";
        //Retrieve name of scene to load
        m_SceneToLoad = GameManager.Instance.SceneName;
        System.GC.Collect();
        if (!m_SceneToLoad.Equals(""))
        {
            m_asyncOperation = SceneManager.LoadSceneAsync(m_SceneToLoad, LoadSceneMode.Single);
            //stop the scene from loading right away
            m_asyncOperation.allowSceneActivation = false;
        }
    }

    public void Update()
    {
        if(m_LoadingBar)
        {
            m_LoadingBar.value = m_asyncOperation.progress + 0.1f;
        }
        if(m_LoadingValueText)
        {
            m_LoadingValueText.text = ((m_asyncOperation.progress + 0.1f) * 100) + "%";
        }
        if (m_asyncOperation.progress >= 0.89f)
        {
            m_LoadedText.text = "Press any key to continue...";

            if (Input.anyKeyDown)
            {
                Cursor.visible = false;
                m_asyncOperation.allowSceneActivation = true;
            }
        }
    }
}
