using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeAScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            GivingPoint(other);
    }

    private void GivingPoint(Collision2D player)
    {
        var game = player.gameObject;
        var script = game.GetComponent<PlayerController>();
        script.grades += 1;
        Destroy(gameObject);
    }
}
