using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class MouseObject : MonoBehaviour, IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    
    }
}
