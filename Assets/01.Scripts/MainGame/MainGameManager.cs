using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{

    // Singleton

    private static MainGameManager _instance;
    public static MainGameManager Instance
    {
        get
        {
            if(null == _instance)
            {
                _instance = FindObjectOfType<MainGameManager>();
            }
            return _instance;
        }
    }

    // Use this for initialization
    void Start ()
    {
        StartGame();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // GameState

     void StartGame()
    {
        PlayerCharacterScr.ChangeState(Player.eState.RUN);
        BlockCreatorScr.StartCreate();
    }

    // Game objects

    public Player PlayerCharacterScr;
    public BlockCreator BlockCreatorScr;

    public Player GetPlayer()
    {
        return PlayerCharacterScr;
    }
}
