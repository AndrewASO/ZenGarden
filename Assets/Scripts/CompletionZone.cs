using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionZone : MonoBehaviour {

    public ZenProgress.Zone zoneType;
    public string completionSceneName = "Message";
    //public string mainSceneName = "ZenGarden";

    public void Complete() {
        ZenProgress.MarkComplete(zoneType);
        ZenCamera.Instance.LoadCompletion();
    }
}
