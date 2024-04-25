using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] playlist;
    public int currentTrackIndex ;
    public bool shuffle = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        PlayCurrentTrack();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    private void PlayCurrentTrack()
    {
        if (playlist.Length > 0)
        {
            audioSource.clip = playlist[currentTrackIndex];
            audioSource.Play();
        }
    }

    private void PlayNextTrack()
    {
        if (shuffle)
        {
            currentTrackIndex = Random.Range(0, playlist.Length);
        }
        else
        {
            currentTrackIndex = (currentTrackIndex + 1) % playlist.Length;
        }

        PlayCurrentTrack();
    }
}
