using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPoint;
    public float fireBallSpeed = 600;

   public void FireballAttack()
    {
        GameObject ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);

    }
}
