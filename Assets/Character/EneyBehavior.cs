
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class EneyBehavior : MonoBehaviour
{
    private int Life { get; set; } = 1;
    private float OriginX { get; set; }
    private Vector2 Thrust { get; set; } = new (-5, 0);

    // Start is called before the first frame update
    void Start()
    {
        OriginX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Life == 0) {
            Destroy(gameObject);
            return;
        }
        if (transform.position.x <= OriginX - 3.0)
            Thrust = new Vector2(5, 0);
        if (transform.position.x >= OriginX + 3.0)
            Thrust = new Vector2(-5, 0);
        GetComponent<Rigidbody2D>().AddForce(Thrust);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) { 
            this.Life -= 1;
        }
    }
}
