using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    [SerializeField]
    GameObject obj;
    public SimpleSampleCharacterControl store;
    public CameraControl angle;
    void Start()
    {
        angle = GameObject.Find("Pivot Camera").GetComponent<CameraControl>();
        store = GameObject.Find("Player").GetComponent<SimpleSampleCharacterControl>();
        if (Time.timeScale != 0f) 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
            
    }
    void Update()
    {
        transform.position = obj.transform.position;
        transform.localRotation = Quaternion.Euler(0, angle.turn.x, 0);


    }
}