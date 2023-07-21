using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject minimapPlayer;
    void Update()
    {
        int playerPosX = Mathf.FloorToInt(player.transform.position.x);
        int playerPosY = Mathf.FloorToInt(player.transform.position.y);
        minimapPlayer.transform.localPosition = new Vector3(playerPosX, playerPosY, 0);
    }  
}