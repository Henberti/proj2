using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    
    private float yValue;
    [SerializeField] float sensetivity = -4f;
    private Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yValue = Input.GetAxis("Mouse X");
        //xValue = Input.GetAxis("Mouse Y");
        rotate = new Vector3(0, yValue * sensetivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
        
    }
}
