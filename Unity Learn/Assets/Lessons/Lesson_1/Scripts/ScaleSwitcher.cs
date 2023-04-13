using UnityEngine;

public class ScaleSwitcher : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _maxScale = 3f;
    [SerializeField] private Vector3 _scale;

    private void Start()
    {
        _scale = Vector3.one * _maxScale;
    }
    void Update()
    {
        transform.localScale += Vector3.one * (_speed * Time.deltaTime);
        if (transform.localScale.x > _scale.x) transform.localScale = Vector3.one;
    }
}
