using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Vector2 turn;
    [SerializeField]
    [Range(0f, 20f)]
    float sensitivityx;
    // Update is called once per frame
    [SerializeField]
    GameObject obj;
    public SimpleSampleCharacterControl store;
    void Start()
    {
        store = GameObject.Find("Player").GetComponent<SimpleSampleCharacterControl>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        transform.position = obj.transform.position;
        transform.position += new Vector3(0, 1f);
        
            turn.x += sensitivityx * Input.GetAxis("Mouse X");

            transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        
  
    }
}