using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private SongData currentSong;
    private int noteIndex = 0;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayNote()
    {
        audioSource.PlayOneShot(currentSong.Notes[noteIndex]);
        noteIndex++;
        if (noteIndex >= currentSong.Notes.Length) noteIndex = 0;
    }
}
