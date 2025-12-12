using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{

    public float speed;
    private float x, z;
    public float maxX, maxZ;
    private Vector2 pi;
    private Vector2 pf;
    float velocidade;
    LineRenderer lr;
    Rigidbody rb;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
        if (lr == null)
        {
            Debug.Log("Adicionar LineRenderer");
        }
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        velocidade = rb.velocity.magnitude;
        if (velocidade < 0.1f)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            lr.enabled = true;
        }
        else
        {
            if(velocidade > 1f)
            {
                if (GameManager.gm)
                {
                    
                }
            }
            lr.enabled = false;
        }

        if (lr.enabled)
        {
                lr.SetPosition(0, transform.position);

            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase == TouchPhase.Began)
                {
                    pi = t.position;
                    pf = t.position;
                    x = 0;
                    z = 0;
                    lr.enabled = true;
                    lr.SetPosition(0, transform.position);
                    lr.SetPosition(1, transform.position);
                }
                if (t.phase == TouchPhase.Moved)
                {
                    pf = t.position;
                    x = (pi.x - pf.x) * 0.03f;
                    z = (pi.y - pf.y) * 0.03f;

                    x = Mathf.Clamp(x, -maxX, maxX);
                    z = Mathf.Clamp(z, -maxZ, maxZ);
                    lr.SetPosition(1, new Vector3(
                        transform.position.x + x,
                        transform.position.y,
                        transform.position.z + z));
                }
                if (t.phase == TouchPhase.Ended)
                {
                    GetComponent<Rigidbody>().AddForce(
                        new Vector3(speed * x, 0, speed * z),
                        ForceMode.Impulse);
                    lr.enabled = false;
                    if (GameManager.gm)
                        GameManager.gm.tacada();
                }

            }
        }
    }
}
