using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [HideInInspector] public int multiply;
    public Animator enemyAnim;
    private bool attacking;
    private bool isHit;

    private void Update()
    {
        if (GameObject.Find(GameData.gameObject_gameController).GetComponent<GameController>().gameStart)
        {
            Movement();
            Hit();
            Attack();
            OutOfArea();
        }
    }

    private void Movement()
    {
        if (!isHit)
        {
            this.gameObject.transform.Translate(new Vector2(5 * multiply, 0) * Time.deltaTime);
        }
        else
        {
            this.gameObject.transform.Translate(new Vector2(15 * multiply, 3) * Time.deltaTime);
        }
    }

    private void Hit() //hit by player
    {
        if (this.gameObject.transform.localRotation.y == 0)
        {
            if (this.gameObject.transform.localPosition.x >= -4f && this.gameObject.transform.localPosition.x <= -2f)
            {
                KnockBack(KeyCode.A);
            }
        }


        if (this.gameObject.transform.localRotation.y == 180)
        {
            if (this.gameObject.transform.localPosition.x >= 2f && this.gameObject.transform.localPosition.x <= 4f)
            {
                KnockBack(KeyCode.D);
            }
        }
    }

    private void KnockBack(KeyCode keyCode)
    {
        if (!isHit)
        {
            if (Input.GetKeyDown(keyCode))
            {
                isHit = true;
                multiply = multiply * -1;
                enemyAnim.Play(GameData.animState_hit, 0);
            }
        }
    }

    private void Attack() //attacking player
    {
        if (this.gameObject.transform.localPosition.x > -2f && this.gameObject.transform.localPosition.x < 0f)
        {
            GiveDamage();
        }

        if (this.gameObject.transform.localPosition.x < 2 && this.gameObject.transform.localPosition.x > 0f)
        {
            GiveDamage();
        }
    }

    private void GiveDamage()
    {
        if (!attacking)
        {
            attacking = true;
            enemyAnim.Play(GameData.animState_attack, 0);
            GameObject.Find(GameData.gameObject_gameController).GetComponent<PlayerController>().health--;
        }
    }

    private void OutOfArea()
    {
        if (this.gameObject.transform.localPosition.x < -10f || this.gameObject.transform.localPosition.x > 10)
        {
            Destroy(this.gameObject);
        }
    }
}
