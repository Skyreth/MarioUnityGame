using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goomba : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.CompareTag("Player")) {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collider.bounds.center;

            bool bottom = contactPoint.y < center.y;
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            Player p = collision.gameObject.GetComponent<Player>();

            if (bottom && !player.isGrounded) {
                player.Jump(255);
                Destroy(gameObject);
            }
            else {
                if (p.hasPower()) p.resetPower();
                else p.setHealth(p.getHealth() - 1);
            }
        }
    }
}
