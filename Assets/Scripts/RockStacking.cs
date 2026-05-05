using UnityEngine;
using Oculus.Interaction;

public class RockStacking : MonoBehaviour {

    SnapInteractable snapInteractable;
    SnapInteractor snapInteractor;

    public int height = 1;
    public int maxHeight = 3;

    void Awake() {
        snapInteractable = GetComponentInChildren<SnapInteractable>();
        snapInteractor = GetComponentInChildren<SnapInteractor>();

        //snapInteractable.WhenSelectingInteractorAdded += SnapOn;
        snapInteractor.WhenInteractableSelected.Action += SnapOn;
    }

    void SnapOn(SnapInteractable bottomSnap) {
        RockStacking bottomRock = bottomSnap.GetComponentInParent<RockStacking>();

        if(!bottomRock || bottomRock == this)
            return;

        height = bottomRock.height + 1;

        if(height >= maxHeight) {
            
        }
    }

    void DisableSnap() {
        snapInteractable.enabled = false;
    }
    
}
