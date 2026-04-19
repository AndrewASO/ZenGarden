using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MessageUI : MonoBehaviour {

    public TextMeshProUGUI zoneMessageText;
    public TextMeshProUGUI zenLevelText;
    public TextMeshProUGUI progressText;

    public float returnTime = 5f;
    public string mainSceneName = "ZenGarden";


    void Awake() {
        zoneMessageText.text = ZenProgress.GetZoneMessage();
        zenLevelText.text = ZenProgress.GetZenLevel();
        progressText.text = ZenProgress.CompletedCount() + " / 4 areas completed";
    }

    void Start() {
        Invoke(nameof(ReturnToMain), returnTime);
    }

    void ReturnToMain() {
        ZenCamera.Instance.ReturnFromCompletion();
    }

}
