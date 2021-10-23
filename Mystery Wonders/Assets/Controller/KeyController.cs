using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public float spinSpeed = 10;
    private void Start() {
        //transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }
    private void Update() {
        Spin();
    }
    private void Spin(){
        //transform.Rotate(0, 0, -spinSpeed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            KeyManager.instance.keys++;
            Destroy(gameObject);
        }
    }
}
