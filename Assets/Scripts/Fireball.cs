using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float ProjectileSpeed = 10;
    public float ProjectileLifetime = 3f;
    public GameObject Projectile;
    public bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb2;
        rb2 = GetComponent<Rigidbody2D>();
        if(isFacingRight)
        {
            rb2.velocity = Vector2.right * ProjectileSpeed;
        } else
        {
            rb2.velocity = Vector2.left * ProjectileSpeed;
        }
        
        Destroy(Projectile, ProjectileLifetime);
    }
}