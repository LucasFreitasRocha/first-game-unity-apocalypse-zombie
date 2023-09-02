using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0f;
    public LayerMask MaskFloor;
    public GameObject TextGameOver;
    public bool Alive = true;
    private Vector3 direction;
    private Rigidbody rigidPlayer;
    private Animator animatorPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        int randomTyper = Random.Range(1, 23);
        transform.GetChild(randomTyper).gameObject.SetActive(true);
        rigidPlayer = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");
        direction = new Vector3(eixoX, 0, eixoZ);

        if (Input.GetKey(KeyCode.LeftShift) && (eixoX != 0 || eixoZ != 0))
        {
            speed = 10;
        }
        else if (eixoX != 0 || eixoZ != 0)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
        }
        animatorPlayer.SetFloat("speedAnimator", speed);
        if(!Alive && Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("game");
        }
    }
    void FixedUpdate()
    {
        
        rigidPlayer.MovePosition(rigidPlayer.position + (direction * Time.deltaTime * speed));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impact;
        if (Physics.Raycast(ray, out impact, 100, MaskFloor))
        {
            Vector3 playerAimingPosition = impact.point - transform.position;
            playerAimingPosition.y = transform.position.y;

            Quaternion newRotation = Quaternion.LookRotation(playerAimingPosition);
            rigidPlayer.MoveRotation(newRotation);
            // telestransporte : bugado...
            // if(Input.GetButton("Fire2")){
            //     rigidPlayer.MovePosition(rigidPlayer.position +  playerAimingPosition);
            // }
        }
    }
}
