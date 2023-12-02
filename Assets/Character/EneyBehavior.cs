
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class EneyBehavior : MonoBehaviour
{
    private int Life { get; set; }
    private float Origine_x { get; set; }
    private Vector2 Thrust{ get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Life = 1;
        Origine_x = transform.position.x;
        Thrust = new Vector2(-5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Life == 0) {
            Destroy(this);
            return;
        }
        if (transform.position.x <= Origine_x - 5.0)
            Thrust = new Vector2(-5, 0);
        if (transform.position.x >= Origine_x + 5.0)
            Thrust = new Vector2(5, 0);
        gameObject.GetComponent<Rigidbody2D>().AddForce(Thrust);
    }

    void OnCollisionEnter2D(Collider2D collider)
    {
        string tag = collider.GameObject().tag;
        if (tag == "Player") {
            this.Life -= 1;
        }
    }
}
