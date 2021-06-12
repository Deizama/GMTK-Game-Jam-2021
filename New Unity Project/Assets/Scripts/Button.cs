using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite buttonPressed;
    public Sprite buttonUnpressed;

    public int howLongPressed = 100;

    private bool isPressed;

    private Collider2D bc;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        bc = this.GetComponent<Collider2D>();
        sr.sprite = buttonUnpressed;
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 6)
        {
            sr.sprite = buttonPressed;
            isPressed = true;

            Debug.Log("Button pressed");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (howLongPressed != 100)
        {
            Debug.Log("Countdown...");
            CountdownCoroutine();
        }
    }


    IEnumerator CountdownCoroutine()
    {
        yield return new WaitForSeconds(howLongPressed);

        sr.sprite = buttonUnpressed;
        isPressed = false;
    }
}
