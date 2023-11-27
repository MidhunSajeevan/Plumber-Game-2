using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    // Called when dragging starts
    public void StartDragging(Vector3 initialOffset)
    {
        isDragging = true;
        offset = initialOffset;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x + offset.x, mousePos.y + offset.y);

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
        }
    }
}
