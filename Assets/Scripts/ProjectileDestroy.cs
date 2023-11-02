using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
        else
        {
            /*if (collision.gameObject.CompareTag("Enemy"))
            {


            }*/
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
