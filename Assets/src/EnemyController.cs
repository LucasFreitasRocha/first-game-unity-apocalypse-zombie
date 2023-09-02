using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
   public float speed = 5f;
    public GameObject player;
    private Rigidbody zombieRigidBody;
    private Animator zombieAnimator;

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        int randomTyper = Random.Range(1, 28);
        transform.GetChild(randomTyper).gameObject.SetActive(true);
        zombieAnimator = GetComponent<Animator>();
        zombieRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;
        float distance = Vector3.Distance(player.transform.position, transform.position);
        Quaternion rotation = Quaternion.LookRotation(direction);
        zombieRigidBody.MoveRotation(rotation);
        if (distance > 2.5)
        {
            zombieRigidBody.MovePosition(zombieRigidBody.position + direction.normalized * speed * Time.deltaTime);
            zombieAnimator.SetBool("attacking", false);
        }
        else
        {
            zombieAnimator.SetBool("attacking", true);
        }

    }

    void AttackedPlayer()
    {
        this.playerController.takeDamage(Random.Range(1,10));
    }
}
