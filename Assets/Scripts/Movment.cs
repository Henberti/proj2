using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float movemet_speed = 5f;
    [SerializeField] float rotation_speed = 180f;

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * movemet_speed;




        transform.Translate(0, 0, zValue);

        transform.Rotate(Vector3.up * xValue * rotation_speed * Time.deltaTime);

    }
}
