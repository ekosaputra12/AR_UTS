using UnityEngine;
using Vuforia;

public class TargetInfo : MonoBehaviour
{
    public string vocabName;
    public string vocabMeaning;
    public AudioClip vocabSound;

    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();

        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // Saat target ditemukan
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            Debug.Log($"Target {vocabName} ditemukan!");
            ARGlobalManager.Instance.TargetFound(this);
        }
        // Saat target hilang
        else if (status.Status == Status.NO_POSE)
        {
            Debug.Log($"Target {vocabName} hilang!");
            ARGlobalManager.Instance.TargetLost(this);
        }
    }
}
