using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextManger : MonoBehaviour
{
    public TextMeshProUGUI textLevel;
    public TextMeshProUGUI textKey;
    public TextMeshProUGUI textHelp;
    private void Start()
    {
        transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
    }
    private void Update() {
        textLevel.text = "Level " + (SceneManager.GetActiveScene().buildIndex + 1).ToString();
        if(KeyManager.instance != null){
            if(KeyManager.instance.keys <= 1){
                textKey.text = "Key: ";
            } else {
                textKey.text = "Keys: ";
            }
            textKey.text = textKey.text + KeyManager.instance.keys.ToString();
        }
        HelpTextUpdate();
    }
    private void HelpTextUpdate(){
        switch(SceneManager.GetActiveScene().buildIndex + 1){
            case 1: textHelp.text = "Press arrow keys to move your square. The level will be complete if you reach the goal which is also a square!"; break;
            case 2: textHelp.text = "Collect all the coins to complete the level."; break;
            case 3: textHelp.text = "Beware of the traps! If you stuck somewhere, you can press R to Restart the level."; break;
            case 4: textHelp.text = "This level tried to trick you, not me."; break;
            case 5: textHelp.text = "Did you hear \"Graph Theory\"?"; break;
            case 6: textHelp.text = "Whenever you have a key and stand near by a lock you can go through it but you will lost that key!"; break;
            case 7: textHelp.text = "\"Not all the locks need to open\" - Dynamics"; break;
            case 8: textHelp.text = "What come around, go around."; break;
            case 9: textHelp.text = "What come around, go around v2.0."; break;
            case 10: textHelp.text = "\"There are always the better ways\" - Dynamics"; break;
            case 11: textHelp.text = "There're some boxes... Well, let's push 'em all"; break;
            case 12: textHelp.text = "These boxes tried to trick you, not this level."; break;
            case 13: textHelp.text = "\"Some locks really need to open\" - Dynamics"; break;
            case 14: textHelp.text = "What come around, go around v3.0."; break;
            default: textHelp.text = "Congratulations! You beat this game... Jk, it's just a demo."; break;
        }
    }
    public void ReloadLevel()
    {
        CoinManager.instance.coins = 0;
        GridManager.instance.ClearGrid();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
