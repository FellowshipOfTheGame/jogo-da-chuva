using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Puzzle;

public class TileMovement : MonoBehaviour
{
    public Tile tile { get; set; }

    private Vector3 GetCorrectPosition()
    {
        return new Vector3(tile.xIndex * 400.0f, tile.yIndex * 400.0f, 0.0f);
    }

    private Vector3 mOffset = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
        return;
        }

        mOffset = transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
    }

    void OnMouseDrag()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
        return;
        }
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + mOffset;
        transform.position = curPosition;
    }

    void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
        return;
        }
        float dist = (transform.position - GetCorrectPosition()).magnitude;
        
        if (dist < 80.0f)
        {
            transform.position = GetCorrectPosition();
            GetComponent<BoxCollider2D>().enabled = false;
            transform.parent.GetComponent<BoardGen>().mTotalTilesInCorrectPosition+=1;
            if(transform.parent.GetComponent<BoardGen>().mTotalTilesInCorrectPosition == 12)
            {
                print("finished");
            }
            // OnTileInPlace?.Invoke(this);
        }
    }

    
}
