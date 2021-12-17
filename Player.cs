using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int heart = 5;
    [SerializeField]
    private GameObject pwbar;
    private PowerBar pbar;
    private GameObject power;
    private PlayerMovement movement;

    void Start() {
        movement = gameObject.GetComponent<PlayerMovement>();
        pbar = pwbar.GetComponent<PowerBar>();
    }

    public PlayerMovement getMovement() {
        return movement;
    }

    public void resetPower() {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        power = null;
    }

    public GameObject getPower() {
        return power;
    }

    public void setPower(GameObject po) {
        this.power = po;
    }

    public bool hasPower() {
        return !(power == null);
    }

    public PowerBar getPowerBar() {
        return pbar;
    }

    public int getHealth() {
        return heart;
    }

    public void setHealth(int health) {
        if(health >= 1) heart = health;
    }
}
