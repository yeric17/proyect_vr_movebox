using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerUIRaycast : MonoBehaviour {
    [SerializeField] EventSystem eventSystem = null;
    [SerializeField] Camera playerCamera = null;

    private void Update() {
        UpdateRaycast();
    }
    private void UpdateRaycast(){
        RaycastHit hit;
        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward,out hit, 1000f);

        if(hit.collider != null){
            Debug.Log(hit.collider.gameObject.name);
        }
        PointerEventData pointer = new PointerEventData(eventSystem);
        List<RaycastResult> results = new List<RaycastResult>();

        pointer.position = playerCamera.transform.position;
        eventSystem.RaycastAll(pointer,results);
        
        Debug.Log(results.Count);
        
        
    }
}