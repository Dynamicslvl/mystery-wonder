using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAlignWhenStart : MonoBehaviour
{
    private void Start() {
        AutoAlign();
        WallExistance();
    }
    public void AutoAlign(){
        Vector2 pos = transform.position;
        int xi = Mathf.RoundToInt(pos.x - 0.5f);
        int yi = Mathf.RoundToInt(pos.y - 0.5f);
        Vector3 alignPos = new Vector3(xi + 0.5f, yi + 0.5f, 0);
        transform.position = alignPos;
    }
    private void WallExistance(){
        if(CompareTag("Wall")){
            GridManager.instance.SetExist(GridManager.instance.GridPosition(transform.position), true);
        }
    }

}
