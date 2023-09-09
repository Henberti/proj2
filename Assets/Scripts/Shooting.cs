using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform roketSpawnPoint;
    public GameObject Rocket;
    public GameObject LongShootRocket;
    public float shootingSpeed = 10f;
    bool canShot = true;
    int longShootRocketBullets = 3;
    bool isLongShoot = false;
    RawImage img;
    InputChannel inputChannel;


    public Texture textureLongBullet, textureBullet;

    private void Start()
    {

        img = GameObject.Find("Bullet Image").GetComponent<RawImage>();
        img.texture = textureBullet;
        var beacon = FindObjectOfType<BeaconScript>();
        inputChannel = beacon.inputChannel;
        inputChannel.shootingEvent += HandleShoot;
        inputChannel.switchAmmoEvent += HandleSwitchAmmo;

    }

    public void HandleShoot(bool value)
    {

        if (canShot)
        {
            if (isLongShoot)
                longShootRocketBullets--;

            var bullet = Instantiate(isLongShoot ? LongShootRocket : Rocket, roketSpawnPoint.position, roketSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = roketSpawnPoint.up * shootingSpeed;
            canShot = false;
            StartCoroutine(shootDelay());
        }

    }
    public void HandleSwitchAmmo(bool value)
    {
        if(longShootRocketBullets > 0)
            isLongShoot = !isLongShoot;
    }




    private void Update()
    {
        if (isLongShoot)
        {
            img.texture = textureLongBullet;
        }
        else
        {
            img.texture = textureBullet;
        }

        if (longShootRocketBullets <= 0)
            isLongShoot = false;

    }

    IEnumerator shootDelay()
    {
        yield return new WaitForSeconds(1.5f);
        canShot = true;

    }
    private void OnDestroy()
    {
        inputChannel.shootingEvent -= HandleShoot;
        inputChannel.switchAmmoEvent -= HandleSwitchAmmo;
    }
  


}