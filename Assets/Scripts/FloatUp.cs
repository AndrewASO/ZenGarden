using UnityEngine;

public class FloatUp : MonoBehaviour {

    private bool toFloat = false;
    [SerializeField] float floatUpSpd = 1.0f;


    void Update(){
        if(toFloat){
            BeginFloatingUp();
        }
    }

    public void ActiveFloat(){
        toFloat = true;
    }

    void BeginFloatingUp(){
        transform.position += new Vector3(0, floatUpSpd * Time.deltaTime, 0);
    }
}
