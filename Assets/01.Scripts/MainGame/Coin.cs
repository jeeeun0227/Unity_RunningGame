using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float AddWeight = 0.0f;
    public float AddHP = 0.0f;

    // Unity Functions

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ("Player" == collision.tag)
        {
            MainGameManager.Instance.GetPlayer().AddWeight(AddWeight);
            MainGameManager.Instance.GetPlayer().IncreaseHP(AddHP);
            GameObject.Destroy(gameObject);
        }
    }
}