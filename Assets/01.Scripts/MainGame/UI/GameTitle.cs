using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTitle : MonoBehaviour
{
    int currentScene = 0;
    // Use this for initialization
    void Start()
    {
        // 현재 Scene 정보를 가지고 온다.
        Scene scene = SceneManager.GetActiveScene();

        // 현재 Scene의 빌드 순서를 가지고 온다.
        currentScene = scene.buildIndex;
        Debug.Log("현재 Scene Number : " + currentScene);


    }

    // Update is called once per frame
    void Update()
    {
        // LoadNextScene();
    }

    public void LoadNextScene()
    {
        //// 현재 Scene 정보를 가지고 온다.
        //Scene scene = SceneManager.GetActiveScene();

        //// 현재 Scene의 빌드 순서를 가지고 온다.
        //int currentScene = scene.buildIndex;
        //Debug.Log("현재 Scene Number : " + currentScene);

        // 현재 Scene 바로 다음 Scene을 가져오기 위해 +1을 해준다.
        int nextScene = currentScene + 1;

        // 다음 Scene을 불러온다.
        SceneManager.LoadScene(nextScene);

        // SceneManager.LoadScene("Scenes/MainGame");
    }
}
