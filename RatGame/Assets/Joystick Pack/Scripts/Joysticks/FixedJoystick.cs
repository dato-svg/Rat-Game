using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    protected override void Start()
    {
        background.gameObject.SetActive(false);
        base.Start();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.localPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        base.OnPointerUp(eventData);
    }
}