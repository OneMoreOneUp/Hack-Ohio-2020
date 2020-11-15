using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource m_audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        m_audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (m_audioSource.isPlaying) return;
        m_audioSource.Play();
    }

    public void StopMusic()
    {
        m_audioSource.Stop();
    }
}
