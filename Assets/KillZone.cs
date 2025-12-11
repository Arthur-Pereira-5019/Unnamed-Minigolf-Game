using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public class ColliderOnTriggerMove : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.gm)
            {
                GameManager.gm.finalizarPartida();
                other.transform.position = GameManager.gm.lastPos;
            }
    }
}

}
