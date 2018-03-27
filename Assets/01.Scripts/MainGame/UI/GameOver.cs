using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    // Unity Functions

    public Text GameOverText;

    // Use this for initialization
    void Start()
    {
        GameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MainGameManager.Instance.GetPlayer().IsDead())
        {
            GameOverText.gameObject.SetActive(true);
        }
    }
}
