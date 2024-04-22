using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioSettings audioSettings;

    

    private void Start()
    {
        LoadSettings();
        ApplySettings();
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        audioSettings.masterVolume = volume;
        ApplySettings();
        SaveSettings();
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioSettings.musicVolume = volume;
        ApplySettings();
        SaveSettings();
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioSettings.sfxVolume = volume;
        ApplySettings();
        SaveSettings();
    }

    private void SaveSettings()
    {
        // Guardar los datos de audio en el ScriptableObject
        PlayerPrefs.SetFloat("MasterVolume", audioSettings.masterVolume);
        PlayerPrefs.SetFloat("MusicVolume", audioSettings.musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", audioSettings.sfxVolume);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        // Cargar los datos de audio desde el ScriptableObject
        audioSettings.masterVolume = PlayerPrefs.GetFloat("MasterVolume", audioSettings.masterVolume);
        audioSettings.musicVolume = PlayerPrefs.GetFloat("MusicVolume", audioSettings.musicVolume);
        audioSettings.sfxVolume = PlayerPrefs.GetFloat("SFXVolume", audioSettings.sfxVolume);
    }

    private void ApplySettings()
    {
        // Aplicar los valores de volumen a los canales de audio
        audioMixer.SetFloat("Master", Mathf.Log10(audioSettings.masterVolume) * 20f);
        audioMixer.SetFloat("Music", Mathf.Log10(audioSettings.musicVolume) * 20f);
        audioMixer.SetFloat("SFX", Mathf.Log10(audioSettings.sfxVolume) * 20f);
    }
}