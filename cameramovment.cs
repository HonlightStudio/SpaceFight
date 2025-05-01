using System;
using UnityEngine;
using UnityEngine.Serialization;

public class cameramovment : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D player;
    [SerializeField] private RectTransform TopRight;
    [SerializeField] private RectTransform BottomLeft;
    [SerializeField] private float speed;
    private Camera cam;
    // Update is called once per frame
    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(player.transform.position.y> cam.ScreenToWorldPoint(TopRight.position).y && player.linearVelocityY>0) transform.position=new Vector3(transform.position.x,Mathf.SmoothStep(transform.position.y,player.position.y,speed),-3);
        if(player.transform.position.y< cam.ScreenToWorldPoint(BottomLeft.position).y && player.linearVelocityY<0) transform.position= 
            new Vector3(transform.position.x,Mathf.SmoothStep(transform.position.y,player.position.y,speed),-3);
    }
}
