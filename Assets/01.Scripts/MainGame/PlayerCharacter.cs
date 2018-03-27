using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Unity가 제공하는 함수들

    /* 
     C#에서는 함수마다 private / public 을 지정해 주어야 한다.
     아무것도 없으면 private, public 이 있으면 public
     */

    // Use this for initialization      // 오브젝트가 시작될 때 호출 되는 함수
    void Start()
    {

    }

    // Update is called once per frame      // 매 프레임마다 호출되는 함수
    void Update()
    {
        // 바닥에 닿았는지 안닿았는지 체크
        LayerMask groundMark = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D hitFromGround = Physics2D.Raycast(transform.position, Vector3.down, 2.0f, groundMark);
        if (null != hitFromGround.transform)
        {
            if (false == _isGround)
            {
                _isGround = true;
                GetAnimator().SetBool("isGround", _isGround);
            }
        }
        else
        {
            if (true == _isGround)
            {
                _isGround = false;
                GetAnimator().SetBool("isGround", _isGround);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ("Block" == collision.tag)
        {
            _player.ResetSpeed();
        }
    }

    // Init

    Player _player;

    public void Init(Player player)
    {
        _player = player;
    }

    // Move

    bool _isGround = false;
    bool _canDoubleJump = false;

    public void Jump(float _jumpSpeed)
    {
        if (_isGround)
        {
            JumpAction(_jumpSpeed);

            if (MainGameManager.Instance.GetPlayer().GetCurrentWeight() < 80.0f)
                _canDoubleJump = true;
            else
                _canDoubleJump = false;
        }
        else if (true == _canDoubleJump)
        {
            JumpAction(_jumpSpeed);
            _canDoubleJump = false;
        }
    }

    void JumpAction(float _jumpSpeed)
    {
        GetAnimator().SetTrigger("Jump");

        // float jumpSpeed = 10.0f;
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        velocity.y = _jumpSpeed;
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    // 상태

    public void IdleState()
    {
        GetAnimator().SetFloat("Horizontal", 0.0f);
    }

    public void RunState()
    {
        GetAnimator().SetFloat("Horizontal", 1.0f);
    }

    // Animator

    Animator GetAnimator()
    {
        return gameObject.GetComponent<Animator>();
    }
}