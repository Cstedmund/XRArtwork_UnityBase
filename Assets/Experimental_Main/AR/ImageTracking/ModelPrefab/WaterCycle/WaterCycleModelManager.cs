using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCycleModelManager : MonoBehaviour {
    // Start is called before the first frame update

    [SerializeField]
    protected GameObject[] State1,State2;

    public void ChangeStage(int currentState) {
        switch (currentState) {
            case 1:
                ToggleGameObjestList(State1, false);
                ToggleGameObjestList(State2, true);
                foreach(GameObject obj in State1) {
                    if (obj.name == "Particle System") {
                        obj.GetComponent<ParticleSystem>().Play();
                    }
                }
                break;
            case 2:
                ToggleGameObjestList(State2, false);
                ToggleGameObjestList(State1, true);
                break;
            default:
                Debug.LogWarning("State Cannot be null");
                break;
        }
    }
    private void ToggleGameObjestList(GameObject[] objs, bool trigger) {
        foreach (GameObject obj in objs) {
            if (obj != null && (obj.active != trigger)) {
                obj.SetActive(trigger);
            }
        }
    }
}
