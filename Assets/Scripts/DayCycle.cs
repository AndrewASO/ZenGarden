using UnityEngine;

public class DayCycle : MonoBehaviour {

    public Material sunrise;
    public Material day;
    public Material sunset;


    public float totalDuration = 120f;  //2 Minutes

    public Color sunriseAmbient = new Color(1f, 0.6f, 0.3f);
    public Color dayAmbient = new Color(1f, 1f, 1f);
    public Color sunsetAmbient = new Color(1f, 0.4f, 0.2f);

    float timer;

    void Start() {
        timer = 0f;
        RenderSettings.skybox = sunrise;
        RenderSettings.ambientLight = sunriseAmbient;
    }

    void Update() {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / totalDuration);

        //Sunrise --> Day (0 - 0.5)
        //Day --> Sunset (0.5 - 1)
        if(t < 0.5) {
            float phase = t / 0.5f;
            RenderSettings.skybox = phase < 0.5f ? sunrise : day;
            RenderSettings.ambientLight = Color.Lerp(sunriseAmbient, dayAmbient, phase);
        }
        else {
            float phase = (t - 0.5f) / 0.5f;
            RenderSettings.skybox = phase < 0.5f ? day : sunset;
            RenderSettings.ambientLight = Color.Lerp(dayAmbient, sunsetAmbient, phase);
        }
        DynamicGI.UpdateEnvironment();
    }
}
