using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Vector3 targetPos;
    private bool move = false;
    public float playerSpeed = 20;
    private Vector2Int MoveDirection(){
        Vector3 playerPos = PlayerController.instance.transform.position;
        Vector3 boxPos = transform.position;
        return GridManager.instance.GridPosition(boxPos) - GridManager.instance.GridPosition(playerPos);
    }
    public bool IsNearByPlayer(){
        Vector3 playerPos = PlayerController.instance.transform.position;
        Vector3 boxPos = transform.position;
        if(GridManager.instance.GridPosition(playerPos).x == GridManager.instance.GridPosition(boxPos).x){
            if(Mathf.Abs(GridManager.instance.GridPosition(playerPos).y - GridManager.instance.GridPosition(boxPos).y) <= 1){
                return true;
            }
        }
        if(GridManager.instance.GridPosition(playerPos).y == GridManager.instance.GridPosition(boxPos).y){
            if(Mathf.Abs(GridManager.instance.GridPosition(playerPos).x - GridManager.instance.GridPosition(boxPos).x) <= 1){
                return true;
            }
        }
        return false;
    }
    private void Update() {
        if(IsNearByPlayer() && PlayerController.instance.move == 0){
            if(GridManager.instance.IsAvaiable(GridManager.instance.GridPosition(transform.position) + MoveDirection())){
                if((Input.GetKey(ExpectKey()) || ButtonController.instance.controller == ExpectController()) && !move){
                    //...
                    if ((ExpectKey() == KeyCode.UpArrow || ExpectKey() == KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))) return;
                    if ((ExpectKey() == KeyCode.LeftArrow || ExpectKey() == KeyCode.RightArrow) && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))) return;
                    GridManager.instance.SetExist(GridManager.instance.GridPosition(transform.position), false);
                    targetPos = RealPosition(GridManager.instance.GridPosition(transform.position) + MoveDirection());
                    //Debug.Log(RealPosition(GridManager.instance.GridPosition(transform.position) + MoveDirection()));
                    move = true;
                }
            }
        }
        if(move){
            MoveToTarget();
        }
    }
    public Vector3 RealPosition(Vector2Int tmp){
        float x, y;
        x = tmp.y - 4 + 0.5f;
        y = 7 - tmp.x - 4 + 0.5f;
        return new Vector3(x, y, 0);
    }
    private void MoveToTarget(){
        Vector3 diff = targetPos - transform.position;
        transform.Translate(diff*playerSpeed*Time.deltaTime);
        float distance = Mathf.Sqrt(diff.x*diff.x + diff.y*diff.y);
        if(distance <= 0.01f){
            GetComponent<AutoAlignWhenStart>().AutoAlign();
            GridManager.instance.SetExist(GridManager.instance.GridPosition(transform.position), true);
            move = false;
        }
    }
    private KeyCode ExpectKey(){
        if(MoveDirection() == new Vector2Int(1, 0)){
            return KeyCode.DownArrow;
        }
        if(MoveDirection() == new Vector2Int(0, 1)){
            return KeyCode.RightArrow;
        }
        if(MoveDirection() == new Vector2Int(-1, 0)){
            return KeyCode.UpArrow;
        }
        return KeyCode.LeftArrow;
    }

    private Controller ExpectController()
    {
        if (MoveDirection() == new Vector2Int(1, 0))
        {
            return Controller.Down;
        }
        if (MoveDirection() == new Vector2Int(0, 1))
        {
            return Controller.Right;
        }
        if (MoveDirection() == new Vector2Int(-1, 0))
        {
            return Controller.Up;
        }
        return Controller.Left;
    }
}
