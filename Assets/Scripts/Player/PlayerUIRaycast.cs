using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayerUIRaycast : MonoBehaviour {
    [SerializeField] EventSystem eventSystem = null;
    [SerializeField] Camera playerCamera = null;

    [SerializeField] LayerMask uiLayer = 0;

    public float secondsClick = 2f;
    private float _time = 0;
    private void Update() {
        _time += Time.deltaTime;
        UpdateRaycast();
    }
    private void UpdateRaycast(){
        RaycastHit hit;
        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward,out hit, 1000f,uiLayer);

        if(hit.collider != null){
            Button button = hit.collider.gameObject.GetComponent<Button>();
            button.Select();
            if(_time > secondsClick){
                ExecuteEvents.Execute(button.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
            }
        } 
        else  _time = 0;
    }
}