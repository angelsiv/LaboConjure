using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float m_MasterSliderValue = 0.0f;
    private float m_MusicSliderValue = 0.0f;
    private float m_SfxSliderValue = 0.0f;

    //store audio slider values
    public void SetMasterVolumeValue(float masterValue)
    {
        m_MasterSliderValue = masterValue;
    }

    public void SetMusicVolumeValue(float musicValue)
    {
        m_MusicSliderValue = musicValue;
    }

    public void SetSfxVolumeValue(float sfxValue)
    {
        m_SfxSliderValue = sfxValue;
    }

    //Retrieve audio slider values
    public float GetMasterVolumeValue()
    {
        return m_MasterSliderValue;
    }

    public float GetMusicSliderValue()
    {
        return m_MusicSliderValue;
    }

    public float GetSfxVolumeValue()
    {
        return m_SfxSliderValue;
    }
}
