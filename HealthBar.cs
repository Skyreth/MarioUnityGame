using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Text text;
    private Player p;
    void Start() {
        text = gameObject.GetComponentInChildren<Text>();
        p = GameObject.Find("Joueur").GetComponent<Player>();
    }

    void Update() {
        if(p != null) text.text = "x " + p.getHealth();
    }
}
