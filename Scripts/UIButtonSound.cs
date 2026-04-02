using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // Ä¶‚·‚éAudioSource
    public AudioClip clickClip;     // ƒ{ƒ^ƒ“‰Ÿ‚µ‚½‚Æ‚«‚Ì‰¹

    public void PlayClickSound()
    {

        if (audioSource != null && clickClip != null)
        {
            audioSource.PlayOneShot(clickClip);
        }
    }
}
