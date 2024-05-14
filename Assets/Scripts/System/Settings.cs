using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderEffects;
    [SerializeField] private Toggle toggle;
    [SerializeField] private TMP_Dropdown dropResulution;
    [SerializeField] private TMP_Dropdown dropQuality;

    private InputControl inputControl;
    [SerializeField] private TextMeshProUGUI textInput;

    void Start()
    {
        sliderMaster.value = PlayerPrefs.GetFloat("Master", 0.5f);
        sliderMusic.value = PlayerPrefs.GetFloat("Music", 0.5f);
        sliderEffects.value = PlayerPrefs.GetFloat("Effects", 0.5f);
        toggle.isOn = PlayerPrefs.GetInt("Full") != 1;
        dropResulution.value = PlayerPrefs.GetInt("Resolution");
        dropQuality.value = PlayerPrefs.GetInt("Quality", 2);
    }

    private void Update()
    {
        SetInputSprite();
    }

    public void StartChapter(string nameChapter)
    {
        SceneManager.LoadScene(nameChapter);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetInputSprite()
    {
        if (inputControl == null)
        {
            inputControl = FindObjectOfType<InputControl>();
            return;
        }

        print("vai");

        textInput.text = "para confirmar <size=36><sprite=" + inputControl.IdButton3 + "></size> para voltar <size=36><sprite=" + inputControl.IdButton2 + "></size>";
    }

    public void SetMaster(float volume)
    {
        PlayerPrefs.SetFloat("Master", volume);
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }

    public void SetMusic(float volume)
    {
        PlayerPrefs.SetFloat("Music", volume);
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    public void SetEffects(float volume)
    {
        PlayerPrefs.SetFloat("Effects", volume);
        audioMixer.SetFloat("Effects", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        PlayerPrefs.SetInt("Quality", qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        PlayerPrefs.SetInt("Full", isFullscreen ? 0 : 1);
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolution)
    {

        PlayerPrefs.SetInt("Resolution", resolution);

        switch (resolution)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen = toggle.isOn);
                break;
            case 1:
                Screen.SetResolution(1366, 768, Screen.fullScreen = toggle.isOn);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreen = toggle.isOn);
                break;
            case 3:
                Screen.SetResolution(1024, 768, Screen.fullScreen = toggle.isOn);
                break;
            case 4:
                Screen.SetResolution(800, 480, Screen.fullScreen = toggle.isOn);
                break;
        }
    }
}
