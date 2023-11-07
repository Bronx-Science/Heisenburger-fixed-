using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    public string obj;
    public string enemy;
    
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(obj)|| collision.gameObject.CompareTag("Projectile"))
        {
            
        }
        else
        {
            if (collision.gameObject.CompareTag(enemy))
            {
                if (enemy.Equals("Enemy")) 
                {

                    collision.gameObject.GetComponent<Enemy>().Health--;
                    if (collision.gameObject.GetComponent<Enemy>().Health <= 0)
                    {
                        Destroy(collision.gameObject);
                        
                    }
                }
                if (enemy.Equals("Player"))
                {
                    collision.gameObject.GetComponent<ObjectCollection>().Health--;
                    if (collision.gameObject.GetComponent<ObjectCollection>().Health <= 0)
                    {

                        collision.gameObject.GetComponent<ObjectCollection>().Health = 0;
                        //Destroy(collision.gameObject);
                    }
                }
            }
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
 
}
