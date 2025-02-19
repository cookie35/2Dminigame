using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    Animator animator = null;
    Rigidbody2D _rigidbody = null;
    SpriteRenderer _spriteRenderer = null;

    public float jumpForce = 6f;  // ������ �� ��� ��
    public float forwardSpeed = 3f;       // ������ ������ �ӵ�  
    public bool isDead = false;    // �׾����� ����
    bool isJump = false;  // ���� ���̳� ����
    float jumpCooldown = 0f;  // ���� ��ٿ� �ð�
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
        if (isDead)  // �׾��� ��
        {
            // gameManager.ReStartGame(); 
        }
        else   // ����� ��
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
            }
        }

        float horizontal = Input.GetAxisRaw("Horizontal");  // ������ ������ -1, �������� ������ 1
        if (horizontal == 1)
        {
            _spriteRenderer.flipX = false;
        }
        else if (horizontal == -1)
        {
            _spriteRenderer.flipX = true;
        }

        float vertical = Input.GetAxisRaw("Vertical");  // �Ʒ��� ������ -1, ���� ������ 1
        movementDirection = new Vector2(horizontal, vertical).normalized;  
        _rigidbody.velocity = movementDirection * forwardSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // enemy tag�� �޷ȴ��� üũ�ϰ� gameObject�� �����Ͷ�.
        {
            gameManager.GameOver();  // �ε��� ���� ������Ʈ�� �ν���.
        }
    }




}
