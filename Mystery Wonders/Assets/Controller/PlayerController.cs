using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float playerSpeed = 1;
    public bool canMove;
    public int move = 0;
    private Vector3 targetPos;
    Animator body;
    private void Awake() {
        if(instance != null){
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }
    private void Start()
    {
        canMove = true;
        body = transform.GetChild(0).GetComponent<Animator>();
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
    private void Update() {
        if(move == 0 && canMove){
            var Grid = GridManager.instance;
            Vector2Int gridPos = Grid.GridPosition(transform.position);
            targetPos = transform.position;
            if(Input.GetKey(KeyCode.DownArrow) || ButtonController.instance.controller == Controller.Down){
                if(Grid.IsAvaiable(new Vector2Int(gridPos.x + 1, gridPos.y))){
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    targetPos.y -= 1;
                    move = 1;
                }
            } else
            if(Input.GetKey(KeyCode.UpArrow) || ButtonController.instance.controller == Controller.Up)
            {
                if(Grid.IsAvaiable(new Vector2Int(gridPos.x - 1, gridPos.y))){
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    targetPos.y += 1;
                    move = 2;
                }
            } else
            if(Input.GetKey(KeyCode.RightArrow) || ButtonController.instance.controller == Controller.Right){
                if(Grid.IsAvaiable(new Vector2Int(gridPos.x, gridPos.y + 1))){
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    targetPos.x += 1;
                    move = 3;
                }
            } else
            if(Input.GetKey(KeyCode.LeftArrow) || ButtonController.instance.controller == Controller.Left)
            {
                if(Grid.IsAvaiable(new Vector2Int(gridPos.x, gridPos.y - 1))){
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    targetPos.x -= 1;
                    move = 4;
                }
            }
        } else {
            body.SetBool("IsMove", true);
            MoveToTarget();
        }
    }
    private void MoveToTarget(){
        Vector3 diff = targetPos - transform.position;
        transform.position = transform.position + diff * playerSpeed * Time.deltaTime;
        float distance = Mathf.Sqrt(diff.x*diff.x + diff.y*diff.y);
        if(distance <= 0.01f){
            body.SetBool("IsMove", false);
            GetComponent<AutoAlignWhenStart>().AutoAlign(); 
            move = 0;
        }
    }
}
