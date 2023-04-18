using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private List<GameObject> _enemies;

    private void Awake()
    {
        _canvas.GameObject().SetActive(false);
    }

    private void FixedUpdate()
    {
        foreach (var enemy in _enemies.Where(enemy => enemy == null))
        {
            _enemies.Remove(enemy);
        }

        if (_enemies.Count == 0)
        {
            _canvas.GameObject().SetActive(true);
        }
    }
}
