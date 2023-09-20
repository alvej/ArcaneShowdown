using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode rightKeybind = KeyCode.D;
    public KeyCode leftKeybind = KeyCode.A;
    public KeyCode jumpKeybind = KeyCode.W;
    public KeyCode crouchKeybind = KeyCode.S;

    public bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.freezeRotation = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();


        if (Input.GetKey(rightKeybind))
        {
            rigidbody.AddForce(new Vector2(10, 0));
        }
        if (Input.GetKey(leftKeybind))
        {
            rigidbody.AddForce(new Vector2(-10, 0));
        }
        if (Input.GetKey(jumpKeybind) && onGround)
        {
            onGround = false;
            rigidbody.AddForce(new Vector2(0, 300));
        }


    }
}