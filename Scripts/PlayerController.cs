using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public int health = 3;
    public GameObject rhand;
    public GameObject lhand;

    private void Update()
    {
        RightPunch();
        LeftPunch();
        NormalRotation();
        print("Health : " + health);
        GameOver();
    }

    private void GameOver()
    {
        if (health <= 0)
        {
            print("GAME OVER");
        }
    }

    public void RightPunch()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rhand.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }

    public void LeftPunch()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            lhand.transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
    }

    private void NormalRotation()
    {
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            rhand.transform.localRotation = Quaternion.Euler(0, 0, 0);
            lhand.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
