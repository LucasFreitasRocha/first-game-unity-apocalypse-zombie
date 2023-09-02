using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   public float speed = 20;

    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
            bulletRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletRigidbody.MovePosition(
            bulletRigidbody.position
            + transform.forward
            * speed
            * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
