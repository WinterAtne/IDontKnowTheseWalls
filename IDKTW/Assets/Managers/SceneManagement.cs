using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(this.gameObject);
        }

        Application.targetFrameRate = 60;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            CloseGame();
            Debug.LogWarning("Must be in Build to Close Game");
        }
    }

    public void LoadScene(string sceneName) {
        var scene = SceneManager.LoadSceneAsync(sceneName);
    }

    public void CloseGame() {
        Application.Quit();
    }
}
