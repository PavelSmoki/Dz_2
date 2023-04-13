using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    [SerializeField] private float _interval = 3;
    [SerializeField] private int _minRange;
    [SerializeField] private int _maxRange = 4;
    [SerializeField] private float _time;

    void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _interval)
        {
            transform.position = new Vector3(transform.position.x, Random.Range(_minRange, _maxRange), Random.Range(_minRange, _maxRange));
            _time = 0;
        }
    }
}
