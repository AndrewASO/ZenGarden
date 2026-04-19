using UnityEngine;

public class AnimalSnack : MonoBehaviour {

    public AudioClip crunchSound;
    public ParticleSystem eatEffect;    //Will work on this later possibly

    AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEat(Collider other) {
        if(other.CompareTag("Snack") ) {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(crunchSound);
            if(eatEffect != null) {     //Setting this for a null check right now because I don't have it implemented currently
                eatEffect.Play();
            }
        }
    }
}
