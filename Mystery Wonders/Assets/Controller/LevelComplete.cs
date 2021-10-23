using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    int nextScene, maxCoins;
    FillController fill;
    bool change = false;
    private void Start() {
        fill = transform.GetChild(0).GetComponent<FillController>();
        maxCoins = 0;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update() {
        maxCoins = Mathf.Max(maxCoins, CoinManager.instance.coins);
        if(Input.GetKey(KeyCode.R) && !change) ReloadLevel();
        if (maxCoins == 0) return;
        float scale = (maxCoins - CoinManager.instance.coins) / (float)maxCoins;
        fill.targetScale = scale;
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player") && !change && CoinManager.instance.coins == 0 && !change){
            change = true;
            FindObjectOfType<PlayerController>().canMove = false;
            Invoke("NextLevel", 0.5f);
        }
    }
    public void NextLevel(){
        if(nextScene < SceneManager.sceneCountInBuildSettings){
            CoinManager.instance.coins = 0;
            GridManager.instance.ClearGrid();
            SceneManager.LoadScene(nextScene);
        } else {
            Debug.Log("EndGame");
            Application.Quit();
        }
    }
    public void ReloadLevel(){
        CoinManager.instance.coins = 0;
        GridManager.instance.ClearGrid();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
