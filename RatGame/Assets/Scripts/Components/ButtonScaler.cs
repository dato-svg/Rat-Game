using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image currentImage;
    private Vector3 defaultScale;
    private Vector3 hoverScale;

    private void Start()
    {
        currentImage = GetComponent<Image>();
        defaultScale = transform.localScale;
        hoverScale = new Vector3(defaultScale.x * 1.2f, defaultScale.y * 1.2f, defaultScale.z);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = defaultScale;
    }
}