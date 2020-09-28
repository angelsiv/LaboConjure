using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Audio variables
    private float m_MasterSliderValue = 0.0f;
    private float m_MusicSliderValue = 0.0f;
    private float m_SfxSliderValue = 0.0f;

    public float MasterVolumeValue { get => m_MasterSliderValue; set => m_MasterSliderValue = value; }
    public float MusicVolumeValue { get => m_MusicSliderValue; set => m_MusicSliderValue = value; }
    public float SfxVolumeValue { get => m_SfxSliderValue; set => m_SfxSliderValue = value; }

    #region GameManager Instance
    private static GameManager m_Instance = null;
    public static GameManager Instance
    {
        get
        {
            if(m_Instance == null)
            {
                m_Instance = FindObjectOfType<GameManager>();
            }
            return m_Instance;
        }
    }
    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
