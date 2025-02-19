using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    Animator animator = null;
    Rigidbody2D _rigidbody = null;
    SpriteRenderer _spriteRenderer = null;

    public float jumpForce = 6f;  // 점프할 때 드는 힘
    public float forwardSpeed = 3f;       // 앞으로 나가는 속도  
    public bool isDead = false;    // 죽었는지 여부
    bool isJump = false;  // 점프 중이냐 여부
    float jumpCooldown = 0f;  // 점프 쿨다운 시간
    Vector2 movementDirection = Vector2.zero; 

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }

        if (_spriteRenderer == null)
        {
            Debug.LogError("Not Founded SpriteRenderer");
        }
    }

    void Update()
    {
        if (isDead)  // 죽었을 때
        {
            // gameManager.ReStartGame(); 
        }
        else   // 살았을 때
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
            }
        }

        float horizontal = Input.GetAxisRaw("Horizontal");  // 왼쪽을 누르면 -1, 오른쪽을 누르면 1
        if (horizontal == 1)
        {
            _spriteRenderer.flipX = false;
        }
        else if (horizontal == -1)
        {
            _spriteRenderer.flipX = true;
        }

        float vertical = Input.GetAxisRaw("Vertical");  // 아래를 누르면 -1, 위를 누르면 1
        movementDirection = new Vector2(horizontal, vertical).normalized;  
        _rigidbody.velocity = movementDirection * forwardSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // enemy tag가 달렸는지 체크하고 gameObject를 가져와라.
        {
            gameManager.GameOver();  // 부딪힌 게임 오브젝트를 부숴라.
        }
    }




}
