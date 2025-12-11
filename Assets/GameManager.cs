using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
        public int par;
    public int tacadas;
    public int pontuacao;

    public Vector3 lastPos;

    public static GameManager gm;

    GameObject player;


    public int mapa;
    void Start()
    {
     player = GameObject.FindWithTag("Player");   
    }

    void Update()
    {
        
    }

    public void tacada() {
        tacadas++;
        pontuacao = tacadas-par;
        lastPos = player.transform.position;
    }

    public void finalizarPartida () {
        if(PlayerPrefs.GetInt("recorde"+mapa, 0) < pontuacao) {
            PlayerPrefs.SetInt("recorde"+mapa, pontuacao);
        }
    }

    public void subirFase()
    {
        int proximo = mapa + 1;
        SceneManager.LoadScene("nivel"+proximo);
    }
}
