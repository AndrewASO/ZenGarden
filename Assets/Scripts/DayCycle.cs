using UnityEngine;

public class DayCycle : MonoBehaviour {

    public Material sunrise;
    public Material day;
    public Material sunset;


    public float totalDuration = 360f;  //6 Minutes

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

        if (t < 0.333f) {
            // Sunrise phase (0 to 2 min)
            float phase = t / 0.333f;
            RenderSettings.skybox = sunrise;
            RenderSettings.ambientLight = Color.Lerp(sunriseAmbient, sunriseAmbient, phase);
        } 
        else if (t < 0.666f) {
            // Day phase (2 to 4 min)
            float phase = (t - 0.333f) / 0.333f;
            RenderSettings.skybox = day;
            RenderSettings.ambientLight = Color.Lerp(sunriseAmbient, dayAmbient, phase);
        } 
        else {
            // Sunset phase (4 to 6 min)
            float phase = (t - 0.666f) / 0.333f;
            RenderSettings.skybox = sunset;
            RenderSettings.ambientLight = Color.Lerp(dayAmbient, sunsetAmbient, phase);
        }
        DynamicGI.UpdateEnvironment();
    }
}
