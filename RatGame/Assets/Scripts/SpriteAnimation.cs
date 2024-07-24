using UnityEngine;
using UnityEngine.Events;

public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] private float _framrate;
    [SerializeField] private bool _loop;
    [SerializeField] private Sprite[] _sprite;
    [SerializeField] private UnityEvent onFinish;

    private SpriteRenderer _spriteRenderer;
    private float _secondFrame;
    private int _currectSprite;
    private float _updateTime;



    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();


    }
    private void OnEnable()
    {
        _secondFrame = 1f / _framrate;
        _updateTime = Time.time + _secondFrame;
        _currectSprite = 0;

    }


    private void Update()
    {
        if (_updateTime > Time.time) return;
        if (_currectSprite >= _sprite.Length)
        {
            if (_loop)
            {
                _currectSprite = 0;
            }
            else
            {
                onFinish?.Invoke();
                enabled = false;
                return;
            }
        }
        _spriteRenderer.sprite = _sprite[_currectSprite];
        _updateTime += _secondFrame;
        _currectSprite++;


    }}
