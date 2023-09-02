using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Zombie;
    bool canSpwan = true;

    public GameObject player;

    public float distanceSpawn = 30f;


    public float spawnTime = 1f;

    // float CountTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (canSpwan && distance < distanceSpawn)
        {
            StartCoroutine(spawnZombie());
        }

    }


    IEnumerator spawnZombie()
    {

        canSpwan = false;
        Instantiate(Zombie, transform.position, transform.rotation);
        yield return new WaitForSeconds(spawnTime);
        canSpwan = true;

    }
}
