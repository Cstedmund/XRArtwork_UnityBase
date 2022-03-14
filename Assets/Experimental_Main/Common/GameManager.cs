using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Start is called before the first frame update
    private static GameManager _instance;
    [SerializeField]
    public bool debugOn;
    [SerializeField]
    private Canvas debugIndicator;

    public static GameManager Instance {
        get { return _instance; }
    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    [SerializeField]
    public Language currentLanguage;
    [SerializeField]
    public BookItem currentBook;
    [HideInInspector]
    [SerializeField]
    public string currentURL,previousScene;

    public enum Book {
        B1,
        B2,
        B3,
        B4,
        B5,
        B6,
        B7,
        B8,
        B9,
        B10,
        B11,
    }
    public enum Language {
        en,
        zh,
    }

    private void Start() {
        Debug.Log(FunctionLibrary.GetCurrentDevice());
    }

    private void Update() {
        if (Input.touchCount == 2 && Input.touchCount < 3) {
            debugOn = false;
            debugIndicator.enabled = false;
        }
        if (Input.touchCount == 3) {
            debugOn = true;
            debugIndicator.enabled = true;
        }
    }

}
