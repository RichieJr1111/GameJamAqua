using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadChemicals : MonoBehaviour
{
    public float MaxHeatlh = 3;
    public float Heatlh;
    public float Speed;
    public Vector3 dest;
    private Rigidbody2D rb;
    public bool anAttacker = false;
    public bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoDestMakeDest());
        rb = GetComponent<Rigidbody2D>();
    }


    public void RandomSpawn()
    {
        float randY = Random.Range(-5f, 5f);
        float randX = Random.Range(-8.5f, 8.5f);
        dest = new Vector3(randX, randY, 0);
        Debug.Log("1: " + randX);
        Debug.Log("1: " + randY);
        while (!(!(randX < -3 && randY < -3) && !(randX > 6 && randY < -3))) // x -3 to - 9 , y = -3 to - 5
        {
            randY = Random.Range(-5f, 5f);
            randX = Random.Range(-8.5f, 8.5f);
            dest = new Vector3(randX, randY, 0);
            if (dest == new Vector3(0, 0, 0))
            {
                randY = Random.Range(-5f, 5f);
                randX = Random.Range(-8.5f, 8.5f);
            }
        }
        Debug.Log(randX);
        Debug.Log(randY);
        transform.position = dest;
    }

    private IEnumerator GoDestMakeDest()
    {
        float randY = Random.Range(-5f, 5f);
        float randX = Random.Range(-8.5f, 8.5f);
        dest = new Vector3(randX, randY, 0);
        Debug.Log("1: " + randX);
        Debug.Log("1: " + randY);
        while (!(!(randX < -3 && randY < -3) && !(randX > 6 && randY < -3))) // x -3 to - 9 , y = -3 to - 5
        {
            randY = Random.Range(-5f, 5f);
            randX = Random.Range(-8.5f, 8.5f);
            dest = new Vector3(randX, randY, 0);
            if (dest == new Vector3(0, 0, 0))
            {
                randY = Random.Range(-5f, 5f);
                randX = Random.Range(-8.5f, 8.5f);
            }
        }
        Debug.Log(randX);
        Debug.Log(randY);
        yield return new WaitUntil(() => new Vector3(Mathf.Round(dest.x), Mathf.Round(dest.y), Mathf.Round(dest.z)) == new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z)));
        //yield return new WaitForSeconds(1f);
        StartCoroutine(GoDestMakeDest());
    }

    void Update()
    {
        if (Heatlh != MaxHeatlh)
        {
            transform.parent.GetChild(1).gameObject.SetActive(true);
            transform.parent.GetChild(2).gameObject.SetActive(true);
            transform.parent.GetChild(1).position = new Vector3(0.5f * (Heatlh - MaxHeatlh) / MaxHeatlh, 0.5f, 0) + transform.position;
            transform.parent.GetChild(2).position = new Vector3(0, 0.5f, 0) + transform.position;
            transform.parent.GetChild(1).localScale = new Vector3(0.8f * (Heatlh / MaxHeatlh), 0.1f, 0);
        }

        if (Heatlh <= 0 && transform.GetComponent<Animator>().GetBool("isDead") == false)
        {
            StartCoroutine(Dying());
        }
        else if (anAttacker)
        {        
            if (GameObject.FindGameObjectWithTag("GoodGuy") != null)
            {
                GameObject[] goodGuys = GameObject.FindGameObjectsWithTag("GoodGuy");
                GameObject closestGood = goodGuys[0];
                float closeDist = Vector3.Distance(goodGuys[0].transform.position, transform.position);
                foreach (GameObject Good in goodGuys)
                {
                    float Dist = Vector3.Distance(Good.transform.position, transform.position);
                    if (Dist < closeDist)
                    {
                        closeDist = Dist;
                        closestGood = Good;
                    }
                }
                dest = closestGood.transform.position;
                if (!isAttacking && closeDist < 0.8f)
                {
                    isAttacking = true;
                    StartCoroutine(Attack(closestGood));
                }
            }
            Vector3 lookTarg = dest;
            lookTarg.z = 0f;

            Vector3 objectPos = transform.position;
            lookTarg.x = lookTarg.x - objectPos.x;
            lookTarg.y = lookTarg.y - objectPos.y;

            float angle = Mathf.Atan2(lookTarg.y, lookTarg.x) * Mathf.Rad2Deg - 150f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        //add force towards dest
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, Speed);
        //Debug.Log(dest);
        rb.AddForce((dest - transform.position) * Time.deltaTime * 100);
    }

    private IEnumerator Attack(GameObject beingAttacked)
    {
        GetComponent<AudioSource>().Play();
        transform.GetComponent<Animator>().SetBool("isAttacking", true);
        yield return new WaitForSeconds(0.75f);
        transform.GetComponent<Animator>().SetBool("isAttacking", false);
        isAttacking = false;
        if (Heatlh > 0)
        {
            beingAttacked.GetComponent<PlayerAlly>().Health--; //might have diff sciprts add switch statement later
            if (beingAttacked.GetComponent<PlayerAlly>().Health < 0)
            {
                beingAttacked.GetComponent<PlayerAlly>().Health = 0;
            }
        }
    }

    private IEnumerator Dying()
    {
        //death animation
        transform.parent.GetComponent<AudioSource>().Play();
        transform.GetComponent<Animator>().SetBool("isDead", true);
        gameObject.tag = "Untagged";
        increasestat.Money++;
        yield return new WaitForSeconds(1f);
        Destroy(transform.parent.gameObject);
    }
}
