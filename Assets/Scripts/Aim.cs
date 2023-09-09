using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    
    private float yValue;
    [SerializeField] float sensetivity = -0.5f;
    private Vector3 rotate;
    private InputChannel inputChannel;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        var beacon = FindObjectOfType<BeaconScript>();
        inputChannel = beacon.inputChannel;
        inputChannel.cameraEvent += HandleChange;
    }

    void HandleChange(float value)
    {
        //Debug.Log(value);
        yValue = value;


    }




    void Update()
    {
        //yValue = Input.GetAxis("Mouse X");
        //Debug.Log(yValue);

        rotate = new Vector3(0, yValue * sensetivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;

    }

    private void OnDestroy()
    {
        inputChannel.cameraEvent -= HandleChange;
    }
    

}
