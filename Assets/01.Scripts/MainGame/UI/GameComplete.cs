using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour
{
    public Text GameCompleteText;

    // Use this for initialization
    void Start()
    {
        GameCompleteText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MainGameManager.Instance.GetPlayer().IsSuccess())
        {
            GameCompleteText.text = "SUCCESS";
        }
        else
        {
            GameCompleteText.text = "FAIL";
        }

        if (MainGameManager.Instance.GetPlayer().IsComplete())
        {
            GameCompleteText.gameObject.SetActive(true);
        }
    }
}
