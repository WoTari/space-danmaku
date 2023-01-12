using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Example : MonoBehaviour
    {
        float speed = 5;
        
        void Update()
        {
            if(player == player[1])
                if(Input.GetKey(KeyCode.A))
                transform.Translate (Vector3.left * speed * Time.deltaTime);
                if(Input.GetKey(KeyCode.D))
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if(Input.GetKey (KeyCode.W))
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                if(Input.GetKey (KeyCode.S))
                transform.Translate (Vector3.down * speed * Time.deltaTime);
            if(player == player[2])
                if(Input.GetKey(KeyCode.LeftArrow))
                    transform.Translate (Vector3.left * speed * Time.deltaTime);
                if(Input.GetKey(KeyCode.RightArrow))
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                if(Input.GetKey (KeyCode.UpArrow))
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                if(Input.GetKey (KeyCode.DownArrow))
                    transform.Translate (Vector3.down * speed * Time.deltaTime);
        }
    }