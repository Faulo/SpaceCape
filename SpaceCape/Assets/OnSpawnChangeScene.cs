using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSpawnChangeScene : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    void Start()
    {
        StartCoroutine(ChangeRoutine());
    }

    private IEnumerator ChangeRoutine() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneToLoad);
    }
}
