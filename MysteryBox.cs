using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    public GameObject[] loots;
    public GameObject wall;

    void Start() {
       wall = GameObject.Find("wall");
    }

    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D collision)  {
        Collider2D collider = collision.collider;

        if (collider.CompareTag("Player")) {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collider.bounds.center;

            bool right = contactPoint.x > center.x;
            bool top = contactPoint.y > center.y;

            if(top) {
                GameObject obj = loots[Random.Range(0, loots.Length)];
                Instantiate(obj, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), gameObject.transform.rotation);

                if (wall != null) Instantiate(wall, new Vector3(transform.position.x, transform.position.y, transform.position.z), gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
