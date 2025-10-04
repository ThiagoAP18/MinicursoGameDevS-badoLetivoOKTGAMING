using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidade;
    private Rigidbody2D rig;
    public float forca_pulo;

    public bool isJumping;

    public bool doubleJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * velocidade;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isJumping == false)
            {
                rig.AddForce(new Vector2(0f, forca_pulo), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else
            {
                if (doubleJump == true)
                {
                    rig.AddForce(new Vector2(0f, forca_pulo), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
