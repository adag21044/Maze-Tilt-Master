using UnityEngine;

public class MusicManager : MonoBehaviour, IMusicManager
{
    private static MusicManager _instance;

    [SerializeField]
    private AudioClip backgroundMusic; // Reference to the background music clip

    private AudioSource audioSource; // AudioSource to play music

    public static MusicManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("MusicManager is not initialized in the scene!");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Singleton Pattern: Ensure only one instance of MusicManager exists
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }

        InitializeAudioSource(); // Initialize AudioSource for playing music
    }

    // Initialization logic specific to MusicManager
    private void InitializeAudioSource()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // music loops
        audioSource.playOnAwake = false; // Prevent auto-play
        audioSource.volume = 0.5f; // Set default volume
    }

    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
           // audioSource.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume); // Keep volume in the range [0,1]
        }
    }
}
