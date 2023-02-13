using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    Vector3 startPoint, startPosition;
    Vector2 startWireEndSize;
    public SpriteRenderer wireEnd;

    private static int wiresSolved = 0;
    private const int TOTAL_NUMBER_OF_WIRES = 4;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;
        startWireEndSize = wireEnd.size;
        print("startPoint");
        print(startPoint);
    }

    // Update is called once per frame
    public void OnMouseDrag()
    {
        // mouse position
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        // check relative position
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, .2f);
        foreach(Collider2D collider in colliders)
        {
            if(collider.gameObject != gameObject)
            {
                UpdateWire(collider.transform.position);
                
                // check color wire
                if(transform.parent.name.Equals(collider.transform.parent.name))
                {                    

                    wiresSolved += 1;
                    // check if the puzzle was solved
                    if (wiresSolved >= TOTAL_NUMBER_OF_WIRES)
                        PuzzleManager.Instance.PuzzleSolved();

                    Destroy(this);
                }
                return;
            }
        }

        UpdateWire(newPosition);

    }   

    public void OnMouseUp()
    {
        // reset wire position
        UpdateWire(startPosition);
        wireEnd.size = startWireEndSize;
    }

    void UpdateWire(Vector3 newPosition)
    {
        print("startPoint");
        print(startPoint);
        // update position
        transform.position = newPosition;
        print("newPosition");
        print(newPosition);
        // update direction
        Vector3 direction = newPosition - startPoint;
        transform.up = direction;

        // update scale
        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(wireEnd.size.x, dist);
        // print(wireEnd.size);
    }
}
