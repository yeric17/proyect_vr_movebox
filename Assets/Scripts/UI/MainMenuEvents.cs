using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

public class MainMenuEvents : MonoBehaviour
{
   public void Play(int sceneIdx){
       SceneController.Instance.Load(sceneIdx);
   }

   public void Exit() {
       SceneController.Instance.Exit();
   }
}
