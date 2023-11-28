
using Unity.Mathematics;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private SpriteRenderer spriteRenderer;
    Vector2 Temp;
    private void OnMouseDown()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 2;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Temp = transform.position;
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
        spriteRenderer.sortingOrder = 1;

      
        Collider2D colliders1 = Physics2D.OverlapBox(transform.position,transform.localScale,2);
        if(colliders1 == null )
        {
            transform.position = Temp; 
        }
   
        transform.position = colliders1.transform.position;
        colliders1.transform.position = Temp;   
        
    }
    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x + offset.x, mousePos.y + offset.y);
        }
    }

    private void Update()
    {
        
        if (isDragging)
        {
            Vector2 MousePositon = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(MousePositon);
        }
    }
    void SwapPositions(GameObject otherPuzzle)
    {
        Vector3 tempPos = otherPuzzle.transform.position;
        otherPuzzle.transform.position = transform.position;
        transform.position = tempPos;
    }
}
