using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{
    [SerializeField] private Sprite onSound;
    [SerializeField] private Sprite offSound;
    [SerializeField] private Image musicSprite;
    [SerializeField] private Image sfxSprite;
    [SerializeField] private AudioMixer audiomixer;
    private bool isMusicOn = true;
    private bool isSFXOn = true;
    private void OnEnable() 
    {
        if(audiomixer == null) return;
        SoundConfig.SetSound(isMusicOn, audiomixer, musicSprite, onSound, offSound, isSFXOn, sfxSprite); 
    }

    public void SetMusic()
    {
        isMusicOn = !isMusicOn;
        SoundConfig.SetMusic(isMusicOn, audiomixer, musicSprite, onSound, offSound);
    }

    public void SetSFX()
    {
        isSFXOn = !isSFXOn;
        SoundConfig.SetSFX(isSFXOn, audiomixer, sfxSprite, onSound, offSound);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //public void Levels()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    //}

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
