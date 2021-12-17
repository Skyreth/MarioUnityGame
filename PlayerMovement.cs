using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private int movespeed = 1;
    [SerializeField] 
    private PlayerInput controls;
    private Animator anim;
    private InputAction move, jump, sneakt;
    public bool isGrounded;
    private Rigidbody2D rg;
    private SpriteRenderer render;
    private bool sneak;

    private void Start() {
        rg = gameObject.GetComponent<Rigidbody2D>();
        render = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        isGrounded = false;
        sneak = false;
    }

    private void FixedUpdate()  {
        if (jump.ReadValue<float>() == 1 && isGrounded) Jump(225);
        if(sneakt.ReadValue<float>() == 1) SetSneak(true);
        if(sneakt.ReadValue<float>() == 0) SetSneak(false);

        Vector2 vec = move.ReadValue<Vector2>();
        render.flipX = (vec.x < 0);
        gameObject.transform.Translate(vec * movespeed * Time.deltaTime);
    }

    public void SetSneak(bool state) {
        if (state) anim.SetBool("Sneaking", true);
        else anim.SetBool("Sneaking", false);

        sneak = state;
    }

    public void Jump(int jumpforce) {
        Debug.Log("Grounded State: "+isGrounded);
        anim.SetBool("Jumping", true);
        rg.AddForce(new Vector2(0, jumpforce));
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ground") && !isGrounded) {
            isGrounded = true;
            anim.SetBool("Jumping", false);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Ground") && isGrounded) {
            isGrounded = false;
        }
    }

    private void OnEnable() {
        move = controls.actions["PlayerMove"];
        jump = controls.actions["Jump"];
        sneakt = controls.actions["Sneak"];
        sneakt.Enable();
        jump.Enable();
        move.Enable();
    }
    private void OnDisable() {
        move.Disable();
        jump.Disable();
        sneakt.Disable();
    }
}
