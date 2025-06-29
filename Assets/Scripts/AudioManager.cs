using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private SongData currentSong;
    private int noteIndex = 0;
    private AudioSource audioSource;
    [SerializeField] private Sprite onSound;
    [SerializeField] private Sprite offSound;
    [SerializeField] private Image sfxSprite;
    [SerializeField] private AudioMixer audiomixer;
    private bool isSFXOn = true;
    public SongData CurrentSong => currentSong;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SoundConfig.CheckSFX(audiomixer, onSound, offSound, isSFXOn, sfxSprite);
    }

    public void PlayNote()
    {
        audioSource.PlayOneShot(currentSong.Notes[noteIndex]);
        noteIndex++;
        if (noteIndex >= currentSong.Notes.Length) noteIndex = 0;
    }

    public void SetSFX()
    {
        isSFXOn = !isSFXOn;
        SoundConfig.SetSFX(isSFXOn, audiomixer, sfxSprite, onSound, offSound);
    }
}
