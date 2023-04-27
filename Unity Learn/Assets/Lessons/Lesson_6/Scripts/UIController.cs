using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas _canvasPrefab;
    private Canvas _canvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_canvas == null)
            {
                _canvas = Instantiate(_canvasPrefab);
            }
            else
            {
                Destroy(_canvas.gameObject);
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Destroy(_canvas.gameObject);
    }
}
