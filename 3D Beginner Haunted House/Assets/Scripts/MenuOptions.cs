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
        m_OptionsCanvas.gameObject.SetActive(false);
        m_OptionsCanvas.enabled = false;

        //Retrieve stored audio volume
        m_SliderMaster.value = GameManager.GetMasterVolumeValue();
        m_SliderMusic.value = GameManager.GetMusicSliderValue();
        m_SliderSfx.value = GameManager.GetSfxVolumeValue();

        //Set retrieved volumes
        m_MasterMixerGroup.audioMixer.SetFloat("MasterVolume", m_SliderMaster.value);
        m_MusicMixerGroup.audioMixer.SetFloat("MusicVolume", m_SliderMusic.value);
        m_SfxMixerGroup.audioMixer.SetFloat("SfxVolume", m_SliderSfx.value);
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

    public void SetMasterVolumeSlider()
    {
        m_MasterMixerGroup.audioMixer.SetFloat("MasterVolume", m_SliderMaster.value);
        GameManager.SetMasterVolumeValue(m_SliderMaster.value);
    }

    public void SetMusicVolumeSlider()
    {
        m_MusicMixerGroup.audioMixer.SetFloat("MusicVolume", m_SliderMusic.value);
        GameManager.SetMusicVolumeValue(m_SliderMusic.value);
    }

    public void SetSfxVolumeSlider()
    {
        m_SfxMixerGroup.audioMixer.SetFloat("SfxVolume", m_SliderSfx.value);
        GameManager.SetSfxVolumeValue(m_SliderSfx.value);
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
