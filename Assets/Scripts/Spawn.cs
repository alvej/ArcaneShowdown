using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public float speed;
    public Transform SpawnAt;
    //speed gör inget ännu
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject fireball = Instantiate(ProjectilePrefab, SpawnAt.position, Quaternion.identity);
            fireball.AddComponent<Fireball>();
            fireball.GetComponent<Fireball>().isFacingRight = SpawnAt.GetComponent<Movement>().facingRight;
        }
    }
}
