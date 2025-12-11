using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour
{
    public static GameManager gm;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(GameManager.gm)
            {
                gm.finalizarPartida();
            }
        }
    }

}
