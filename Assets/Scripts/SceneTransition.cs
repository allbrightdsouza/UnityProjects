using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public string sceneToLoad;
    public Vector2 playerPosition;
    public Vector2 playerDirection;
    public Vector2 camOffset;
    public VectorValue playerStorage;
    public VectorValue playerDirStorage;
    public VectorValue camOffsetStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1.5f);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            playerDirStorage.initialValue = playerDirection;
            camOffsetStorage.initialValue = camOffset;
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);

        yield return new WaitForSeconds(fadeWait);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public IEnumerator FadeCoAlt()
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncOperation.allowSceneActivation = false;
        yield return new WaitForSeconds(fadeWait);
        asyncOperation.allowSceneActivation = true;
    }
    

}