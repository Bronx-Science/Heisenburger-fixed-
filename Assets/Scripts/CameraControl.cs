using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Vector2 turn;
    [SerializeField]
    [Range(0f, 20f)]
    float sensitivityx;
    [SerializeField]
    [Range(0f, 20f)]
    public float sensitivityy;
    // Update is called once per frame
    [SerializeField]
    GameObject obj;
    public SimpleSampleCharacterControl store;
    public GameObject car;
    void Start()
    {
        store = GameObject.Find("Player").GetComponent<SimpleSampleCharacterControl>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        
        
            
            turn.x += sensitivityx * Input.GetAxis("Mouse X");
            turn.y += sensitivityy * Input.GetAxis("Mouse Y");

            transform.localRotation = Quaternion.Euler(turn.y, turn.x, 0);
        if (!store.nCar)
        {
            transform.position = obj.transform.position;
            transform.position += new Vector3(0, 1f);
        }
        else
        {
            transform.position = car.transform.position+new Vector3(0,2,0);
        }
    }
}
