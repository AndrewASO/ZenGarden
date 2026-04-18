using UnityEngine;
using ithappy.Animals_FREE;

public class AnimalRoamer : MonoBehaviour {

    public Transform areaCenter;
    public float areaRadius = 5f;

    public float minWaitTime = 1f;
    public float maxWaitTime = 5f;
    public bool runSometimes = false;

    CreatureMover mover;
    Vector3 targetPos;
    float waitTimer = 0f;
    bool waiting = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        mover = GetComponent<CreatureMover>();

        targetPos = transform.position;
        waitTimer = Random.Range(minWaitTime, maxWaitTime);
    }

    // Update is called once per frame
    void Update() {
        if(mover == null || areaCenter == null) return;

        if(waiting) {
            waitTimer -= Time.deltaTime;
            //Telling animal to stand still
            mover.SetInput(Vector2.zero, transform.position + transform.forward, false, false);

            if(waitTimer <= 0f) {
                targetPos = GetRandomPoint();
                waiting = false;
            }
            return;
        }

        //Calculating dir to target as a Vector2(x, z)
        Vector3 dir = targetPos - transform.position;
        dir.y = 0f;
        float dist = dir.magnitude;

        if(dist < 0.3f) {
            waiting = true;
            waitTimer = Random.Range(minWaitTime, maxWaitTime);
            return;
        }

        Vector2 axis = new Vector2(dir.normalized.x, dir.normalized.z);
        bool shouldRun = runSometimes && Random.value > 0.7f;

        //Handing off movement, rotation and animation to CreatureMover
        mover.SetInput(axis, targetPos, shouldRun, false);
    }

    Vector3 GetRandomPoint() {
        Vector2 rand = Random.insideUnitCircle * areaRadius;
        Vector3 pt = areaCenter.position + new Vector3(rand.x, 0f, rand.y);

        //Keeping the animal on the ground
        if(Physics.Raycast(pt + Vector3.up * 2f, Vector3.down, out RaycastHit hit, 5f) )
            pt.y = hit.point.y;
        return pt;
    }

    
    void OnDrawGizmosSelected() {
        if(areaCenter == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(areaCenter.position, areaRadius);
    }
    
}
