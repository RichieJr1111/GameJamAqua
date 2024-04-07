using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundobjects : MonoBehaviour
{
    public float Speed;
    public Vector3 dest;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoDestMakeDest());
        rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator GoDestMakeDest()
    {
        float randY = Random.Range(-5f, 5f);
        float randX = Random.Range(-8.5f, 8.5f);
        while (!(!(randX < -3 && randY < -3) && !(randX > 6 && randY < -3))) // x -3 to - 9 , y = -3 to - 5
        {
            randY = Random.Range(-5f, 5f);
            randX = Random.Range(-8.5f, 8.5f);
            dest = new Vector3(randX, randY, 0);
        }
        yield return new WaitUntil(() => new Vector3(Mathf.Round(dest.x), Mathf.Round(dest.y), Mathf.Round(dest.z)) == new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z)));
        //yield return new WaitForSeconds(1f);
        StartCoroutine(GoDestMakeDest());
    }

    void Update()
    {
            Vector3 lookTarg = dest;
            lookTarg.z = 0f;

            Vector3 objectPos = transform.position;
            lookTarg.x = lookTarg.x - objectPos.x;
            lookTarg.y = lookTarg.y - objectPos.y;

            float angle = Mathf.Atan2(lookTarg.y, lookTarg.x) * Mathf.Rad2Deg - 150f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            //add force towards dest
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, Speed);
        Debug.Log(dest);
        rb.AddForce((dest - transform.position) * Time.deltaTime * 100);
        }

    }

