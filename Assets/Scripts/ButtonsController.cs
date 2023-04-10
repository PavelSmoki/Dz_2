using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private TextMeshProUGUI _textMesh;
    private GameObject _obj;
    private int _indexOfObj;
    private Material _defaultMaterial;
    private Renderer _renderer;

    private void Start()
    {
        _obj = _objects[_indexOfObj];
        _renderer = _obj.GetComponent<Renderer>();
        _renderer.material.color = Color.red;
        SetText();
    }

    public void IncreaseScale()
    {
        _obj.transform.localScale += Vector3.one;
        SetText();
    }

    public void DecreaseScale()
    {
        _obj.transform.localScale -= Vector3.one;
        SetText();
    }

    public void ChangeRotation()
    {
        _obj.transform.Rotate(Vector3.right, 30f);
        SetText();
    }

    public void LeftArrow()
    {
        if (_indexOfObj == 0) _indexOfObj = _objects.Length - 1;
        else _indexOfObj--;
        ChangeObject();
    }

    public void RightArrow()
    {
        if (_indexOfObj == _objects.Length - 1) _indexOfObj = 0;
        else _indexOfObj++;
        ChangeObject();
    }

    private void ChangeObject()
    {
        _renderer.material.color = Color.white;
        _obj = _objects[_indexOfObj];
        _renderer = _obj.GetComponent<Renderer>();
        _renderer.material.color = Color.red;
        SetText();
    }

    private void SetText()
    {
        _textMesh.text = "Position: " +
                         "X: " + _obj.transform.position.x + " " +
                         "Y: " + _obj.transform.position.y + " " +
                         "Z: " + _obj.transform.position.z + "\n" +
                         "Rotation: " +
                         "X: " + _obj.transform.rotation.x + " " +
                         "Y: " + _obj.transform.rotation.y + " " +
                         "Z: " + _obj.transform.rotation.z + "\n" +
                         "Scale: " +
                         "X: " + _obj.transform.localScale.x + " " +
                         "Y: " + _obj.transform.localScale.y + " " +
                         "Z: " + _obj.transform.localScale.z;
    }

    public void PrevScene()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        if (index == 0) index = 3;
        SceneManager.LoadScene(index - 1);
    }

    public void NextScene()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        if (index == 2) index = -1;
        SceneManager.LoadScene(index + 1);
    }
}