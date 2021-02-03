using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class CustomGUIBehavior : MonoBehaviour,
    IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler,
    IPointerExitHandler, IPointerDownHandler
{ 
    protected abstract void ClickAction();
    protected abstract void Init();

    public Color normalColor = Color.white;
    public Color ClickColor = Color.black;
    public Color HoverColor = Color.white;

    Image TargetGraphic;
    [Header("Sprites")]
    public Sprite HoverSprite;
    [HideInInspector]
    public Sprite DefaultSprite;

    private void Awake()
    {
        TargetGraphic = GetComponent<Image>();
        DefaultSprite = TargetGraphic.sprite;
        if (HoverSprite == null) HoverSprite = DefaultSprite;
        NormalState();
        Init();
    }

    //interfaces implementations
    //you can easily add all sorts of extra functionality in these methods
    public void OnPointerClick(PointerEventData eventData)
    {
        ClickAction();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverState();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        NormalState();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickState();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        HoverState();
    }

    //States

    //they are made virtual so you can override them if needed
    //otherwise you should make them private

    //private void HoverState()
    protected virtual void HoverState()
    {
        transform.localScale = Vector3.one * 1.1f;
        TargetGraphic.color = HoverColor;
        TargetGraphic.sprite = DefaultSprite;
    }
    protected virtual void ClickState()
    {
        transform.localScale = Vector3.one;
        TargetGraphic.color = ClickColor;
        TargetGraphic.sprite = HoverSprite;
    }
    protected virtual void NormalState()
    {
        transform.localScale = Vector3.one;
        TargetGraphic.color = normalColor;
        TargetGraphic.sprite = DefaultSprite;
    }
}
