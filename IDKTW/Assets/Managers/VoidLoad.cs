using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidLoad : MonoBehaviour
{
    SceneManagement sm;

    [SerializeField] string nameOfNextScene = "MainMenu";
    [SerializeField] float timeToLoad = 2f;

    void Awake() {
        sm = GameObject.Find("EventSystem").GetComponent<SceneManagement>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(LoadInAMoment());
    }

    IEnumerator LoadInAMoment() {
        yield return new WaitForSeconds(timeToLoad);
        sm.LoadScene(nameOfNextScene);
    }
}
