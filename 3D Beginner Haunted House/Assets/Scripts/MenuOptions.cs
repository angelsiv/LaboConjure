using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private Canvas m_OptionsCanvas;

    [SerializeField] private Slider m_SliderMaster;
    [SerializeField] private Slider m_SliderMusic;
    [SerializeField] private Slider m_SliderSfx;

    [SerializeField] private AudioMixerGroup m_MasterMixerGroup;
    [SerializeField] private AudioMixerGroup m_MusicMixerGroup;
    [SerializeField] private AudioMixerGroup m_SfxMixerGroup;

    private GameManager GameManager;

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        if(m_OptionsCanvas)
        {
            m_OptionsCanvas.gameObject.SetActive(false);
            m_OptionsCanvas.enabled = false;
        }

        //Retrieve stored audio volume
        if(m_SliderMaster)
        {
            m_SliderMaster.value = GameManager.Instance.MasterVolumeValue;
        }
        if(m_SliderMusic)
        {
            m_SliderMusic.value = GameManager.Instance.MusicVolumeValue;
        }
        if(m_SliderSfx)
        {
            m_SliderSfx.value = GameManager.Instance.SfxVolumeValue;
        }

        //Set retrieved volumes
        if(m_MasterMixerGroup)
        {
            m_MasterMixerGroup.audioMixer.SetFloat("MasterVolume", m_SliderMaster.value);
        }
        if(m_MusicMixerGroup)
        {
            m_MusicMixerGroup.audioMixer.SetFloat("MusicVolume", m_SliderMusic.value);
        }
        if(m_SfxMixerGroup)
        {
            m_SfxMixerGroup.audioMixer.SetFloat("SfxVolume", m_SliderSfx.value);
        }
    }

    public void DisplayOptionsCanvas()
    {
        if(m_OptionsCanvas)
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

    public void SetMasterVolumeSlider()
    {
        m_MasterMixerGroup.audioMixer.SetFloat("MasterVolume", m_SliderMaster.value);
        GameManager.Instance.MasterVolumeValue = m_SliderMaster.value;
    }

    public void SetMusicVolumeSlider()
    {
        m_MusicMixerGroup.audioMixer.SetFloat("MusicVolume", m_SliderMusic.value);
        GameManager.Instance.MusicVolumeValue = m_SliderMusic.value;
    }

    public void SetSfxVolumeSlider()
    {
        m_SfxMixerGroup.audioMixer.SetFloat("SfxVolume", m_SliderSfx.value);
        GameManager.Instance.SfxVolumeValue = m_SliderSfx.value;
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
