using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlly : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Speed = 3f;
    public float MaxHealth = 3f;
    public float Health = 3f;
    public float Damage = 1f;
    private bool isAttacking = false;
    public GameObject Ally3Attack;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Jukebox = GameObject.Find("Jukebox").GetComponent<JukeBox>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Health != MaxHealth)
        {
            transform.parent.GetChild(1).gameObject.SetActive(true);
            transform.parent.GetChild(2).gameObject.SetActive(true);
            transform.parent.GetChild(1).position = new Vector3(0.4f * (Health - MaxHealth) / MaxHealth, 0.5f, 0) + transform.position;
            transform.parent.GetChild(2).position = new Vector3(0, 0.5f, 0) + transform.position;
            transform.parent.GetChild(1).localScale = new Vector3(0.8f * (Health / MaxHealth), 0.1f, 0);
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy;
        float closeDist = 999;
        if (enemies.Length <= 0)
        {
            closestEnemy = gameObject;
            GameObject.Find("Jukebox").GetComponent<JukeBox>().WhatShouldPlay();
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

        //transform.Lookat(closet enmy)
        Vector3 lookTarg = closestEnemy.transform.position;
        lookTarg.z = 0f;

        Vector3 objectPos = transform.position;
        lookTarg.x = lookTarg.x - objectPos.x;
        lookTarg.y = lookTarg.y - objectPos.y;
        float angle = Mathf.Atan2(lookTarg.y, lookTarg.x) * Mathf.Rad2Deg - 90;
        if (gameObject.name.Substring(0, 5) == "Ally3".Substring(0, 5))
        {
            angle = Mathf.Atan2(lookTarg.y, lookTarg.x) * Mathf.Rad2Deg - 220f;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, Speed);
        if (gameObject.name.Substring(0, 5) == "Ally3".Substring(0, 5) && isAttacking)
        {
            rb.AddForce((closestEnemy.transform.position - transform.position) * Time.deltaTime * -25);
        }
        else
        {
            rb.AddForce((closestEnemy.transform.position - transform.position) * Time.deltaTime * 100);
        }

        if (Health <= 0 && transform.GetComponent<Animator>().GetBool("isDead") == false)
        {
            StartCoroutine(Dying());
        }
        else
        {
            if (closeDist < 2.5f && !isAttacking)
            {
                isAttacking = true;
                StartCoroutine(Attack(closestEnemy));
            }
        }
    }

    private IEnumerator Attack(GameObject beingAttacked)
    {
        if (gameObject.name.Substring(0, 5) == "Ally1".Substring(0, 5))
        {
            GetComponent<AudioSource>().Play();
            transform.GetComponent<Animator>().SetBool("isAttacking", true);
            yield return new WaitForSeconds(0.5f);
            transform.GetComponent<Animator>().SetBool("isAttacking", false);
            isAttacking = false;
            if (Health > 0)
            {
                beingAttacked.GetComponent<BadChemicals>().Heatlh -= Damage;
                if (beingAttacked.GetComponent<BadChemicals>().Heatlh < 0)
                {
                    beingAttacked.GetComponent<BadChemicals>().Heatlh = 0;
                }
            }
        }
        else
        {
            //attack for ally3
            GetComponent<AudioSource>().Play();
            transform.GetComponent<Animator>().SetBool("isAttacking", true);
            yield return new WaitForSeconds(1.5f);
            if (Health > 0)
            {
                GameObject temp = Instantiate(Ally3Attack, transform.position + (2f * (transform.up + -transform.right)), transform.rotation);
                temp.GetComponent<GoodExploScript>().Strength = Damage;
            }
            yield return new WaitForSeconds(1.5f);
            transform.GetComponent<Animator>().SetBool("isAttacking", false);
            isAttacking = false;
        }
    }

    private IEnumerator Dying()
    {
        //dying
        transform.parent.GetComponent<AudioSource>().Play();
        transform.GetComponent<Animator>().SetBool("isDead", true);
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(1f);
        Destroy(transform.parent.gameObject);
    }
}
