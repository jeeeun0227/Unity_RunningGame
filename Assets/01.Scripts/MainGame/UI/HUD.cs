using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Text WeightText;
    public Text MaxSpeedText;
    public Text WCurrentSpeedText;
    public Text JumpInfoText;
    public Text RemainDistanceInfoText;
    public Text GoalWeightText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WeightText.text = "체중 " + MainGameManager.Instance.GetPlayer().GetCurrentWeight();
        MaxSpeedText.text = "최대속도 " + MainGameManager.Instance.GetPlayer().GetMaxSpeed();
        WCurrentSpeedText.text = "속도 " + MainGameManager.Instance.GetPlayer().GetSpeed();

        if (MainGameManager.Instance.GetPlayer().CanDoubleJump())
        {
            JumpInfoText.text = "Double Jump";
        }
        else
        {
            JumpInfoText.text = "Single Jump";
        }

        float maxDistance = MainGameManager.Instance.GetPlayer().GetMaxDistance();
        float distance = MainGameManager.Instance.GetPlayer().GetDistance();
        int remainDistance = (int)(maxDistance - distance);
        RemainDistanceInfoText.text = "남은 거리 " + remainDistance;

        GoalWeightText.text = "목표 체중 " + MainGameManager.Instance.GetPlayer().GetGoalWeight();
    }
}
