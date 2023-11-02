using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDrive : MonoBehaviour
{
    // Start is called before the first frame update
    public SimpleSampleCharacterControl carstore;
    private float m_currentV = 0;
    private float m_currentH = 0;
    private float m_interpolation = 10f;
    private float mult = 20f;
    private Vector3 rot;
    private Vector3 m_currentDirection = Vector3.zero;
    public Rigidbody rb;
    void Start()
    {
        carstore = GameObject.Find("Player").GetComponent<SimpleSampleCharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!carstore.nCar)
        {
            rb.AddForce(-rb.velocity * 0.6f, ForceMode.Acceleration);
        }
        else
        {
            float v = Input.GetAxis("Vertical");
            if (v < 0)
            {
                v *= 0.25f;
            }
            float h = Input.GetAxis("Horizontal");
            m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
            m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);
            rot.y += 0.6f*m_currentH;
            transform.localRotation= Quaternion.Euler(0, rot.y, 0);
            Vector3 direction = mult * transform.forward * m_currentV;
            float directionLength = direction.magnitude;
            direction.y = 0;
            direction = direction.normalized * directionLength;

            if (direction != Vector3.zero)
            {
                m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);
                //transform.position += m_currentDirection * 2 * Time.deltaTime;
                rb.velocity = m_currentDirection*1.3f+new Vector3(0,rb.velocity.y,0);
                if (rb.velocity.y > 0)
                {
                    rb.velocity -= new Vector3(0,2f,0);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.AddForce(-rb.velocity*10f, ForceMode.Acceleration);

    }
}
