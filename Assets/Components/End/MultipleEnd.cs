using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultipleEnd : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            LaunchEnd(other.gameObject);
    }

    private void LaunchEnd(GameObject player)
    {
        var script = player.GetComponent<PlayerController>();

        SceneManager.LoadScene(script.grades > 4 ? "Diploma" : "NoDiploma");
    }
}
