using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlly : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed = 3f;
    public float Health = 3f;
    private bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closeDist = 999;
        if (enemies.Length <= 0)
        {
            closestEnemy = gameObject;
        }
        else
        {
            closestEnemy = enemies[0];
            closeDist = Vector3.Distance(enemies[0].transform.position, transform.position);
        }
        foreach (GameObject Enemy in enemies)
        {
            float Dist = Vector3.Distance(Enemy.transform.position, transform.position);
            if (Dist < closeDist)
            {
                closeDist = Dist;
                closestEnemy = Enemy;
            }
        }

        if (closeDist < 1f && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(Attack(closestEnemy));
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, Speed);
        rb.AddForce((closestEnemy.transform.position - transform.position) * Time.deltaTime * 100);

        if (Health <= 0)
        {
            StartCoroutine(Dying());
        }
    }

    private IEnumerator Attack(GameObject beingAttacked)
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        beingAttacked.GetComponent<BadChemicals>().Heatlh--; //might have diff sciprts add switch statement later
    }

    private IEnumerator Dying()
    {
        //death animation
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
