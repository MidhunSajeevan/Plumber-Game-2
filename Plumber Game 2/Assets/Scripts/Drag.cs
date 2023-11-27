
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;

        // Detect other puzzle pieces underneath
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("PuzzlePiece") && collider.gameObject != gameObject)
            {
                SwapPositions(collider.gameObject);
            }
        }
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
