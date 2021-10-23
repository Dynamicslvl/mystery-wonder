using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;
    public int keys;
    private void Awake() {
        if(instance != null){
            Destroy(gameObject);
        } else {
            instance = this;
        }
        keys = 0;
    }
    private void Update() {
        
    }
}
