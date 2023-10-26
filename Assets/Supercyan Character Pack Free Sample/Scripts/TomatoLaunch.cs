using UnityEngine;
using System.Collections;

public class TomatoLaunch : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 10f;
    float loadRate = 0.5f;
    float timeRemaining;
    public float up = 5f;
    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeRemaining <= 0)
        {
            timeRemaining = loadRate;
            ShootProjectile();
            //GetComponent<AudioSource>().Play();
        }
    }
    void ShootProjectile()
    {
        GameObject tomato = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
        tomato.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, up, speed));


        //StartCoroutine(Die(tomato));
    }
    
        /*private IEnumerator Die(GameObject obj)
        {

            yield return new WaitForSeconds(5f);
            Destroy(obj);
        }*/

    }