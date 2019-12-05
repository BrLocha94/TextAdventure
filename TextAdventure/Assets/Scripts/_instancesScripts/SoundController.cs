using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource sourceBackground;
    [SerializeField]
    private AudioSource sourceSfx;

    [SerializeField]
    private AudioClip[] backgroundAudios;

    [SerializeField]
    private AudioClip[] sfxAudios;

    bool is_enabled = true;

    #region INSTANCE

    private static SoundController _instance;
    public static SoundController instance()
    {
        if (_instance != null)
            return _instance;

        _instance = GameObject.FindObjectOfType<SoundController>();

        if(_instance == null)
        {
            GameObject instanceResource = Resources.Load("SoundController") as GameObject;
            if (instanceResource != null)
            {
                GameObject instanceObject = Instantiate(instanceResource);
                _instance = instanceObject.GetComponent<SoundController>();
                DontDestroyOnLoad(instanceObject);
            }
            else
                Debug.Log("Failed to load SoundController resource ");
        }

        return _instance;
    }

    #endregion

    public void PlayOpenBackground()
    {
        _instance.sourceBackground.clip = backgroundAudios[0];

        _instance.sourceBackground.Play();
    }

    public void PlayGameBackground()
    {
        _instance.sourceBackground.clip = backgroundAudios[1];

        _instance.sourceBackground.Play();
    }

    public void PlayButtonSFX()
    {
        _instance.sourceSfx.clip = sfxAudios[0];

        _instance.sourceSfx.Play();
    }

    #region Gets and Sets

    public void setEnabled(bool value)
    {
        _instance.is_enabled = value;

        if (_instance.is_enabled)
            Debug.Log("Turned sound ON");
        else
            Debug.Log("Turned sound OFF");
    }

    public bool getEnabled()
    {
        return _instance.is_enabled;
    }

    #endregion
}
