using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            PlayerMovement player = (PlayerMovement) collision.GetComponent<PlayerMovement>();
            //transform.Translate(new Vector2(transform.position.x, transform.position.y-1));
            player.Jump(255);

        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            transform.Translate(new Vector2(transform.position.x, (transform.position.y-1)));
        }
    }

    IEnumerator Animation()
    {
        for(float i=0f;i!=1f;i+=0.1f) {
            transform.Translate(new Vector2(transform.position.x, transform.position.y + i));
        }
        yield return null;
    }


    void Update() {
        
    }
}
