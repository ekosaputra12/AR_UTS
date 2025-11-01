using UnityEngine;

public class PlayAudioButton : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySound()
    {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}
