using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{

    // Unity Functions

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (false == _isCreate)
            return;

        // 거리 기반으로 변경
        float distance = transform.position.x - _prevBlockObject.transform.position.x;

        if(_intervalDistance <= distance)
        {
            _prevBlockObject = CreateBlock();
        }
    }

    // State

    bool _isCreate = false;

    public void StartCreate()
    {
        _isCreate = true;

        _prevBlockObject = CreateBlock();
    }

    // Blocks

    public GameObject BlockPrefabs;
    public GameObject CoinPrefabs_1;
    public GameObject CoinPrefabs_2;

    GameObject _prevBlockObject;

    // For Test -> public은 test용
    public float _intervalDistance = 10.0f;

    GameObject CreateBlock()
    {
        // Block 1층 생성
        GameObject blockObject = GameObject.Instantiate(BlockPrefabs);
        blockObject.transform.position = transform.position;

        /*
        // Coin 2층 생성
        GameObject coinObject_1 = GameObject.Instantiate(CoinPrefabs_1);
        coinObject_1.transform.position = new Vector2(transform.position.x, 2.0f);     // Second Floor과 같은 숫자여야 한다.

        // Coin 3층 생성
        GameObject coinObject_2 = GameObject.Instantiate(CoinPrefabs_2);
        coinObject_2.transform.position = new Vector2(transform.position.x, 4.5f);
        */

        GameObject coinObject_1;
        GameObject coinObject_2;

        int selectCoin = Random.Range(0, 1000);
        if(selectCoin < 500)
        {
            coinObject_1 = GameObject.Instantiate(CoinPrefabs_1);
            coinObject_2 = GameObject.Instantiate(CoinPrefabs_2);
        }
        else
        {
            coinObject_1 = GameObject.Instantiate(CoinPrefabs_2);
            coinObject_2 = GameObject.Instantiate(CoinPrefabs_1);
        }

        coinObject_1.transform.position = new Vector2(transform.position.x, 0.6f);      // 2층 생성
        coinObject_2.transform.position = new Vector2(transform.position.x, 3.5f);      // 3층 생성

        int randValue = Random.Range(0, 1000);

        if (randValue < 300)
        {
            // Block 2층 생성 & Coin 1층 생성
            blockObject.transform.position = new Vector2(blockObject.transform.position.x, 0.6f);       // 2.0f = 2층의 높이
            coinObject_1.transform.position = transform.position;
        }

        // 임시로 주석처리
        // GameObject.Destroy(blockObject, 6.0f);

        return blockObject;
    }
}
