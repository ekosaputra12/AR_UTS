using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Vuforia;

public class ARWordToggleOnDetect : MonoBehaviour
{
    [Header("Kata dalam Bahasa Indonesia")]
    public string indoWord = "MEJA";
    public AudioClip indoAudio;  // 🎵 audio Indonesia

    [Header("Kata dalam Bahasa Inggris")]
    public string englishWord = "TABLE";
    public AudioClip englishAudio;  // 🎵 audio Inggris

    [Header("Referensi UI")]
    public TextMeshProUGUI textDisplay;
    public Button toggleButton;
    public GameObject uiContainer;

    private AudioSource audioSource;
    private bool showingEnglish = false;
    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        audioSource = gameObject.AddComponent<AudioSource>();

        if (textDisplay != null)
            textDisplay.text = indoWord;

        if (toggleButton != null)
            toggleButton.onClick.AddListener(ToggleLanguage);
    }

    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (uiContainer != null)
            uiContainer.SetActive(status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED);
    }

    void ToggleLanguage()
    {
        showingEnglish = !showingEnglish;

        if (textDisplay != null)
            textDisplay.text = showingEnglish ? englishWord : indoWord;

        PlaySound();
    }

    void PlaySound()
    {
        if (audioSource == null) return;

        AudioClip clip = showingEnglish ? englishAudio : indoAudio;

        if (clip != null)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clip);
        }
    }
}
