using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvasAwal;
    public GameObject canvasAR;
    public GameObject vuforiaBehaviourObject;

    public void StartAR()
    {
        // Matikan UI awal
        canvasAwal.SetActive(false);

        // Aktifkan UI AR
        canvasAR.SetActive(true);

        // Nyalakan Vuforia (kamera AR)
        vuforiaBehaviourObject.SetActive(true);
    }
}
