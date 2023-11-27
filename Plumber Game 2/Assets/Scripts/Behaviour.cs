using UnityEditor;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    private Camera _camera;
    private bool isDragging = false;
    private Vector3 offset;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);

         
                DragAndDrop dragAndDropScript = hit.collider.GetComponent<DragAndDrop>();

                // If it doesn't have the script, add it
                if (dragAndDropScript == null)
                {
                    dragAndDropScript = hit.collider.gameObject.AddComponent<DragAndDrop>();
                }

                // Record the initial offset for dragging
                dragAndDropScript.StartDragging(offset);
                isDragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
        }

        if (isDragging)
        {
            // Update the offset during dragging
            offset = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
    }
}
