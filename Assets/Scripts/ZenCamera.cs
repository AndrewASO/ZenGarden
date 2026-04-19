using UnityEngine;
using UnityEngine.SceneManagement;

public class ZenCamera : MonoBehaviour {

    public static ZenCamera Instance;

    public GameObject cameraRig;
    public string completionSceneName = "Message";

    void Awake() {
        Instance = this;
    }

    public void LoadCompletion() {
        //cameraRig.SetActive(false);
        SceneManager.LoadScene(completionSceneName, LoadSceneMode.Additive);
    }

    public void ReturnFromCompletion() {
        SceneManager.UnloadSceneAsync(completionSceneName);
        //cameraRig.SetActive(true);
    }
    
}
