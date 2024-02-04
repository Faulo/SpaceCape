using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSpawnChangeScene : MonoBehaviour {
    [SerializeField]
    string sceneToLoad;

    protected void Start() {
        StartCoroutine(ChangeRoutine());
    }

    IEnumerator ChangeRoutine() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneToLoad);
    }
}
