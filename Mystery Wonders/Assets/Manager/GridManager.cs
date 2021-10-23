using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public bool[,] exist = new bool[8, 8];
    private void Awake() {
        if(instance != null){
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        ClearGrid();
    }
    public void SetExist(Vector2Int tmp, bool value){
        exist[tmp.x, tmp.y] = value;
    }
    public bool GetExist(Vector2Int tmp){
        return exist[tmp.x, tmp.y];
    }
    public bool IsAvaiable(Vector2Int tmp){
        if(tmp.x < 0 || tmp.x >=8 || tmp.y < 0 || tmp.y >= 8){
            return false;
        }
        return !GetExist(tmp);
    }
    public Vector2Int GridPosition(Vector3 tmp){
        Vector2Int ans = new Vector2Int();
        ans.y = (int) (tmp.x - 0.5f) + 4;
        ans.x = (int) 7 - ((int) (tmp.y - 0.5f) + 4);
        return ans;
    }
    public void ClearGrid(){
        for(int i = 0; i<8; i++){
            for(int j = 0; j<8; j++){
                exist[i, j] = false;
            }
        }
    }
}
