using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ARGlobalManager : MonoBehaviour
{
    public static ARGlobalManager Instance;

    [Header("UI Elements")]
    public GameObject panelInfo;
    public TextMeshProUGUI txtVocabName;
    public Button btnSound;
    public Button btnArti;
    public GameObject panelArti;
    public TextMeshProUGUI txtArti;

    private AudioSource audioSource;
    private TargetInfo currentTarget;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        panelInfo.SetActive(false);
        panelArti.SetActive(false);

        btnSound.onClick.AddListener(PlaySound);
        btnArti.onClick.AddListener(ShowMeaning);
    }

    public void TargetFound(TargetInfo target)
    {
        currentTarget = target;
        txtVocabName.text = target.vocabName;
        panelInfo.SetActive(true);
        Debug.Log($"🟢 Target {target.vocabName} ditemukan!");
    }

    public void TargetLost(TargetInfo target)
    {
        if (currentTarget == target)
        {
            panelInfo.SetActive(false);
            panelArti.SetActive(false);
            currentTarget = null;
            Debug.Log($"🔴 Target {target.vocabName} hilang!");
        }
    }

    void PlaySound()
    {
        if (currentTarget != null && audioSource && currentTarget.vocabSound)
            audioSource.PlayOneShot(currentTarget.vocabSound);
    }

    void ShowMeaning()
    {
        if (currentTarget != null)
        {
            txtArti.text = $"{currentTarget.vocabName} = {currentTarget.vocabMeaning}";
            panelArti.SetActive(true);
        }
    }
}
