using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    private float fadeDuration = 1f;
    private float displayImageDuration = 1f;
    public GameObject player;

    float m_Timer;

    bool m_IsPlayerAtExit = false;
    bool m_IsPlayerCaught = false;
    bool m_HasAudioPlayed = false;

    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    [SerializeField] private Button resetGameButton;
    [SerializeField] private Button quitToMenuButton;

    public void Start()
    {
        resetGameButton.gameObject.SetActive(false);
        quitToMenuButton.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, exitAudio);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, caughtAudio);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void EndLevel(CanvasGroup imageCanvasGroup, AudioSource audioSource)
    {
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        
        if(m_Timer > fadeDuration + displayImageDuration)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            resetGameButton.gameObject.SetActive(true);
            resetGameButton.enabled = true;
            quitToMenuButton.gameObject.SetActive(true);
            quitToMenuButton.enabled = true;
        }
        
    }

    //To use with the buttons
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ReturnToMainMenu()
    {
        //GameManager.Instance.SceneName = "MainMenu";
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        Cursor.visible = false;
        GameManager.Instance.SceneName = "Game";
        SceneManager.LoadScene("Loading");
    }
}
