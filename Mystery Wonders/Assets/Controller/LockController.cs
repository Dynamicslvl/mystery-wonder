using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    private bool destroyed = false;
    private void Update() {
        Vector2Int lockGridPos = GridManager.instance.GridPosition(transform.position);
        if(IsNearByPlayer() && KeyManager.instance.keys > 0 || destroyed){
            ChangeAlpha(0.5f);
            GridManager.instance.SetExist(lockGridPos, false);
        } else {
            ChangeAlpha(1);
            GridManager.instance.SetExist(lockGridPos, true);
        }
    }
    public bool IsNearByPlayer(){
        Vector3 playerPos = PlayerController.instance.transform.position;
        Vector3 lockPos = transform.position;
        if(GridManager.instance.GridPosition(playerPos).x == GridManager.instance.GridPosition(lockPos).x){
            if(Mathf.Abs(GridManager.instance.GridPosition(playerPos).y - GridManager.instance.GridPosition(lockPos).y) <= 1){
                //Debug.Log("Ahhh");
                return true;
            }
        }
        if(GridManager.instance.GridPosition(playerPos).y == GridManager.instance.GridPosition(lockPos).y){
            if(Mathf.Abs(GridManager.instance.GridPosition(playerPos).x - GridManager.instance.GridPosition(lockPos).x) <= 1){
                //Debug.Log("Ahhh");
                return true;
            }
        }
        return false;
    }
    private void ChangeAlpha(float value){
        var image = GetComponent<SpriteRenderer>();
        Color tmp = image.color;
        tmp.a = value;
        image.color = tmp;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !destroyed){
            destroyed = true;
            KeyManager.instance.keys--;
            Invoke("DestroySelf", 0.2f);
        }
    }
    private void DestroySelf(){
        Destroy(gameObject);
    }
}
