using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
    public GameObject fadeCube;
    public float fadeTime = 2;
    private float timer;
    public string sceneToLoad;
    public bool loadScene = false;
    public bool prevloadScene = false;

    

    private void Start()
    {
    }

    void fadeOut()
    {
        timer = timer - Time.deltaTime;
        Color c = new Color(0, 0, 0, 1 - timer / fadeTime);
        fadeCube.GetComponent<MeshRenderer>().material.color = c;
        if (timer < 0)
        {
            changeToScene();
            loadScene = false;
            fadeCube.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1); ;
        }

    }

    void changeToScene()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    void Update()
    {
        if (prevloadScene != loadScene && loadScene == true)
        {
            if(loadScene == true)
            {
                timer = fadeTime;
            }
            prevloadScene = loadScene; 

        }
        // Press the space key to start coroutine

        if (loadScene)
        {
            fadeOut();      
            // Use a coroutine to load the Scene in the background
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
