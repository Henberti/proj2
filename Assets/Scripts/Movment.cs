using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float movemet_speed = 5f;
    [SerializeField] float rotation_speed = 180f;
    InputChannel inputChannel;
    Vector3 movmentDir = Vector3.zero;


    private void Start()
    {
       var beacon =  FindObjectOfType<BeaconScript>();
        inputChannel = beacon.inputChannel;
        inputChannel.moveEvent += HandleMovement;
    }





    public void HandleMovement(Vector3 value)
    {
        movmentDir = value;
        //float xValue = value.x;
        //float zValue = value.z * Time.deltaTime * movemet_speed;

        //transform.Translate(0, 0, zValue);

        //transform.Rotate(Vector3.up * xValue * rotation_speed * Time.deltaTime);

    }

    public void Update()
    {
        float xValue = movmentDir.x;
        float zValue = movmentDir.z * Time.deltaTime * movemet_speed;

        transform.Translate(0, 0, zValue);

        transform.Rotate(Vector3.up * xValue * rotation_speed * Time.deltaTime);

    }
    private void OnDestroy()
    {
        inputChannel.moveEvent -= HandleMovement;
    }

}
