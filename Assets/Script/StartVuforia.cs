using UnityEngine;
using Vuforia;
using System.Collections;

public class StartVuforia : MonoBehaviour
{
    public GameObject uiCanvas;

    private bool vuforiaReady = false;

    void Start()
    {
        Debug.Log("🚀 Menunggu Vuforia siap...");
        // Saat Vuforia siap, panggil OnVuforiaInitialized
        VuforiaApplication.Instance.OnVuforiaInitialized += OnVuforiaInitialized;
    }

    void OnVuforiaInitialized(VuforiaInitError error)
    {
        if (error == VuforiaInitError.NONE)
        {
            vuforiaReady = true;
            Debug.Log("✅ Vuforia berhasil diinisialisasi!");
            // Matikan dulu supaya kamera belum aktif
            VuforiaBehaviour.Instance.enabled = false;
            Debug.Log("🧩 Vuforia dimatikan sampai tombol Mulai diklik.");
        }
        else
        {
            Debug.LogError("❌ Gagal inisialisasi Vuforia: " + error.ToString());
        }
    }

    public void OnStartButton()
    {
        Debug.Log("▶️ Tombol Mulai ditekan!");

        if (uiCanvas != null)
            uiCanvas.SetActive(false);

        if (vuforiaReady && VuforiaBehaviour.Instance != null)
        {
            VuforiaBehaviour.Instance.enabled = true;
            Debug.Log("🎥 Vuforia berhasil diaktifkan!");
        }
        else
        {
            Debug.LogWarning("⚠️ Vuforia belum siap, tidak bisa diaktifkan.");
        }
    }
}
