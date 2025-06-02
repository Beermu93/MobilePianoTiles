using UnityEngine;

[CreateAssetMenu(fileName = "NewSong", menuName = "Songs/Song")]

public class SongData : ScriptableObject
{
    [SerializeField] private string songName;
    [SerializeField] private AudioClip[] notes;

    public string SongName => songName;
    public AudioClip[] Notes => notes;
}
