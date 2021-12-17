using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField]
    private int movespeed;
    [SerializeField]
    private int mushroomlvl;

    void Update() {
        gameObject.transform.Translate(Vector2.right * movespeed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Player player = collision.GetComponent<Player>();
            Debug.Log("PowerState: " + player.hasPower());
            Debug.Log("PowerBar Power State: " + player.getPowerBar().hasPower());

            if (!player.hasPower()) {
                setMushroom(player, mushroomlvl);
                player.setPower(gameObject);
            }
            else if (!player.getPowerBar().hasPower()) {
                player.getPowerBar().setPower(gameObject);
            }

            Destroy(gameObject);
        }
    }
    void setMushroom(Player p, int level) {
        if (level == 1) p.transform.localScale = new Vector3(1.5f, 2f, 1f);
        else if (level == 2) {
            p.getMovement().Jump(300);
            p.transform.localScale = new Vector3(4f, 6f, 1f); 
        }
        else p.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
