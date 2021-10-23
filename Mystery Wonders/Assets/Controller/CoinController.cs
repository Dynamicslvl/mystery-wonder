using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    Transform ring1, ring2;
    GameObject target = null;
    bool moveToTarget = false;
    public float spinSpeed = 10;
    private void Start() {
        target = FindObjectOfType<LevelComplete>().gameObject;
        CoinManager.instance.coins++;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        ring1 = transform.GetChild(0);
        ring2 = transform.GetChild(1);

    }
    private void Update() {
        Spin();
        MoveToTarget();
    }
    private void Spin(){
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime/2);
        ring1.Rotate(0, spinSpeed * Time.deltaTime*3, 0);
        ring2.Rotate(spinSpeed * Time.deltaTime*2, 0, 0);
    }
    private void MoveToTarget()
    {
        if (moveToTarget)
        {
            Vector3 diff = target.transform.position - transform.position;
            transform.position = transform.position + diff * Time.deltaTime * 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !moveToTarget){
            GetComponent<SpriteRenderer>().sortingOrder = 10;
            //Destroy(gameObject);
            moveToTarget = true;
        }
        if (other.CompareTag("Target"))
        {
            CoinManager.instance.coins--;
            Destroy(gameObject);
        }
    }
}
