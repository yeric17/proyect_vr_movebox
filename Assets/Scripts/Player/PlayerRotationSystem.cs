﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRotationSystem : MonoBehaviour
{

    [SerializeField] Transform YRotation = null;
    [SerializeField] Transform XRotation = null;

    public float VerticalSensitivy = 20f;
    public float HorizontalSensitivy = 20f;

    private Vector3 VecYRotation = Vector3.zero;
    private Vector3 VecXRotation = Vector3.zero;
    private bool canRotate = true;
    private void Update()
    {
        UpdateRotate();
    }

  
    private void UpdateRotate()
    {

        VecYRotation = new Vector3(0, Input.GetAxis("Mouse X") * HorizontalSensitivy, 0);
        VecXRotation = new Vector3(-Input.GetAxis("Mouse Y") * VerticalSensitivy, 0, 0);


        // nextRotation_X es la siguiente rotación en el eje X que se va aplicar
        float nextRotation_X = XRotation.rotation.eulerAngles.x + VecXRotation.x;

        canRotate = !(nextRotation_X > 80 && nextRotation_X < 280);
    }

    private void FixedUpdate()
    {
        if (canRotate)
        {
            YRotation.Rotate(VecYRotation);
            XRotation.Rotate(VecXRotation);
        }
    }
}
