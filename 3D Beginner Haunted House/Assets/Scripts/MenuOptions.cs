using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer m_audioMixer;
    [SerializeField] private Canvas m_OptionsCanvas;

    private GameManager GameManager;

    private AudioMixerGroup m_Master;
    private AudioMixerGroup m_Music;
    private AudioMixerGroup m_Sfx;

    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();

        m_OptionsCanvas.gameObject.SetActive(false);
        m_OptionsCanvas.enabled = false;
    }

    public void DisplayOptionsCanvas()
    {
        if(m_OptionsCanvas != null)
        {
            if(!m_OptionsCanvas.isActiveAndEnabled)
            {
                m_OptionsCanvas.gameObject.SetActive(true);
                m_OptionsCanvas.enabled = true;
            }
            else
            {
                m_OptionsCanvas.gameObject.SetActive(false);
                m_OptionsCanvas.enabled = false;
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
