using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeARView : MonoBehaviour {
    private TrackedImageManager trackedImageManager;
    private bool trigger;
    [SerializeField]
    private GameObject spawnObject;

    private GameObject spawnedObj;
    // Start is called before the first frame update
    void Start() {
        trigger = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public void ChangeARViewMode() {
        trackedImageManager = FindObjectOfType<TrackedImageManager>();
        if (trackedImageManager == null) {
            return;
        }
        if (!trigger) {
            spawnedObj = Instantiate(spawnObject,transform.position, Quaternion.Euler(0,spawnObject.transform.eulerAngles.y, 0));
            spawnObject.SetActive(false);
            trackedImageManager.enabled = false;
        } else {
            Destroy(spawnedObj);
            spawnObject.SetActive(true);
            trackedImageManager.enabled = true;
        }
        trigger = !trigger;
    }
}
