using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerMovement : MonoBehaviour
 {
     public GameObject playerPrefab;
     List<GameObject> players = new List<GameObject>();
     float speed = 5;
     
     void Update()
     {
         foreach(GameObject player in GameObject.FindObjectsOfType (typeof(GameObject)))
         {
             if(player.tag == "Player" && !players.Contains(player))
                 players.Add (player);
         }
 
         if(Input.GetKey(KeyCode.A))
             players[0].transform.Translate (Vector3.left * speed * Time.deltaTime);
         if(Input.GetKey(KeyCode.D))
             players[0].transform.Translate(Vector3.right * speed * Time.deltaTime);
         if(Input.GetKey (KeyCode.W))
             players[0].transform.Translate(Vector3.up * speed * Time.deltaTime);
         if(Input.GetKey (KeyCode.S))
             players[0].transform.Translate (Vector3.down * speed * Time.deltaTime);
 
         if(Input.GetKey(KeyCode.LeftArrow))
             players[1].transform.Translate (Vector3.left * speed * Time.deltaTime);
         if(Input.GetKey(KeyCode.RightArrow))
             players[1].transform.Translate(Vector3.right * speed * Time.deltaTime);
         if(Input.GetKey (KeyCode.UpArrow))
             players[1].transform.Translate(Vector3.up * speed * Time.deltaTime);
         if(Input.GetKey (KeyCode.DownArrow))
             players[1].transform.Translate (Vector3.down * speed * Time.deltaTime);
 
 
     }
 }