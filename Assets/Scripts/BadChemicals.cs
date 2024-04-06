using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadChemicals : MonoBehaviour
{
    public float Heatlh;
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
        float randX = Random.Range(-7f, 7f);
        dest = new Vector3(randX, randY, 0);
        yield return new WaitUntil(() => new Vector3(Mathf.Round(dest.x), Mathf.Round(dest.y), Mathf.Round(dest.z)) == new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z)));
        //yield return new WaitForSeconds(1f);
        StartCoroutine(GoDestMakeDest());
    }

    void Update()
    {
        //add force towards dest
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, Speed);
        //Debug.Log(dest);
        rb.AddForce((dest - transform.position) * Time.deltaTime * 100);
        if (Heatlh <= 0)
        {
            StartCoroutine(Dying());
        }
    }

    private IEnumerator Dying()
    {
        //death animation
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
