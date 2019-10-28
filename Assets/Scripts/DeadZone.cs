using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public static event Action<DeadZone> OnAnyTouchZone = delegate {};

    private void OnTriggerEnter(Collider other) {
        OnAnyTouchZone(this);
    }
}
