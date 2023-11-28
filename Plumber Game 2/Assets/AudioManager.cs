using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;

    AudioSource _audioSource;

    void Awake()
    {
        if (instance == null)
        {
           
            instance = this;

            // Make sure this object persists between scenes
            DontDestroyOnLoad(gameObject);

            // Set up your AudioSource
            _audioSource = GetComponent<AudioSource>();
            // Add your specific audio setup here
        }
        else
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Play the audio when the scene starts
        _audioSource.Play();
    }

    // You might want to expose a method to control playback externally
    public void PlayAudio()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }
}
