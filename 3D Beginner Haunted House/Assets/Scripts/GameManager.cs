using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioMixer m_audioMixer;
    [SerializeField] Canvas m_OptionsCanvas;

    private AudioMixerGroup m_Master;
    private AudioMixerGroup m_Music;
    private AudioMixerGroup m_Sfx;


}
