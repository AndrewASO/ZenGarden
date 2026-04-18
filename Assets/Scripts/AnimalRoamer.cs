using UnityEngine;

public class AnimalRoamer : MonoBehaviour {

    public Transform areaCenter;
    public float areaRadius = 5f;

    public float moveSpd = 1f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 5f;

    Animator anim;
    Vector3 targetPos;
    float waitTimer = 0f;
    bool waiting = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        anim = GetComponentInChildren<Animator>();
        if(anim != null) {
            anim.applyRootMotion = false;
        }
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (waiting) {
            waitTimer -= Time.deltaTime;
            anim.SetFloat("Speed", 0f);
            if(waitTimer <= 0f) {
                targetPos = GetRandomPoint();
                waiting = false;
            }
            return;
        }

        //Moving target forward
        Vector3 dir = (targetPos - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpd * Time.deltaTime);


        //Facing forward direction
        if(dir != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 5f);
        }

        anim.SetFloat("Speed", moveSpd);

        //If arrived at destination
        if(Vector3.Distance(transform.position, targetPos) < 0.2f) {
            waiting = true;
            waitTimer = Random.Range(minWaitTime, maxWaitTime);
        }
    }

    Vector3 GetRandomPoint() {
        Vector2 rand = Random.insideUnitCircle * areaRadius;
        Vector3 pt = areaCenter.position + new Vector3(rand.x, 0f, rand.y);

        //Keeping the animal on the ground
        if(Physics.Raycast(pt + Vector3.up * 2f, Vector3.down, out RaycastHit hit, 5f) )
            pt.y = hit.point.y;
        return pt;
    }
}
