using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameScene;

public class PlayerLife : MonoBehaviour {

    public int lifes = 5;
    [SerializeField] Transform respawnPoint = null;
    [SerializeField] Image[] imagesLifes = null;
    private void Awake() {
        DeadZone.OnAnyTouchZone += DeadZoneBehaviour;
        lifes = imagesLifes.Length;
    }

    private void ResetLifes() {
        lifes = imagesLifes.Length;
        foreach(Image i in imagesLifes){
            i.enabled = true;
        }
    }
    private void DeadZoneBehaviour(DeadZone zone){
        if(lifes > 0){
            lifes--;
            imagesLifes[lifes].enabled = false;
            transform.position = respawnPoint.position;
        }
        else {
            ResetLifes();
            SceneController.Instance.Load((int)ScenesInGame.mainMenu);
        }
    }
}