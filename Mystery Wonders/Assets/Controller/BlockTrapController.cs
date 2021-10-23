using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BlockTrapController : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            GridManager.instance.SetExist(GridManager.instance.GridPosition(transform.position), true);
            GetComponent<SpriteRenderer>().color = new Color(135f / 255, 135f / 255, 135f / 255, 1);
            GetComponent<ShadowCaster2D>().useRendererSilhouette = true;
            GetComponent<ShadowCaster2D>().castsShadows = true;
        }
    }
}
