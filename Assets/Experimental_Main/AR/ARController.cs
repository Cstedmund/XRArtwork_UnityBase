using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class ARController : MonoBehaviour
{
    RuntimeXRLoaderManager m_runtimeXRLoaderManager;
    ManualXRControl m_manualXRControl;

    [SerializeField][Tooltip("Leave it blank if your scene do not have reset AR function")]
    private GameObject _ARSessionOrigin, _ARSession;

    private bool restart = true;

    void Awake() {
        for (var i = 0; i < this.transform.childCount; i++) {
            if (this.transform.GetChild(i).gameObject.active) {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void Start() {
        m_manualXRControl = GetComponent<ManualXRControl>();
        StartCoroutine(m_manualXRControl.StartXRCoroutine());
        m_runtimeXRLoaderManager = GetComponent<RuntimeXRLoaderManager>();
        m_runtimeXRLoaderManager.StartXR(0);
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene() {
        yield return XRGeneralSettings.Instance.Manager.activeLoaders[1].Deinitialize();
        Debug.Log("StartCoroutine(StartScene())");
        for (var i = 0; i < this.transform.childCount; i++) {
            if (!this.transform.GetChild(i).gameObject.active) {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void ReloadXRSubsystem() {
        if (restart) {
            m_manualXRControl.StopXR();
            if(_ARSession != null && _ARSessionOrigin != null) {
                _ARSession.SetActive(false);
                _ARSessionOrigin.SetActive(false);
            }
            
        } else {
            StartCoroutine(m_manualXRControl.StartXRCoroutine());
            if (_ARSession != null && _ARSessionOrigin != null) {
                _ARSession.SetActive(true);
                _ARSessionOrigin.SetActive(true);
            }
        }
        restart=!restart;
    }
}
