using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{

    // Unity Functions

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float maxHP = MainGameManager.Instance.GetPlayer().GetMaxHP();
        float currentHP = MainGameManager.Instance.GetPlayer().GetCurrentHP();
        float rate = currentHP / maxHP;
        gameObject.GetComponent<Slider>().value = rate;
    }
}