using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //public ParticleSystem sparkle;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        /* sparkle.Stop();
        sparkle.Clear();
        sparkle.Play();
        sparkle.enableEmission = true; */
        pos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //sparkle.Play();
        this.transform.Rotate(1, 1, 1);
        
        gameObject.transform.position = new Vector3(pos.x, pos.y + .24f * Mathf.Sin(Time.fixedTime), pos.z);
    }

}
