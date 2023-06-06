using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour

{
private void OnCollisionEnter(Collision col)
    {
        int damageAmount = 20;

        if(col.collider.tag == "Player")
        {
            PlayerManager.currentHP -= damageAmount;
        }
    }
}
