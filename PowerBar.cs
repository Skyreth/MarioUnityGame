using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    [SerializeField]
    private GameObject power;

    public GameObject getPowerSlot() {
        return power;
    }

    public bool hasPower() {
        return (power != null);
    }
    
    public void setPower(GameObject obj) {
        this.power = obj;
        gameObject.GetComponent<Image>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
    }
}
