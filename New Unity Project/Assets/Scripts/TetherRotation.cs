using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherRotation : MonoBehaviour
{
    public GameObject ghostTether;
    public GameObject humanTether;
    public GameObject lineTether;

    public GameObject humanCharacter;
    public GameObject ghostCharacter;

    private SpriteRenderer tetherSprite;

    // Start is called before the first frame update
    void Start()
    {
        tetherSprite = lineTether.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // We get the rotation of both end of the tether
        humanTether.transform.right = ghostCharacter.transform.position - humanTether.transform.position;
        ghostTether.transform.right = humanCharacter.transform.position - ghostTether.transform.position;
        // Rotation of the line in between
        lineTether.transform.right = humanTether.transform.right;

        // We change the position of the ends of the tether
        ghostTether.transform.position = ghostCharacter.transform.position + ghostTether.transform.right;
        humanTether.transform.position = humanCharacter.transform.position + humanTether.transform.right;
        // Position of the line
        lineTether.transform.position = (ghostTether.transform.position + humanTether.transform.position) / 2 ;

        // Size of the line
        float distance = Vector2.Distance(ghostTether.transform.position, humanTether.transform.position);

        if (distance < 1)
        {
            if (distance < 0.1)
            {
                humanTether.GetComponent<SpriteRenderer>().enabled = false;
                ghostTether.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                humanTether.GetComponent<SpriteRenderer>().size = new Vector2(distance,1);
                ghostTether.GetComponent<SpriteRenderer>().size = new Vector2(distance, 1);
                humanTether.GetComponent<SpriteRenderer>().enabled = true;
                ghostTether.GetComponent<SpriteRenderer>().enabled = true;
            }
            tetherSprite.enabled = false;
        }
        else
        {
            tetherSprite.enabled = true;
            tetherSprite.size = new Vector2(distance, 1);
        }
    }
}
