using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    public string obj;
    public string enemy;
    public SimpleSampleCharacterControl store;
    public ObjectCollection hp;
    private void Awake()
    {
        store = GameObject.Find("Player").GetComponent<SimpleSampleCharacterControl>();
        hp = GameObject.Find("Player").GetComponent<ObjectCollection>();
    }
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
                        Enemy.look--;
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
            if (store.nCar && collision.gameObject.CompareTag("Car") && !obj.Equals("Player"))
            {
                int num = (int)Random.Range(0, 10);
                if (num < 3)
                {
                    hp.Health--;
                    if (hp.Health < 0)
                    {
                        hp.Health = 0;
                    }
                }
            }
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
 
}
