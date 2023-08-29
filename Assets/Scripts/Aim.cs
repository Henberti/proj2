using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    
    private float yValue;
    [SerializeField] float sensetivity = -4f;
    private Vector3 rotate;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        yValue = Input.GetAxis("Mouse X");
   
        rotate = new Vector3(0, yValue * sensetivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
        
    }
}
