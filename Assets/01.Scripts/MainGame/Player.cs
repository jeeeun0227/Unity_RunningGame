using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCharacter PlayerView;

    // Unity Functions

    // Use this for initialization
    void Start()
    {
        _currentWeight = _startWeight;
        _currentHP = _maxHP;

        _distance = 0.0f;

        PlayerView.Init(this);
        // ChangeState(eState.IDLE);        // 임시 주석
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            PlayerView.Jump(_jumpSpeed);
        }

        // 가속도
        if (eState.RUN == _state)
        {

            UpdateDistance();

            if (_velocity.x < _maxSpeed)
            {
                _velocity.x += _addSpeed;
            }
            else
            {
                _velocity.x = _maxSpeed;
            }
            UpdateWeight();
            UpdateHP();

            UpdateSpeedByWeight();
        }
    }

    void UpdateDistance()
    {
        float deltaDistance = _velocity.x * Time.deltaTime;
        _distance += deltaDistance;
        if (_maxDistance <= _distance)
        {
            ChangeState(eState.COMPLETE);
        }
    }

    void UpdateWeight()
    {
        _currentWeight -= _decreaseWeight / 3;

        if (_currentWeight < _minWeight)
            _currentWeight = _minWeight;

        if (_maxWeight < _currentWeight)
            _currentWeight = _maxWeight;
    }

    void UpdateHP()
    {
        _currentHP -= _decreaseHP;

        if (_currentHP < 0)
        {
            _currentHP = 0;

            ChangeState(eState.DEATH);
        }
        // Debug.Log("HP " + _currentHP);       // 유니티 디버그 상태에서 확인이 가능하다.
    }

    void UpdateSpeedByWeight()
    {
        if (120.0f < _currentWeight)
        {
            _maxSpeed = 7.0f;
        }
        else if (110.0f < _currentWeight)
        {
            _maxSpeed = 9.0f;
        }
        else if (100.0f < _currentWeight)
        {
            _maxSpeed = 11.0f;
        }
        else if (90.0f < _currentWeight)
        {
            _maxSpeed = 13.0f;
        }
        else if (80.0f < _currentWeight)
        {
            _maxSpeed = 15.0f;
        }
        else if (70.0f < _currentWeight)
        {
            _maxSpeed = 17.0f;
        }
        else if (60.0f < _currentWeight)
        {
            _maxSpeed = 19.0f;
        }
        else if (50.0f < _currentWeight)
        {
            _maxSpeed = 21.0f;
        }
    }

    // 캐릭터의 상태 구현
    public enum eState
    {
        IDLE,
        RUN,
        DEATH,
        COMPLETE,
    }

    eState _state = eState.IDLE;

    // HP

    float _maxHP = 100.0f;
    float _decreaseHP = 0.1f;
    float _currentHP = 0.0f;

    public void IncreaseHP(float addHP)
    {
        _currentHP += addHP;
        if (_maxHP < _currentHP)
        {
            _currentHP = _maxHP;
        }
    }

    public float GetMaxHP()
    {
        return _maxHP;
    }

    public float GetCurrentHP()
    {
        return _currentHP;
    }

    // Weight

    float _maxWeight = 120.0f;
    float _minWeight = 50.0f;
    float _startWeight = 100.0f;
    float _decreaseWeight = 0.1f;
    float _goalWeight = 60.0f;
    float _currentWeight = 0.0f;

    public void AddWeight(float addWeight)
    {
        _currentWeight += addWeight;

        if (_currentWeight < _minWeight)
            _currentWeight = _minWeight;

        if (_maxWeight < _currentWeight)
            _currentWeight = _maxWeight;
    }

    public float GetMaxWeight()
    {
        return _maxWeight;
    }

    public float GetMinWeight()
    {
        return _minWeight;
    }

    public float GetCurrentWeight()
    {
        return _currentWeight;
    }

    public float GetGoalWeight()
    {
        return _goalWeight;
    }

    // Speed

    float _maxSpeed = 15.0f;
    float _addSpeed = 0.1f;
    float _jumpSpeed = 21.0f;

    public float GetMaxSpeed()
    {
        return _maxSpeed;
    }

    public float GetSpeed()
    {
        return _velocity.x;
    }

    // Distance

    float _maxDistance = 500.0f;        // 목표 거리
    float _distance = 0.0f;         // 현재 거리

    public float GetMaxDistance()
    {
        return _maxDistance;
    }

    public float GetDistance()
    {
        return _distance;
    }

    // State

    public void ChangeState(eState state)
    {
        _state = state;

        switch (state)
        {
            case eState.IDLE:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.IdleState();
                break;
            case eState.RUN:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.RunState();
                break;
            case eState.DEATH:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.IdleState();
                break;
            case eState.COMPLETE:
                _velocity.x = 0.0f;
                _velocity.y = 0.0f;
                PlayerView.IdleState();
                break;
        }
    }

    public bool IsDead()
    {
        if (eState.DEATH == _state)
            return true;
        return false;
    }

    public bool IsComplete()
    {
        if (eState.COMPLETE == _state)
            return true;
        return false;
    }

    public bool IsSuccess()
    {
        float deltaWeight = _goalWeight - _currentWeight;
        float deltaWeightOffset = Mathf.Abs(deltaWeight);

        if (deltaWeightOffset < 3.0f)
            return true;
        return false;
    }

    public bool CanDoubleJump()
    {
        if (MainGameManager.Instance.GetPlayer().GetCurrentWeight() < 80.0f)
            return true;
        return false;
    }

    // Move

    Vector2 _velocity = Vector2.zero;

    public Vector2 GetVelocity()
    {
        return _velocity;
    }

    public void ResetSpeed()
    {
        _velocity.x = 0.0f;
    }
}