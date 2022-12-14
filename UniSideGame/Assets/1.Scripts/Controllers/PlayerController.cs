using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;


    Animator animator;
    public string stopAnime = "PlayerStop";
    public string moveAnime = "PlayerMove";
    public string jumoAnime = "Jump";
    public string goalAnime = "PlayerClear";
    public string deadAnime = "PlayerOver";

    string nowAnime = "";
    string oldAnime = "";

    public static string gameState = "playing";
    public int score = 0;

    bool isMoving = false;

    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = stopAnime;

        gameState = "playing";

    }

    void Update()
    {
        if (gameState != "playing")
        {
            return;
        }

        if (isMoving == false)
        {
            axisH = Input.GetAxisRaw("Horizontal");
        }
        axisH = Input.GetAxisRaw("Horizontal");

        if (axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        

    }

    void FixedUpdate()
    {
        if (gameState != "playing")
        {
            return;
        }

        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);

        if (onGround || axisH != 0)
        {
            rbody.velocity = new Vector2(speed * axisH, rbody.velocity.y);
        }
        if (onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0, jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            goJump = false;
        }

        rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);

        if (onGround)
        {
            if (axisH == 0)
            {
                nowAnime = stopAnime;
            }
            else
            {
                nowAnime = moveAnime;
            }
        }
        else
        {
            nowAnime = jumoAnime;
        }

        if (nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead")
        {
            Dead();
        }
        else if (collision.gameObject.tag == "ScoreItem")
        {
            ItemData item = collision.gameObject.GetComponent<ItemData>();
            score = item.value;
            Destroy(collision.gameObject);
        }
    }

    public void Jump()
    {
        goJump = true;
    }

    public void Goal()
    {
        animator.Play(goalAnime);
        gameState = "gameclear";
        GameStop();
    }

    public void Dead()
    {
        animator.Play(deadAnime);
        gameState = "gameover";
        GameStop();
        GetComponent<CapsuleCollider2D>().enabled = false;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    public void GameStop()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = new Vector2(0, 0);
    }

    public void SetAxis(float h, float v)
    {
        axisH = h;
        if (axisH == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }

}
