using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public static class SoundConfig 
{
    public static void SetMusic(bool isMusicOn, AudioMixer audiomixer, Image musicSprite, Sprite onSound, Sprite offSound)
    {
        audiomixer.SetFloat("MusicVolume", isMusicOn ? 0f : -80f);
        musicSprite.sprite = isMusicOn ? onSound : offSound;
    }
    public static void SetSFX(bool isSFXOn, AudioMixer audiomixer, Image sfxSprite, Sprite onSound, Sprite offSound)
    {
        audiomixer.SetFloat("SFXVolume", isSFXOn ? 0f : -80f);
        sfxSprite.sprite = isSFXOn ? onSound : offSound;
    }

    public static void SetSound(bool isMusicOn, AudioMixer audiomixer, Image musicSprite, Sprite onSound, Sprite offSound, bool isSFXOn, Image sfxSprite)
    {
        float musicVolume;
        audiomixer.GetFloat("MusicVolume", out musicVolume);
        isMusicOn = musicVolume > -79f;
        musicSprite.sprite = isMusicOn ? onSound : offSound;

        float sfxVolume;
        audiomixer.GetFloat("SFXVolume", out sfxVolume);
        isSFXOn = sfxVolume > -79f;
        sfxSprite.sprite = isSFXOn ? onSound : offSound;
    }

    public static void CheckSFX( AudioMixer audiomixer, Sprite onSound, Sprite offSound, bool isSFXOn, Image sfxSprite)
    {
        float sfxVolume;
        audiomixer.GetFloat("SFXVolume", out sfxVolume);
        isSFXOn = sfxVolume > -79f;
        sfxSprite.sprite = isSFXOn ? onSound : offSound;
    }
}
