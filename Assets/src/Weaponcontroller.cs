using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bullet;
    public GameObject spawnBullet;
    bool canShoot = false;
    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetButton("Fire1") && (!canShoot))
        {
            StartCoroutine(FireShot());
        }

    }

    IEnumerator FireShot()
    {
        canShoot = true;
        Instantiate(Bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        canShoot = false;

    }
}
