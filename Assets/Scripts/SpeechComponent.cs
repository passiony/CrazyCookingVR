using System.Collections;
using System.Collections.Generic;
using GT.Hotfix;
using UnityEngine;

public class SpeechComponent : MonoBehaviour
{
    public static SpeechComponent Instance;
    private Speech m_Speech;

    void Awake()
    {
        Instance = this;
        m_Speech = new Speech("Yaoyao");
    }

    public void Play(string message)
    {
        m_Speech.Play(message, null);
    }
}