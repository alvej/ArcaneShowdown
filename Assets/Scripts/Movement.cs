using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode rightKeybind = KeyCode.D;
    public KeyCode leftKeybind = KeyCode.A;
    public KeyCode jumpKeybind = KeyCode.W;
    public KeyCode crouchKeybind = KeyCode.S;

    public float jumpPower = 300f;

    public float speed = 5f;


    public bool onGround = false;

    private int onGroundCount = 0;

    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.freezeRotation = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Ground"))
        {
            onGroundCount++;
            onGround = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Ground"))
        {
            if(onGroundCount > 0)
            {
                onGroundCount--;
            }
            if(onGroundCount == 0)
            {
                onGround = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Animator animator = GetComponent<Animator>();


        if (Input.GetKey(rightKeybind))
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Idle", false);
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            if (!facingRight)
            {
                Flip();
            }
        }
        if (Input.GetKey(leftKeybind))
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Idle", false);
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            if (facingRight)
            {
                Flip();
            }
        }
        if (Input.GetKey(jumpKeybind) && onGround)
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Idle", false);
            onGround = false;
            rigidbody.AddForce(new Vector2(0, jumpPower));
        }

        if(!Input.GetKey(rightKeybind) && !Input.GetKey(leftKeybind) && !Input.GetKey(jumpKeybind))
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }


    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
